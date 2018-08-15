using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public Vector3 offset;
    public float xBuffer;
   // public float yBuffer;
    public float smoothspeed = 1.0f;

    private float cameraWidth;
    private float cameraHeight;
    private Vector3 playerDistance;

	// Use this for initialization
	void Start () {
        cameraHeight = Camera.main.orthographicSize * 2;
        cameraWidth = cameraHeight * Camera.main.aspect;


	}
	
	// Update is called once per frame
	void Update () {
        // Find a vector that relates the player to the center of the camera
        playerDistance = new Vector3(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y, 0);

        // If the player is a certain distance away, move the camera to follow them.
        if(playerDistance.magnitude > xBuffer) {
            transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z), smoothspeed * Time.deltaTime);
        }
	}

}
