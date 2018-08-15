using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhetuAI : MonoBehaviour {

    //Movement Variables
    public float fMaxSpeed = 10.0f;
    public float fSpeed;
    public float fMass = 0.175f;

    private Vector3 vecVelocity;
    private Vector3 vecDesVelocity;
    private Vector3 vecTar;


    //GameObjects
    public GameObject Player;

    private int iSeq = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        vecTar = Player.transform.position;
        vecTar.y = vecTar.y + 2.0f;

        transform.position = Vector3.MoveTowards(transform.position, vecTar, fMaxSpeed * Time.deltaTime);
		
	}
}
