using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private MyControl myControl;
    private float movementInput;
    [SerializeField] private float speed = 4f;

    private void Awake()
    {
        myControl = new MyControl();
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
        movementInput = myControl.Player.Movement.ReadValue<float>();
        Vector3 currentPosition = transform.position;
        currentPosition.x += movementInput * speed * Time.deltaTime;
        transform.position = currentPosition;
        FlipSprite();
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
