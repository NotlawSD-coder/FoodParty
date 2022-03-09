using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ingredient", menuName = "Cooking Party/Recipe/Ingredient")]
public class Ingredient : ScriptableObject
{
    public new string name;

    public Texture2D icon;
    public GameObject modelPrefab;
}