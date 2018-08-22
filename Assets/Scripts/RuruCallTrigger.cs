using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuruCallTrigger : MonoBehaviour {

    public bool isWarning;
    private bool hasCalled = false;

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && !hasCalled) {
            if (isWarning) {
                RuruCallManager.WarningCall();
            } else {
                RuruCallManager.SafeCall();
            }

            hasCalled = true;
        }
    }

}
