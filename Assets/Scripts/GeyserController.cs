using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeyserController : MonoBehaviour {

    public float geyserForce = 10.0f;
    public float period = 5.0f;
    public float gushDuration = 5.0f;
    public float height = 3.0f;

    private float timer = 0.0f;
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
            Debug.DrawRay(transform.position, Vector3.up, Color.cyan, height);
            if (hit.collider != null) {
                hit.transform.GetComponent<Rigidbody>().AddForce(Vector3.up * geyserForce * Time.fixedDeltaTime, ForceMode.VelocityChange);
                if (hit.transform.CompareTag("Player")) {
                    //PlayerController.Kill();
                }
            }
        }

    }

    //void OnTriggerStay(Collider other) {
    //    if (isGushing) {
    //        other.GetComponent<Rigidbody>().AddForce(geyserForce * Vector3.up, ForceMode.VelocityChange);
    //    }
    //}

    void Gush(Collider collider) {
        if (collider.CompareTag("Player")) {
            
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
