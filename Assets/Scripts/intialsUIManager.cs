using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class intialsUIManager : MonoBehaviour {

    public InputField initialsInputField;

    private DataController dataController;
	// Use this for initialization
	void Start () {
        dataController = FindObjectOfType<DataController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EnterInitials()
    {
        string initals = initialsInputField.text;
        dataController.submitNewPlayerInitials(initals);
        SceneManager.LoadScene("score");
    }
}
