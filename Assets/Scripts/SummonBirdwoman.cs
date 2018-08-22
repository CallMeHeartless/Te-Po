using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonBirdwoman : MonoBehaviour {

    public GameObject birdwoman;
    public AudioSource screech;
    bool hasbeenCalled = false;

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && !hasbeenCalled) {
            birdwoman.SetActive(true);
            birdwoman.transform.position = transform.position + new Vector3(0, 15, 0);
            Debug.Log(transform.position);
            Debug.Log(birdwoman.transform.position);
            RuruCallManager.WarningCall();
            screech.Play();
            hasbeenCalled = true;
        }
    }


}
