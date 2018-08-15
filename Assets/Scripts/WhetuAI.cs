using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhetuAI : MonoBehaviour {

    //Movement Variables
    public float fMaxSpeed = 10.0f;
    public float fSpeed;
    public float fMass = 0.175f;
    public float fPlayerRadius = 10.0f;
    private float fPlayerDistance;

    private Vector3 vecVelocity;
    private Vector3 vecDesVelocity;
    private Vector3 vecTar;

    private Vector3[] vechover = new Vector3 [2];

    //GameObjects
    public GameObject Player;

    private int iSeq = 0;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        

        fPlayerDistance = (Player.transform.position - transform.position).magnitude;

        vecTar = Player.transform.position;
        vecTar.y = vecTar.y + 2.0f;

        if(fPlayerDistance > fPlayerRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, vecTar, fMaxSpeed * Time.deltaTime);
        }
        else
        {
            vechover[0] = Player.transform.position;
            vechover[0].x = vechover[0].x - 3.0f;
            vechover[0].y = vechover[0].y + 3.0f;

            vechover[1] = Player.transform.position;
            vechover[1].x = vechover[1].x + 3.0f;
            vechover[1].y = vechover[1].y + 3.0f;

            transform.position = Vector3.MoveTowards(transform.position, vechover[iSeq], fMaxSpeed * Time.deltaTime);

            if (transform.position == vechover[iSeq])
            {
                iSeq++;
                if(iSeq > 1)
                {
                    iSeq = 0;
                }
            }
        }
		
	}
}
