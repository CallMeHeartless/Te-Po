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

    private Vector3[] vechover = new Vector3[2];
    private int iSeq = 0;
    public float fTime = 3.0f;
    private float fSwoop = 0.0f;

    private Vector3 vecPlayerPrev;
    private bool bKILL = false;
    public float fOffsetx1 = 5.0f;
    public float fOffsety1 = 5.0f;
    public float fOffsetx2 = 5.0f;
    public float fOffsety2 = 5.0f;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

        vechover[0] = Player.transform.position;
        vechover[0].x = vechover[0].x - fOffsetx1;
        vechover[0].y = vechover[0].y + fOffsety1;

        vechover[1] = Player.transform.position;
        vechover[1].x = vechover[1].x + fOffsetx2;
        vechover[1].y = vechover[1].y + fOffsety2;


        //rotate towards tar
        //find vec from Whetu to target
        vecDir = (Player.transform.position - transform.position).normalized;
        vecDir.y = 0;
        //create rotation
        quatLookRotation = Quaternion.LookRotation(vecDir);
        //rotate over time
        transform.rotation = Quaternion.Slerp(transform.rotation, quatLookRotation, fRotationSpeed * Time.deltaTime);
        // ugh
        


        //KILL!
        if (bKILL == true)
        {
            //KILL!
            transform.position = Vector3.MoveTowards(transform.position, vecPlayerPrev, fMaxSpeed * Time.deltaTime);
            if(transform.position == vecPlayerPrev)
            {
                if(fSwoop>= fTime)
                {
                    bKILL = false;
                    fSwoop = 0.0f;
                    iSeq = Random.Range(0, 2);
                }
                else
                {
                    fSwoop = fSwoop + Time.deltaTime;
                }
            }
        }
        else
        {
            //move towards hover targets
            transform.position = Vector3.MoveTowards(transform.position, vechover[iSeq], fMaxSpeed * Time.deltaTime);
            if (transform.position == vechover[iSeq])
            {
                if (fSwoop >= fTime)
                {
                    bKILL = true;
                    vecPlayerPrev = Player.transform.position;
                    fSwoop = 0.0f;
                }
                else
                {
                    fSwoop = fSwoop + Time.deltaTime;
                }
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerController.Kill();
        }
    }

}


