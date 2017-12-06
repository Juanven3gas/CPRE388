using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour {

    private PlayerProgress playerProgress;
    private playerSettings settings;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        LoadPlayerProgress();
        LoadPlayerPreferece();

        SceneManager.LoadScene("menu");
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

    public void SubmitNewDifficultySetting(int newDifficulty)
    {
        if(settings.difficulty != newDifficulty)
        {
            settings.difficulty = newDifficulty;
            SavePlayerSettings();
        }
    }

    public int GetHighestScore()
    {
        return playerProgress.score;
    }

    public string GetInitials()
    {
        return playerProgress.initials;
    }

    public int GetDifficulty()
    {
        return settings.difficulty;
    }

    private void SavePlayerProgress()
    {
        PlayerPrefs.SetInt("highscore1", playerProgress.score);
    }

    private void SavePlayerInitials()
    {
        PlayerPrefs.SetString("highscore1init", playerProgress.initials);
    }

    private void SavePlayerSettings()
    {
        PlayerPrefs.SetInt("difficulty", settings.difficulty);
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

    private void LoadPlayerPreferece()
    {
        settings = new playerSettings();

        if(PlayerPrefs.HasKey("difficulty"))
        {
            settings.difficulty = PlayerPrefs.GetInt("difficulty");
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
