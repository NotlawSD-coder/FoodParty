using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardItem_Base : MonoBehaviour
{
    public BoardEntity owner;

    public new string name;

    [TextArea]
    public string description;

    public Sprite icon;
}
