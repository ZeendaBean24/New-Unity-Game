using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUseWeapon : MonoBehaviour
{

    [SerializeField] SpriteRenderer holdPosition;
    [SerializeField] Sprite temporaryRifle;

    private Vector2 mousePos;
    [SerializeField] Camera cam;
    [SerializeField] Rigidbody2D playerRB;

    [SerializeField] GameObject medBullet;

    // Start is called before the first frame update
    void Start()
    {
        holdPosition = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //temporary weapon thing
        if (Input.GetKeyDown(KeyCode.F))
        {
            holdPosition.transform.localScale = new Vector3(0.1f, 0.1f);
            holdPosition.sprite = temporaryRifle;
        }
        AimItem();
    }

    void AimItem()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 currentPlayerPosition = holdPosition.transform.position;
        Vector2 mousePosDif = mousePos - currentPlayerPosition;
        float lookAngle = Mathf.Atan2(mousePosDif.y, mousePosDif.x) * Mathf.Rad2Deg;
        if (playerRB.transform.localScale.x < 0)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, lookAngle + 180);
        }
        if (playerRB.transform.localScale.x > 0)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, lookAngle);
        }
    }

    void UseItemInHand()
    {
        //temporary just for the bullets thing before we add scirptable objects
        if (Input.GetMouseButtonDown(0))
        {

        }
    }
}
