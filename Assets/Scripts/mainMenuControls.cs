using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuControls : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void startButton()
    {
        Debug.Log("Start was pressed!!!");
        SceneManager.LoadScene("Main");
    }

    public void quitButton()
    {
        Application.Quit();
        Debug.Log("Quit button was pressed!!");
    }
}
