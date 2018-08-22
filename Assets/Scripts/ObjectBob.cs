using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBob : MonoBehaviour {

    public float amplitude;
    public float frequency = 3.0f;
    public GameObject model;
    private float timer = 0.0f;

	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        model.transform.Translate(new Vector3(0, amplitude * Mathf.Sin(frequency * timer), 0));
	}
}
