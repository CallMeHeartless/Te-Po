using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTrigger : MonoBehaviour {
    public GameObject tutorialUIText;
    public string tutorialText;

	// Use this for initialization
	void Start () {
              
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    // Enable UI text and display
    public void OnTriggerEnter(Collider other) {
        
        if (other.CompareTag("Player")) {
            // Display and enable text
            tutorialUIText.GetComponentInChildren<Text>().text = tutorialText;
            tutorialUIText.SetActive(true);
            Debug.Log("Hit");
        }
    }

    // Disable UI text
    void OnTriggerExit(Collider other) {
        
        if (other.CompareTag("Player")) {
            // Disable text
            tutorialUIText.SetActive(false);
        }
    }
}
