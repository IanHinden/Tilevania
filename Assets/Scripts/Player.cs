using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private MyControl myControl;
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
        float movementInput = myControl.Player.Movement.ReadValue<float>();
        Vector3 currentPosition = transform.position;
        currentPosition.x += movementInput * speed * Time.deltaTime;
        transform.position = currentPosition;
    }
}
