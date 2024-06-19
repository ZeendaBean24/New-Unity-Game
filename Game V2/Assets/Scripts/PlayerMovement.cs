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

    [SerializeField] float walkSpeed = 3f, sprintSpeed=8f;

    //sprinting stuff
    [SerializeField] float sprintTimer=3f;
    float sprintMax = 3f;
    bool ableRun = true, running = false;
    [SerializeField] Slider staminBar;

    // Start is called before the first frame update
    void Start()
    {
        staminBar.value = sprintMax;
        playerRB = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        staminBar.value=sprintTimer;
        Run();
        FlipSprite();
        CheckRunStatus();
    }

    void OnMove(InputValue value)
    {
        playerInputValue = value.Get<Vector2>();
    }

    void Run()
    {

        //sprint conditions
        if (Input.GetKeyDown(KeyCode.LeftShift)&&ableRun)
        {
            walkSpeed=sprintSpeed;
            running= true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            walkSpeed=3f;
            ableRun = false;
            running=false;
        }

        Vector2 playerVector = new Vector2(playerInputValue.x*walkSpeed, playerInputValue.y*walkSpeed);
        playerRB.velocity=playerVector;
    }

    void FlipSprite()
    {

        bool playerMoving=Mathf.Abs(playerRB.velocity.x)>Mathf.Epsilon;

        if (playerMoving)
        {
            transform.localScale = new Vector2(Mathf.Sign(playerRB.velocity.x), 1f);
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
}
