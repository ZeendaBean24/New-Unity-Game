using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D playerRB;
    CapsuleCollider2D playerCollider;
    Vector2 playerInputValue;

    [SerializeField] float runSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipSprite();
    }

    void OnMove(InputValue value)
    {
        playerInputValue = value.Get<Vector2>();
    }

    void Run()
    {
        Vector2 playerVector = new Vector2(playerInputValue.x*runSpeed, playerInputValue.y*runSpeed);
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
}
