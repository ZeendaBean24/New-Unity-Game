using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public Image utilitySlotImage;
    public Image gunSlotImage;
    public Image meleeSlotImage;
    public TextMeshProUGUI utilitySlotText;
    public TextMeshProUGUI gunSlotText;
    public TextMeshProUGUI meleeSlotText;
    public Image utilitySlotBorder;
    public Image gunSlotBorder;
    public Image meleeSlotBorder;

    void Update()
    {
        UpdateUI();
        HighlightActiveSlot();
    }

    void UpdateUI()
    {
        if (inventory.currentUtilityItem != null)
        {
            utilitySlotImage.sprite = inventory.currentUtilityItem.icon;
            utilitySlotText.text = inventory.currentUtilityItem.itemName;
        }

        if (inventory.currentGunItem != null)
        {
            gunSlotImage.sprite = inventory.currentGunItem.icon;
            gunSlotText.text = inventory.currentGunItem.itemName;
        }

        if (inventory.currentMeleeItem != null)
        {
            meleeSlotImage.sprite = inventory.currentMeleeItem.icon;
            meleeSlotText.text = inventory.currentMeleeItem.itemName;
        }
    }

    void HighlightActiveSlot()
    {
        gunSlotBorder.gameObject.SetActive(inventory.currentSlot == 1);
        meleeSlotBorder.gameObject.SetActive(inventory.currentSlot == 2);
        utilitySlotBorder.gameObject.SetActive(inventory.currentSlot == 3);
    }
}

