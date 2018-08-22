using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTrigger : MonoBehaviour {
    public GameObject whetuUIText;
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
            whetuUIText.GetComponentInChildren<Text>().text = tutorialText;
            whetuUIText.SetActive(true);
            Debug.Log("Hit");
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
