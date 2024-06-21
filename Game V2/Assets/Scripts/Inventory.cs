using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public UtilityItem currentUtilityItem;
    public GunItem currentGunItem;
    public MeleeItem currentMeleeItem;

    public int currentSlot = 1; // 1: Utility, 2: Gun, 3: Melee

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentSlot = 1;
            SwitchItem();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentSlot = 2;
            SwitchItem();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentSlot = 3;
            SwitchItem();
        }
    }

    void SwitchItem()
    {
        // Implement the logic to switch items based on the current slot
        switch (currentSlot)
        {
            case 1:
                Debug.Log("Switched to Utility Item: " + currentUtilityItem.itemName);
                break;
            case 2:
                Debug.Log("Switched to Gun Item: " + currentGunItem.itemName);
                break;
            case 3:
                Debug.Log("Switched to Melee Item: " + currentMeleeItem.itemName);
                break;
        }
    }
}


