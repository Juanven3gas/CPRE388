using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingUIManager : MonoBehaviour {

    private DataController dataController;
    public Text difficultyText;
    private int currentDifficulty = 1;
    private string difficultyTextSetting = "Easy";

	// Use this for initialization
	void Start () {

        dataController = FindObjectOfType<DataController>();
        currentDifficulty = dataController.GetDifficulty();

        if(currentDifficulty == 1)
        {
            difficultyTextSetting = "Easy";
        }
        else if(currentDifficulty == 2)
        {
            difficultyTextSetting = "Medium";
        }
        else
        {
            difficultyTextSetting = "Hard";
        }

        setDifficultyText();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void changeDifficulty(int difficulty)
    {
        switch(difficulty)
        {
            case 1:
                currentDifficulty = difficulty;
                difficultyTextSetting = "Easy";
                setDifficultyText();
                break;
            case 2:
                currentDifficulty = difficulty;
                difficultyTextSetting = "Medium";
                setDifficultyText();
                break;
            case 3:
                currentDifficulty = difficulty;
                difficultyTextSetting = "Hard";
                setDifficultyText();
                break;
            default:
                currentDifficulty = 1;
                difficultyTextSetting = "Easy";
                setDifficultyText();
                break;
        }
    }

    public void MainMenu()
    {
        dataController.SubmitNewDifficultySetting(currentDifficulty);
        SceneManager.LoadScene("menu");
    }

    private void setDifficultyText()
    {
        difficultyText.text = "Difficulty: " + difficultyTextSetting;
    }
}
