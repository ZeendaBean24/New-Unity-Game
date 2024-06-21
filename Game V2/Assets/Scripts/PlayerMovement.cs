using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D playerRB;
    CapsuleCollider2D playerCollider;
    Vector2 playerInputValue;
    Vector3 originalScale; // Store the original scale

    [SerializeField] float walkSpeed = 3f, sprintSpeed = 8f;

    // Sprinting stuff
    [SerializeField] float sprintTimer = 3f;
    float sprintMax = 3f;
    bool ableRun = true, running = false;
    [SerializeField] Slider staminBar;

    // Start is called before the first frame update
    void Start()
    {
        staminBar.value = sprintMax;
        playerRB = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<CapsuleCollider2D>();
        originalScale = transform.localScale; // Save the original scale
    }

    // Update is called once per frame
    void Update()
    {
        staminBar.value = sprintTimer;
        Run();
        FlipSprite();
        CheckRunStatus();
        changeSlot();
    }

    void OnMove(InputValue value)
    {
        playerInputValue = value.Get<Vector2>();
    }

    void Run()
    {
        // Sprint conditions
        if (Input.GetKeyDown(KeyCode.LeftShift) && ableRun)
        {
            walkSpeed = sprintSpeed;
            running = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            walkSpeed = 3f;
            ableRun = false;
            running = false;
        }

        Vector2 playerVector = new Vector2(playerInputValue.x * walkSpeed, playerInputValue.y * walkSpeed);
        playerRB.velocity = playerVector;
    }

    void FlipSprite()
    {
        bool playerMoving = Mathf.Abs(playerRB.velocity.x) > Mathf.Epsilon;

        if (playerMoving)
        {
            // Maintain the original scale while flipping the sprite
            transform.localScale = new Vector3(Mathf.Sign(playerRB.velocity.x) * originalScale.x, originalScale.y, originalScale.z);
        }
    }

    void CheckRunStatus()
    {
        if (running)
        {
            if (sprintTimer > 0)
            {
                sprintTimer -= Time.deltaTime;
            }
            if (sprintTimer <= 0)
            {
                ableRun = false;
                walkSpeed = 3f;
            }
        }
        if (!running)
        {
            if (sprintTimer <= sprintMax)
            {
                sprintTimer += Time.deltaTime;
            }
            else
            {
                ableRun = true;
            }
        }
    }

    void changeSlot()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Inventory.Instance.currentSlot = 1;
            Inventory.Instance.SwitchItem();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Inventory.Instance.currentSlot = 2;
            Inventory.Instance.SwitchItem();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Inventory.Instance.currentSlot = 3;
            Inventory.Instance.SwitchItem();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "UsableItem")
        {
            ItemController itemController = collision.GetComponent<ItemController>();
            Inventory.Instance.AddItem(itemController.gunItem, itemController.meleeItem, itemController.utilItem);
            Destroy(collision.gameObject);
        }
    }
}
