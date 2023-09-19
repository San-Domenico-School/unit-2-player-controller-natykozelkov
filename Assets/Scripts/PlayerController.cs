using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/**********************************************
 * Component of the Vehicle, takes in user
 * imput to move and turn the vehicle
 * 
 * Natalie Kozelkova
 * September 12, 2023
 *********************************************/

public class NewBehaviourScript : MonoBehaviour
{
    private float speed;            // holds the forward of the vehicle
    private float turnSpeed;        // holds the turn speed of the vehicle
    private float verticalInput;    // gets a value [-1, 1] from user key press up/down or W/S
    private float horizontalInput;  // ets a value [-1, 1] from user key press left/right or A/S

    private Rigidbody rb;           // points to vehicle rigidbody component

    // Initializes speed before the first frame update
    void Start()
    {
        speed = 1200.0f;
        turnSpeed = 30.0f;
        rb = GetComponent<Rigidbody>();
     
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.forward * speed * verticalInput);
        transform.Rotate(Vector3.up * turnSpeed * horizontalInput * Time.deltaTime);
        Scorekeeper.Instance.AddToScore(verticalInput);

    }

    // Called from PlayerActionInput when user presses WASD or arrow keys
    private void OnMove(InputValue input)
    {
        verticalInput = input.Get<Vector2>().y;
        horizontalInput = input.Get<Vector2>().x;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Scorekeeper.Instance.SubtractFromScore();
        }
    }

}
