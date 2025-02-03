using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Contorl2 : MonoBehaviour
{
    private Rigidbody2D rb;

    public GameObject render;

    public float thrust = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)) {
            rb.AddRelativeForce(Vector2.up * thrust, ForceMode2D.Impulse);
            // render.GetComponent<TrailRenderer>().enabled = true;
        } else {
            // render.GetComponent<TrailRenderer>().enabled = false;
        }

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.MoveRotation(angle - 90);
        if(Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(0);
        }
    }
}
