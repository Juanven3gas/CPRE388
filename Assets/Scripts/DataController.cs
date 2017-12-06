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

    public void submitNewPlayerInitials(string initals)
    {
        playerProgress.initials = initals;
        SavePlayerInitials();
    }

    public int GetHighestScore()
    {
        return playerProgress.score;
    }

    public string GetInitials()
    {
        return playerProgress.initials;
    }

    private void SavePlayerProgress()
    {
        PlayerPrefs.SetInt("highscore1", playerProgress.score);
    }

    private void SavePlayerInitials()
    {
        PlayerPrefs.SetString("highscore1init", playerProgress.initials);
    }

    private void LoadPlayerProgress()
    {
        playerProgress = new PlayerProgress();

        if(PlayerPrefs.HasKey("highscore1"))
        {
            playerProgress.score = PlayerPrefs.GetInt("highscore1");
        }

        if(PlayerPrefs.HasKey("highscore1init"))
        {
            playerProgress.initials = PlayerPrefs.GetString("highscore1init");
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
