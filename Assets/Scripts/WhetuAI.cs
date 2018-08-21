using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhetuAI : MonoBehaviour {

    //Movement Variables
    //Left to right
    public float fMaxSpeed = 10.0f;
    public float fSpeed;
    public float fMass = 0.175f;
    public float fPlayerRadius = 10.0f;
    private float fPlayerDistance;
    private float fPlatformDistance;

    //magic platform
    private bool bPlatform = false;

    //rotation
    private Vector3 vecDir;
    private Quaternion quatLookRotation;
    public float fRotationSpeed = 10.0f;


    private Vector3 vecVelocity;
    private Vector3 vecDesVelocity;
    private Vector3 vecTar;

    private Vector3[] vechover = new Vector3 [8];
    public float fTime = 3.0f;
    private float fSwoop = 0.0f;

    //GameObjects
    public GameObject Player;
    public GameObject[] Platforms;
    public GameObject MagicPlatform;

    private int iSeq = 0;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        
        //Distance to player
        fPlayerDistance = (Player.transform.position - transform.position).magnitude;

        //Target movement over player
        vecTar = Player.transform.position;
        vecTar.y = vecTar.y + 3.0f;

        for(int i = 0; i < Platforms.Length; i++)
        {
            //Distance to platform objects
            fPlatformDistance = (Platforms[i].transform.position - Player.transform.position).magnitude;

            //if close enough
            if(fPlatformDistance < fPlayerRadius)
            {
                //set platform as target
                bPlatform = true;
                vecTar = Platforms[i].transform.position;
                vecTar.y = vecTar.y + 5.0f;
            }

            //if far away
            if (fPlatformDistance > fPlayerRadius)
            {
                //disable platform targeting
                bPlatform = false;
                //disable magic platform
                MagicPlatform.SetActive(false);
            }
        }

        //if platform is target
        if(bPlatform == true)
        {
            //rotate towards tar
            //find vec from Whetu to target
            vecDir = (vecTar - transform.position).normalized;
            //create rotation
            quatLookRotation = Quaternion.LookRotation(vecDir);
            //rotate over time
            transform.rotation = Quaternion.Slerp(transform.rotation, quatLookRotation, fRotationSpeed * Time.deltaTime);

            //move towards platform target
            transform.position = Vector3.MoveTowards(transform.position, vecTar, (fMaxSpeed * 2) * Time.deltaTime);
            //if arrived
            if(transform.position == vecTar)
            {
                //make magic platform
                MagicPlatform.SetActive(true);
            }

            
        }

        //if platform isn't target
        if(bPlatform == false)
        {
            //if player is further away
            if (fPlayerDistance > fPlayerRadius)
            {
                //rotate towards tar
                //find vec from Whetu to target
                vecDir = (vecTar - transform.position).normalized;
                //create rotation
                quatLookRotation = Quaternion.LookRotation(vecDir);
                //rotate over time
                transform.rotation = Quaternion.Slerp(transform.rotation, quatLookRotation, fRotationSpeed * Time.deltaTime);
  
                //move towards player
                transform.position = Vector3.MoveTowards(transform.position, vecTar, fMaxSpeed * Time.deltaTime);
            }
            else
            {
                //if player is close
                //hover around player
                vechover[0] = Player.transform.position;
                vechover[0].x = vechover[0].x - 0.0f;
                vechover[0].y = vechover[0].y + 3.0f;

                vechover[1] = Player.transform.position;
                vechover[1].x = vechover[1].x - 1.5f;
                vechover[1].y = vechover[1].y + 3.5f;

                vechover[2] = Player.transform.position;
                vechover[2].x = vechover[2].x - 3.0f;
                vechover[2].y = vechover[2].y + 4.0f;

                vechover[3] = Player.transform.position;
                vechover[3].x = vechover[3].x - 1.5f;
                vechover[3].y = vechover[3].y + 4.5f;

                vechover[4] = Player.transform.position;
                vechover[4].x = vechover[4].x - 0.0f;
                vechover[4].y = vechover[4].y + 5.0f;

                vechover[5] = Player.transform.position;
                vechover[5].x = vechover[5].x + 1.5f;
                vechover[5].y = vechover[5].y + 4.5f;

                vechover[6] = Player.transform.position;
                vechover[6].x = vechover[6].x + 3.0f;
                vechover[6].y = vechover[6].y + 4.0f;

                vechover[7] = Player.transform.position;
                vechover[7].x = vechover[7].x + 1.5f;
                vechover[7].y = vechover[7].y + 3.5f;

                //rotate towards tar
                //find vec from Whetu to target
                vecDir = (vechover[iSeq] - transform.position).normalized;
                //create rotation
                if (vecDir != Vector3.zero) {
                    quatLookRotation = Quaternion.LookRotation(vecDir);
                }
               
                //rotate over time
                transform.rotation = Quaternion.Slerp(transform.rotation, quatLookRotation, fRotationSpeed * Time.deltaTime);

                //move towards hover targets
                transform.position = Vector3.MoveTowards(transform.position, vechover[iSeq], fMaxSpeed * Time.deltaTime);

                //if hover target is reached
                if (transform.position == vechover[iSeq])
                {
                    if(fSwoop>= fTime)
                    {
                        iSeq = Random.Range(0, 7);
                        fSwoop = 0.0f;
                    }
                    else
                    {
                        fSwoop = fSwoop + Time.deltaTime;
                    }
                    
                }
            }
        }
	}
}
