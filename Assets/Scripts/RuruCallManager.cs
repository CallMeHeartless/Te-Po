using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuruCallManager : MonoBehaviour {
    static RuruCallManager instance;
    public AudioSource safeCall;
    public AudioSource warningCall;

	// Use this for initialization
	void Start () {
        instance = this;
	}

    public static void SafeCall() {
        instance.safeCall.Play();
    }

    public static void WarningCall() {
        instance.warningCall.Play();
    }
}
