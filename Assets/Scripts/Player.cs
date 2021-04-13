using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private MyControl myControl;
    private float movementInput;

    [SerializeField] private float speed = 5f;

    bool isAlive = true;

    Animator myAnimator;

    private void Awake()
    {
        myControl = new MyControl();
        myAnimator = GetComponent<Animator>();
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
