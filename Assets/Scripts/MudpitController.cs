using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudpitController : MonoBehaviour {

    public float playerXSlow = 1.5f;
    public float playerJumpSlow = 1.1f;
    public float killTime = 3.0f;
    private bool hasPlayer = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            // Slow player movement
            PlayerController.Slow(playerXSlow, playerJumpSlow);
            hasPlayer = true;
            // Kill player if they are there for too long
            StartCoroutine(KillPlayer());
        }
    }

    // Speed player up
    public void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            PlayerController.EndSlow(playerXSlow, playerJumpSlow);
            hasPlayer = false;
        }
    }

    // Kills the player if they remain within the bounds of the mudpit for too long
    IEnumerator KillPlayer() {
        yield return new WaitForSeconds(killTime);
        if (hasPlayer) {
            PlayerController.Kill();
        }
    }
}
