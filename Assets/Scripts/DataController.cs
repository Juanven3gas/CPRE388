using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour {

    public ScoreData[] allScoreData;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);

        SceneManager.LoadScene("menu");
	}

    public ScoreData getCurrentScoreData()
    {
        return allScoreData[0];
    }

	// Update is called once per frame
	void Update () {
		
	}
}
