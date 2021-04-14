using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private MyControl myControl;
    private float movementInput;
    private float jumpInput;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpSpeed = 5f;

    bool isAlive = true;

    Animator myAnimator;

    private void Awake()
    {
        myControl = new MyControl();
        myAnimator = GetComponent<Animator>();
        myControl.Player.Jump.performed += _ => Jump(); 
    }

    private void OnEnable()
    {
        myControl.Enable();
    }

    private void OnDisable()
    {
        myControl.Disable();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        Run();
        FlipSprite();
    }

    private void Run()
    {
        movementInput = myControl.Player.Movement.ReadValue<float>();
        Vector3 currentPosition = transform.position;
        currentPosition.x += movementInput * speed * Time.deltaTime;
        transform.position = currentPosition;

        bool playerIsMoving = movementInput != 0;
        myAnimator.SetBool("Running", playerIsMoving);
    }

    private void Jump()
    {
        if (!GetComponent<Collider2D>().IsTouchingLayers(LayerMask.GetMask("Ground"))) { return;  }
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);
    }

    private bool IsGrounded()
    {
        return true;
    }

    private void FlipSprite()
    {
        if(movementInput == -1)
        {
            transform.localScale = new Vector2(-1, 1);
        } else if(movementInput == 1)
        {
            transform.localScale = new Vector2(1, 1);
        }
    }
}
