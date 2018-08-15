using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhetuUIController : MonoBehaviour {

    public Vector3 offset;
    public GameObject Whetu;

	// Use this for initialization
	void Start () {
        Whetu = GameObject.Find("Whetu");
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Whetu.transform.position + offset;
	}
}
