using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public float thrust = 10f;
    public float torque = 5f;
    public float liftCoefficient = 2f;
    public float dragCoefficient = 0.5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Calculate angle of attack (in radians)
        float angleOfAttack = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        
        // Get current velocity
        Vector2 velocity = rb.velocity;
        float speed = velocity.magnitude;

        // Calculate lift force
        float lift = liftCoefficient * speed * speed * Mathf.Sin(angleOfAttack);
        Vector2 liftDirection = new Vector2(-Mathf.Sin(angleOfAttack), Mathf.Cos(angleOfAttack));
        rb.AddForce(liftDirection * lift);

        // Calculate drag force
        float drag = dragCoefficient * speed * speed;
        rb.AddForce(-velocity.normalized * drag);

        // Handle input
        if(Input.GetKey(KeyCode.D)) {
            rb.AddRelativeForce(Vector2.right * thrust);
        }
        if(Input.GetKey(KeyCode.W)) {
            rb.AddTorque(torque);
        } else if (Input.GetKey(KeyCode.S)) {
            rb.AddTorque(-torque);
        }
        if(Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(0);
        }
    }
}