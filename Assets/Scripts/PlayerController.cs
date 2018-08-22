using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    private static PlayerController instance;
    private Rigidbody rb;
    private Animator anim;
    private float movementDirection;
    private bool canJump = true;
    private Quaternion targetRotation;

    public float speed = 5.0f;
    public float turnSpeed = 100.0f;
    public float jumpForce = 100.0f;
    public float gravityMultiplier = 2.5f;
    public AudioSource playerRunning;



	// Use this for initialization
	void Start () {
        instance = this;
        rb = this.GetComponent<Rigidbody>();
        anim = this.GetComponentInChildren<Animator>();
       // playerRunning = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

    }

    void FixedUpdate() {

        // Character movement (horizontal axis)
        movementDirection = Input.GetAxisRaw("Horizontal");
        if(movementDirection != 0.0f) {
            rb.velocity = new Vector3(movementDirection * speed, rb.velocity.y, 0);
            targetRotation = Quaternion.LookRotation(Vector3.forward * movementDirection, Vector3.up);
            anim.SetTrigger("Walk");
            anim.ResetTrigger("Idle");
            // Sound
            if (!playerRunning.isPlaying && rb.velocity.y == 0.0f) {
                playerRunning.Play();
            }
            
        } else {
            // Stop player's horizontal movement
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
            // Animation
            anim.ResetTrigger("Walk");
            anim.SetTrigger("Idle");
            // Sound
            if(playerRunning.isPlaying) {
                playerRunning.Stop();
            }
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
        // Jump animation
        anim.SetTrigger("Jump");
        // Sound
        playerRunning.Stop();
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
        // Reload the current level
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
