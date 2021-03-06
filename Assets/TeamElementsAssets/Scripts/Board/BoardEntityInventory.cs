using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardEntityInventory : MonoBehaviour
{
    public ItemsCanvas itemsCanvasPrefab;

    public BoardEntity owner;

    public Dictionary<BoardItem_Base, int> items = new Dictionary<BoardItem_Base, int>();

    public ItemsCanvas itemsCanvasInstance;

    public bool canUseItem
    {
        get
        {
            return _canUseItem;
        }
        set
        {
            _canUseItem = value;
        }
    }
    private bool _canUseItem;

    public bool isUsingItem
    {
        get
        {
            return _isUsingItem;
        }
        set
        {
            _isUsingItem = value;
        }
    }
    private bool _isUsingItem;

    public bool visible
    {
        get
        {
            return _visible;
        }
        set
        {
            _visible = value;
        }
    }
    private bool _visible;

    protected virtual void Awake()
    {
        itemsCanvasPrefab = Resources.Load<ItemsCanvas>("UI/PlayerItemsUI");
        visible = false;
        TryGetComponent(out owner);
        //AddItem(Resources.LoadAll<BoardItem_Base>("BoardItems/Items")[0], 1); // XDDD
        //AddItem(Resources.LoadAll<BoardItem_Base>("BoardItems/Items")[1], 1); // XDDD
        //AddItem(Resources.LoadAll<BoardItem_Base>("BoardItems/Items")[2], 1); // XDDD
    }

    public void ToggleItemsUI()
    {
        if (visible)
        {
            owner.LockTPC();
        } else
        {
            owner.UnlockTPC();
        }
        itemsCanvasInstance.enabled = visible;
        itemsCanvasInstance.gameObject.SetActive(visible);
    }

    public virtual void Create()
    {
        //Debug.Log($"{owner.name} Esto es una pruebahfuriejnergerm");
        itemsCanvasInstance = Instantiate(itemsCanvasPrefab);
        itemsCanvasInstance.transform.SetParent(GameBoardManager.singleton.uiParent.transform);
        itemsCanvasInstance.interactor = owner;
        List<BoardItem_Base> auxItems = new List<BoardItem_Base>();
        foreach (KeyValuePair<BoardItem_Base, int> kV in items)
        {
            auxItems.Add(kV.Key);
        }
        itemsCanvasInstance.SetItems(auxItems);
        ToggleItemsUI();
        /*
        itemsCanvasInstance.enabled = visible;
        itemsCanvasInstance.gameObject.SetActive(false);
        */
    }

    public virtual void Delete()
    {
        Destroy(itemsCanvasInstance.gameObject);
        ItemsCanvas.singleton = null; // Weirdddd.
        //itemsCanvasInstance = null;
    }

    #region Inventory Methods
    public void AddItem(BoardItem_Base item, int amount = 1)
    {
        if (!items.ContainsKey(item))
        {
            items.Add(item, amount);
        }
        else
        {
            items[item] += amount;
        }
    }

    public void UpdateItem(BoardItem_Base item, int amount)
    {
        if (!items.ContainsKey(item))
        {
            return;
        }

        if(amount == 0)
        {
            items.Remove(item);
            return;
        }

        items[item] = amount;
    }

    public bool HasItem(BoardItem_Base item)
    {
        return items.ContainsKey(item);
    }

    public void UseItem(BoardItem_Base item)
    {
        if (canUseItem && !isUsingItem)
        {
            BoardItem_Base itemInstance = Instantiate(item, transform.position + transform.forward * 1.5f + (transform.up * 2f), Quaternion.identity);
            itemInstance.owner = owner;
            ConsumeItem(item);
            StartUsingItem(itemInstance);
        }
    }

    private void ConsumeItem(BoardItem_Base item)
    {
        if (items.ContainsKey(item))
        {
            items[item]--;
            if (items[item] <= 0) items.Remove(item);
            canUseItem = false;
        }
        else
        {
            Debug.LogWarning("This inventory doesn't have this item.");
        }
    }
    #endregion

    #region Events
    public event Action onStartUsingItem;
    public void StartUsingItem(BoardItem_Base item)
    {
        visible = false;
        ToggleItemsUI();
        canUseItem = false;
        isUsingItem = true;
        owner.SetCanThrowDice(false);
        onStartUsingItem?.Invoke();
    }

    public event Action onEndUsingItem;
    public void EndUsingItem(BoardItem_Base item)
    {
        isUsingItem = false;
        canUseItem = false;
        owner.SetCanThrowDice(true);
        onEndUsingItem?.Invoke();
    }

    public event Action onCancelUsingItem;
    public void CancelUsingItem(BoardItem_Base item)
    {
        visible = true;
        ToggleItemsUI();
        isUsingItem = false;
        canUseItem = true;
        AddItem(item);
        owner.SetCanThrowDice(true);
        onCancelUsingItem?.Invoke();
    }
    #endregion
}
