using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun Item", menuName = "Inventory/Gun Item")]
public class GunItem : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public int damage;
    public int ammo;
    public float fireRate;
}

