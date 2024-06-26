using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUseWeapon : MonoBehaviour
{
    [SerializeField] public SpriteRenderer holdSpriteRend;
    [SerializeField] Transform aimIndicator; // Reference to the aim indicator

    private Vector2 mousePos;
    [SerializeField] Camera cam;
    [SerializeField] Rigidbody2D playerRB;
    [SerializeField] float aimIndicatorDistance = 0.75f;

    [SerializeField] GameObject smallBullet;

    GameObject bulletShot;

    void Start()
    {
        holdSpriteRend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
/*        // Temporary weapon assignment
        if (Input.GetKeyDown(KeyCode.F))
        {
            holdSpriteRend.transform.localScale = new Vector3(0.1f, 0.1f, 1);
            holdSpriteRend.sprite = temporaryRifle;
        }*/
        AimItem();
        usingItem();
    }

    void AimItem()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 currentPlayerPosition = playerRB.position;
        Vector2 direction = mousePos - currentPlayerPosition;
        float lookAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the aim indicator around the player
        aimIndicator.position = currentPlayerPosition + direction.normalized * aimIndicatorDistance;
        aimIndicator.rotation = Quaternion.Euler(0, 0, lookAngle - 90);
    }

    void usingItem()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Inventory.Instance.currentSlot == 1)
            {
                if (Inventory.Instance.currentGunItem.ammoType == "small")
                {
                    bulletShot=smallBullet;
                    Inventory.Instance.currentGunItem.shootGun(bulletShot, playerRB, aimIndicator);
                }
            }
        }
    }
}
