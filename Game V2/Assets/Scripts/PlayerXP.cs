using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerXP : MonoBehaviour
{
    public int currentXP = 0;
    public TextMeshProUGUI xpText; // Reference to the TextMeshProUGUI component

    void Start()
    {
        UpdateXPUI();
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
}

