using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public static Inventory Instance;

    public UtilityItem currentUtilityItem;
    public GunItem currentGunItem;
    public MeleeItem currentMeleeItem;

    [SerializeField] GameObject holdPosition;

    PlayerUseWeapon playerUseWeapon;

    [SerializeField] MeleeItem emptyFists;
    [SerializeField] UtilityItem noUtilState;
    [SerializeField] GunItem unarmedState;


    public int currentSlot = 1; // 1: Utility, 2: Gun, 3: Melee

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        holdPosition = GameObject.Find("HoldPosition");
        playerUseWeapon = holdPosition.GetComponent<PlayerUseWeapon>();
    }

    void Update()
    {
        //moved changing slot controls to player movement
        if(currentMeleeItem == null)
        {
            currentMeleeItem = emptyFists;
        }
        if (currentGunItem==null)
        {
            currentGunItem = unarmedState;
        }
        if (currentUtilityItem == null) { 
            currentUtilityItem = noUtilState;
        }
    }

    public void SwitchItem()
    {
        // Implement the logic to switch items based on the current slot
        playerUseWeapon.holdSpriteRend.transform.localScale = new Vector3(0.2f, 0.2f, 1);
        switch (currentSlot)
        {
            case 1:
                playerUseWeapon.holdSpriteRend.sprite = currentGunItem.icon;
                break;
            case 2:
                playerUseWeapon.holdSpriteRend.sprite = currentMeleeItem.icon;
                break;
            case 3:
                playerUseWeapon.holdSpriteRend.sprite = currentUtilityItem.icon;
                break;
        }
    }

    public void AddItem(GunItem gunItem, MeleeItem meleeItem, UtilityItem utilItem)
    {
        if (gunItem != null)
        {
            currentGunItem = gunItem;
        }
        else if (meleeItem != null) { 
            currentMeleeItem = meleeItem;
        }
        else if (utilItem != null)
        {
            currentUtilityItem=utilItem;
        }
    }
}


