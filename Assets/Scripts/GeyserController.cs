using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeyserController : MonoBehaviour {

    public float geyserForce = 10.0f;
    public float period = 5.0f;
    public float gushDuration = 5.0f;
    public float height = 3.0f;

    private bool isGushing = false;
    private Transform geyserHeightMarker;

	// Use this for initialization
	void Start () {
        StartCoroutine(StartGushing());
        geyserHeightMarker = transform.Find("GeyserHeight");
        height = geyserHeightMarker.transform.position.y - transform.position.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        // Method 1
        if (isGushing) {
            RaycastHit hit;
            Physics.Raycast(transform.position, Vector3.up, out hit, height);
            Debug.DrawLine(transform.position, geyserHeightMarker.transform.position, Color.cyan);
            if (hit.collider != null) {
                //hit.transform.GetComponent<Rigidbody>().AddForce(Vector3.up * geyserForce * Time.fixedDeltaTime, ForceMode.VelocityChange);
                hit.rigidbody.velocity = new Vector3(hit.rigidbody.velocity.x, geyserForce, 0);
                if (hit.transform.CompareTag("Player")) {
                    PlayerController.Kill();
                }
            }
        }

    }



    // Set geyser to gush after elapsed time
    IEnumerator StartGushing() {
        yield return new WaitForSeconds(period);
        isGushing = true;
        StartCoroutine(StopGushing());
    }

    IEnumerator StopGushing() {
        yield return new WaitForSeconds(gushDuration);
        isGushing = false;
        StartCoroutine(StartGushing());
    }
}
