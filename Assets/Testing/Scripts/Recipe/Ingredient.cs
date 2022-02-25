using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : ScriptableObject
{
    public new string name;
    public string description;
    public Texture2D icon;
    public GameObject modelPrefab;
}