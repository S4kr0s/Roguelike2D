using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item_", menuName = "Roguelike/ItemData")]
public class Item : ScriptableObject
{
    [Header("Item Data:")]
    public Sprite ItemSprite;
    public Vector2Int ItemSize = Vector2Int.one;

    [Space, Header("Placement Type")]
    public bool Corner = true;
    public bool NearWallUp = true;
    public bool NearWallDown = true;
    public bool NearWallRight = true;
    public bool NearWallLeft = true;
    public bool Inner = true;

    [Min(1)]
    public int PlacementQuantityMin = 1;
    [Min(1)]
    public int PlacementQuantityMax = 1;

    [Space, Header("Group Placement:")]
    public bool PlaceAsGroup = false;
    [Min(1)]
    public int GroupMinCount = 1;
    [Min(1)]
    public int GroupMaxCount = 1;
}
