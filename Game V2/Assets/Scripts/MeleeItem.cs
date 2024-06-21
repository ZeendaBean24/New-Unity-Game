using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Melee Item", menuName = "Inventory/Melee Item")]
public class MeleeItem : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public int damage;
    public float attackSpeed;
}

