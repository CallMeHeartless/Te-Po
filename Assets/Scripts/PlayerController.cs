﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private static PlayerController instance;
    private Rigidbody rb;
    private Vector3 movementDirection;
    private bool canJump = true;

    public float speed = 5.0f;
    public float jumpForce = 100.0f;
    public float gravityMultiplier = 2.5f;



	// Use this for initialization
	void Start () {
        instance = this;
        rb = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.DrawRay(transform.position, -Vector3.up * 1f, Color.yellow);
	}

    void FixedUpdate() {

        // Character movement (horizontal axis)
        movementDirection.x = Input.GetAxisRaw("Horizontal");
        if(Input.GetAxis("Horizontal") != 0.0f) {
            rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, rb.velocity.y, 0);
        } else {
            // Stop player's horizontal movement
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }

        // Accelerate player if falling
        if(rb.velocity.y < 0 ) {
            rb.AddForce(Vector3.down * gravityMultiplier, ForceMode.Force);
        }
      
        // Jump if grounded
        if(Input.GetButton("Jump") && CanJump()) {
            Jump();
        }
    }

    // Checks if the player can jump (is it grounded?)
    bool CanJump() {
        RaycastHit hit;
        Physics.Raycast(transform.position, Vector3.down, out hit, 1);
        return hit.collider != null;
    }

    // Makes the player jump upwards
    void Jump() {
        rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.VelocityChange);
    }

    // Slow the player (when in mud pit)
    public static void Slow(float xRate, float jumpRate) {
        instance.speed /= xRate;
        instance.jumpForce /= jumpRate;
    }

    public static void EndSlow(float xRate, float jumpRate) {
        instance.speed *= xRate;
        instance.jumpForce *= jumpRate;
    }

    public static void Kill() {
        // Currently resets the player
        instance.transform.position = new Vector3(2, 2, 0);
    }
}
