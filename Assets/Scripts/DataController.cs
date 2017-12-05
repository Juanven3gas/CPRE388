using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour {

    public ScoreData[] allScoreData;
    private PlayerProgress playerProgress;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        LoadPlayerProgress();

        SceneManager.LoadScene("menu");
	}

    public ScoreData getCurrentScoreData()
    {
        return allScoreData[0];
    }

    public void SubmitNewPlayerScore(int newScore)
    {
        if(newScore > playerProgress.score)
        {
            playerProgress.score = newScore;
            SavePlayerProgress();
        }
    }

    public int GetHighestScore()
    {
        return playerProgress.score;
    }

    private void SavePlayerProgress()
    {
        PlayerPrefs.SetInt("highscore1", playerProgress.score);
    }

    private void LoadPlayerProgress()
    {
        playerProgress = new PlayerProgress();

        if(PlayerPrefs.HasKey("highscore1"))
        {
            playerProgress.score = PlayerPrefs.GetInt("highscore1");
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
