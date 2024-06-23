using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerXP : MonoBehaviour
{
    public int currentXP = 0;
    public TextMeshProUGUI xpText; 
    public GameObject door;
    public Button unlockButton; 

    private void Start()
    {
        UpdateXPUI();
        unlockButton.onClick.AddListener(UnlockPassage);
    }

    public void AddXP(int amount)
    {
        currentXP += amount;
        UpdateXPUI();
    }

    void UpdateXPUI()
    {
        if (xpText != null)
        {
            xpText.text = "XP: " + currentXP;
        }
    }

    void UnlockPassage()
    {
        if (currentXP >= 200)
        {
            currentXP -= 200;
            UpdateXPUI();
            Destroy(door); // Remove the door to unlock the passage
        }
    }
}

