using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearController : MonoBehaviour {

    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            PlayerController.Kill();
        }
    }
}
