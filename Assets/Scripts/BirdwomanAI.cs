using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdwomanAI : MonoBehaviour {

    public GameObject Player;
    public float fMaxSpeed = 20.0f;
    
    //rotation
    private Vector3 vecDir;
    private Quaternion quatLookRotation;
    public float fRotationSpeed = 10.0f;

    private Vector3[] vechover = new Vector3[5];
    private int iSeq = 0;
    public float fTime = 3.0f;
    private float fSwoop = 0.0f;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

        vechover[0] = Player.transform.position;
        vechover[0].x = vechover[0].x - 0.0f;
        vechover[0].y = vechover[0].y + 5.0f;

        vechover[1] = Player.transform.position;
        vechover[1].x = vechover[1].x - 10.0f;
        vechover[1].y = vechover[1].y + 0.0f;

        vechover[2] = Player.transform.position;
        vechover[2].x = vechover[2].x - 5.0f;
        vechover[2].y = vechover[2].y + 5.0f;

        vechover[3] = Player.transform.position;
        vechover[3].x = vechover[3].x + 5.0f;
        vechover[3].y = vechover[3].y + 5.0f;

        vechover[4] = Player.transform.position;
        vechover[4].x = vechover[4].x + 10.0f;
        vechover[4].y = vechover[4].y + 0.0f;

        //rotate towards tar
        //find vec from Whetu to target
        vecDir = (Player.transform.position - transform.position).normalized;
        //create rotation
        quatLookRotation = Quaternion.LookRotation(vecDir);
        //rotate over time
        transform.rotation = Quaternion.Slerp(transform.rotation, quatLookRotation, fRotationSpeed * Time.deltaTime);

        //move towards hover targets
        transform.position = Vector3.MoveTowards(transform.position, vechover[iSeq], fMaxSpeed * Time.deltaTime);

        //if hover target is reached
        if (transform.position == vechover[iSeq])
        {
            if(fSwoop >= fTime)
            {
                iSeq = Random.Range(0, 4);
                fSwoop = 0.0f;
            }
            else
            {
                fSwoop = fSwoop + Time.deltaTime;
            }
        }
    }

}
