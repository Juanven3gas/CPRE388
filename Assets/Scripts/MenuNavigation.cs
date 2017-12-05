using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuNavigation : MonoBehaviour {

    private DataController dataController;
    public Text highscoreText;

    private void Start()
    {
        dataController = FindObjectOfType<DataController>();
        setScoreText();
    }

    private void setScoreText()
    {
        highscoreText.text = "First Place: " + dataController.GetHighestScore().ToString();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
