﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Vector3 touchPos;
    private Rigidbody2D rb;
    private Vector3 dir;
    private float movementSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        // searches the objaect it's attached to for a rigibody2D
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // calls the TouchMovement function
        TouchMovement();
    }

    void TouchMovement()
    {
        // checks if the screen is beeing touched
        if (Input.touchCount > 0)
        {
            // sets the touch to a variable
            Touch touch = Input.GetTouch(0);
            // makes variable the position where te finger touched in worldspace
            touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            // makes the z axis of the touch possition 0
            touchPos.z = 0;
            // follows the position of the finger and changes its possition
            dir = (touchPos - transform.position);
            // gives the velocity to the direction of the touch, thus making the object follow your finger
            rb.velocity = new Vector2(dir.x, dir.y) * movementSpeed;

            // checks if you stopped touching the screen
            if (touch.phase == TouchPhase.Ended)
            {
                // sets the velocity of the object zero
                rb.velocity = Vector2.zero;
            }
        }
    }
}
