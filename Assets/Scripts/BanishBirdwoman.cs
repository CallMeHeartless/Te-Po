using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanishBirdwoman : MonoBehaviour {
    public GameObject birdwoman;
    public float riseSpeed = 25.0f;
    bool hasBeenBanished = false;
    bool isRising = false;

    void Update() {
        if (isRising) {
            birdwoman.transform.Translate(new Vector3(0, riseSpeed, 0) * Time.deltaTime);
        }

    }

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player") && !hasBeenBanished) {

            isRising = true;
            hasBeenBanished = true;
            StartCoroutine(DisableBirdwoman());
        }
    }

    IEnumerator DisableBirdwoman() {
        yield return new WaitForSeconds(3);
        birdwoman.SetActive(false);
        RuruCallManager.SafeCall();
        isRising = false;
    }
	
}
