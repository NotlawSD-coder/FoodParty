using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    CoasterControls inputActions;

    public float shopDuration;

    private bool isOpen;

    public TextMeshProUGUI timer;

    [HideInInspector]
    public BoardEntity shopInteractor;

    public ShopItemsPanel itemsPanel;
    public SelectedItem selectedItemPanel;

    public ShopElementUI shopItemPrefab;

    public List<ShopElementUI> shopItems = new List<ShopElementUI>();

    List<Selectable> autobuyDisabled = new List<Selectable>();

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Awake()
    {
        CreateInputs();
        shopItems = new List<ShopElementUI>();
        selectedItemPanel.shop = this;
        CreateItems();
        LoadItems();
        gameObject.SetActive(false);
    }

    public void CreateInputs()
    {
        inputActions = new CoasterControls();
        /*
        inputActions.Shop.PreviousItem.performed += _ => SelectPreviousItem();
        inputActions.Shop.NextItem.performed += _ => SelectNextItem();
        */
        inputActions.Shop.IncreaseAmount.performed += _ => selectedItemPanel.itemAmount++;
        inputActions.Shop.DecreaseAmount.performed += _ => selectedItemPanel.itemAmount--;
        inputActions.Shop.Buy.performed += _ => BuyItem();
        inputActions.Shop.Sell.performed += _ => SellItem();
    }

    private void Start()
    {
        StartCoroutine(RunTimer());
    }

    private IEnumerator RunTimer()
    {
        float counter = 0f;
        while (counter < shopDuration && isOpen)
        {
            timer.text = $"{(int)(shopDuration - counter)}";
            counter += Time.deltaTime;
            yield return null;
        }
        shopInteractor.currentCoaster.EndInteract(shopInteractor);
    }

    private void CreateItems()
    {
        foreach(RecipeElement rE in Resources.LoadAll<RecipeElement>("Recipes/RecipeElements"))
        {
            //Debug.Log(rE.GetType());
            ShopElementUI sEUI = Instantiate(shopItemPrefab);
            sEUI.shop = this;
            sEUI.recipeElement = rE;
            switch (rE)
            {
                case Flavor flavor:
                    sEUI.amount = 1;
                    //sEUI.maxAmount = 1;
                    break;

                case Ingredient ingredient:
                    sEUI.amount = 5;
                    //sEUI.maxAmount = 5;
                    break;
            }
            sEUI.gameObject.transform.SetParent(itemsPanel.elementsContentPanel.transform);
            shopItems.Add(sEUI);
        }
    }

    public void LoadItems()
    {
        foreach (ShopElementUI sEUI in shopItems)
        {
            sEUI.itemName = sEUI.recipeElement.name;
            sEUI.itemSprite = sEUI.recipeElement.icon;
            sEUI.itemCost = sEUI.recipeElement.buyCost;
        }
        /* // Moved to OpenShop()
        shopItems[0].GetComponent<Button>().Select();
        Debug.Log("Selecting the first item,");
        shopItems[0].SelectItem();
        */
    }

    public void OpenShop(BoardEntity entity, bool visible = true)
    {
        //Debug.Log("Open shop!");
        shopInteractor = entity;
        isOpen = true;
        shopItems[0].GetComponent<Button>().Select();
        shopItems[0].SelectItem();
        gameObject.SetActive(true);
        if (!visible) gameObject.GetComponent<Canvas>().enabled = false;
    }

    public void CloseShop()
    {
        //shopInteractor.currentCoaster.EndInteract(); // Moved to coroutine
        isOpen = false;
        //gameObject.SetActive(false);
    }

    public void AutoBuy()
    {
        StartCoroutine(AutoBuyCo());
    }

    public IEnumerator AutoBuyCo()
    {

        //Debug.Log("Auto buying.");
        Recipe recipe = GameBoardManager.singleton.recipeStates[shopInteractor];

        //Debug.Log("Recipe at start:\n" + recipe.ToString());

        foreach (ShopElementUI sE in shopItems)
        {
            if (recipe.requiredElements.ContainsKey(sE.recipeElement))
            {
                int requiredAmount = recipe.requiredElements[sE.recipeElement] - recipe.currentElements[sE.recipeElement];
                if (requiredAmount > 0)
                {
                    int amountBought = Mathf.Clamp(shopInteractor.coins / sE.recipeElement.buyCost, 0, requiredAmount);
                    shopInteractor.coins -= amountBought * sE.recipeElement.buyCost;
                    recipe.SetCurrentElement(sE.recipeElement, recipe.currentElements[sE.recipeElement] + amountBought);
                    yield return new WaitForSeconds(.25f);
                }
                yield return new WaitForSeconds(.15f);
            }
        }
        yield return new WaitForSeconds(1f);
        shopInteractor.currentCoaster.EndInteract(shopInteractor);
        yield return null;
    }

    public void BuyItem()
    {
        if(selectedItemPanel.itemAmount > selectedItemPanel.selected.amount || selectedItemPanel.buyCost > shopInteractor.coins)
        {
            Debug.LogWarning("Couldn't proceed with the purchase because interactor doesn't have enough coins.");
            return;
        }
        // Update coins
        shopInteractor.coins -= selectedItemPanel.buyCost;
        if (!GameBoardManager.singleton.recipeStates[shopInteractor].currentElements.ContainsKey(selectedItemPanel.selected.recipeElement)) GameBoardManager.singleton.recipeStates[shopInteractor].currentElements.Add(selectedItemPanel.selected.recipeElement, selectedItemPanel.itemAmount);
        else
        {
            int newAmount = GameBoardManager.singleton.recipeStates[shopInteractor].currentElements[selectedItemPanel.selected.recipeElement] + selectedItemPanel.itemAmount;
            // Add X amount of recipe elements
            GameBoardManager.singleton.recipeStates[shopInteractor].SetCurrentElement(selectedItemPanel.selected.recipeElement, newAmount);
        }

        // Update shop element UI amount value.
        selectedItemPanel.selected.amount -= selectedItemPanel.itemAmount;
        selectedItemPanel.UpdatePanel();

        // Update recipe display
        // RecipeManagerUI.singleton.UpdateDisplay(shopInteractor); // Ya no ?????
    }

    public void SellItem()
    {
        if (!GameBoardManager.singleton.recipeStates[shopInteractor].currentElements.ContainsKey(selectedItemPanel.selected.recipeElement) || selectedItemPanel.itemAmount > GameBoardManager.singleton.recipeStates[shopInteractor].currentElements[selectedItemPanel.selected.recipeElement])
        {
            Debug.LogWarning("Couldn't proceed with the sale because interactor doesn't have enough elements.");
            return;
        }

        // Update coins
        shopInteractor.coins += selectedItemPanel.sellCost;
        int newAmount = GameBoardManager.singleton.recipeStates[shopInteractor].currentElements[selectedItemPanel.selected.recipeElement] - selectedItemPanel.itemAmount;
        
        // Remove X amount of recipe elements
        GameBoardManager.singleton.recipeStates[shopInteractor].SetCurrentElement(selectedItemPanel.selected.recipeElement, newAmount);

        // Update shop element UI amount value.
        selectedItemPanel.selected.amount += selectedItemPanel.itemAmount;
        selectedItemPanel.UpdatePanel();

        // Update recipe display
        // RecipeManagerUI.singleton.UpdateDisplay(shopInteractor); // Ya no ???
    }
}