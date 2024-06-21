using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUseWeapon : MonoBehaviour
{
    [SerializeField] SpriteRenderer holdPosition;
    [SerializeField] Sprite temporaryRifle;
    [SerializeField] Transform aimIndicator; // Reference to the aim indicator

    private Vector2 mousePos;
    [SerializeField] Camera cam;
    [SerializeField] Rigidbody2D playerRB;

    [SerializeField] GameObject medBullet;

    void Start()
    {
        holdPosition = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Temporary weapon assignment
        if (Input.GetKeyDown(KeyCode.F))
        {
            holdPosition.transform.localScale = new Vector3(0.1f, 0.1f, 1);
            holdPosition.sprite = temporaryRifle;
        }
        AimItem();
    }

    void AimItem()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 currentPlayerPosition = playerRB.position;
        Vector2 direction = mousePos - currentPlayerPosition;
        float lookAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the aim indicator around the player
        aimIndicator.position = currentPlayerPosition + direction.normalized * 1.5f;
        aimIndicator.rotation = Quaternion.Euler(0, 0, lookAngle - 90);

        if (direction.x < 0)
        {
            holdPosition.transform.localScale = new Vector3(-0.1f, 0.1f, 1);
        }
        else
        {
            holdPosition.transform.localScale = new Vector3(0.1f, 0.1f, 1);
        }
    }

    void UseItemInHand()
    {
        // Temporary code for shooting bullets
        if (Input.GetMouseButtonDown(0))
        {
            // Implement shooting logic here
        }
    }
}
