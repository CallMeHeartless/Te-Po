using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTrigger : MonoBehaviour {
    public GameObject whetuUIText;
    public string tutorialText;

	// Use this for initialization
	void Start () {
        //whetuUIText = GameObject.Find("WhetuUI/Text").GetComponent<GameObject>();

        Debug.Log(whetuUIText.name);
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Enable UI text and display
    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            // Display and enable text
            whetuUIText.GetComponent<Text>().text = tutorialText;
            whetuUIText.SetActive(true);
        }
    }

    // Disable UI text
    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            // Disable text
            whetuUIText.SetActive(false);
        }
    }
}
