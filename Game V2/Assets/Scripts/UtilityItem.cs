using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Utility Item", menuName = "Inventory/Utility Item")]
public class UtilityItem : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public int damage;
    public float cooldown;
}

