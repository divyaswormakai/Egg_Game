using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI scoreBoard,finalScore;
    public Canvas pauseCanvas;
    public Canvas gameOverCanvas;

    GameManager gameManager;



    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void SetScore()
    {
        int score = gameManager.GetScore();
        scoreBoard.SetText("Points:\n" + score.ToString());
    }

    public void PauseScreen()
    {
        scoreBoard.gameObject.SetActive(false);
        pauseCanvas.gameObject.SetActive(true);
    }
    
    public void UnPauseScreen()
    {
        scoreBoard.gameObject.SetActive(true);
        pauseCanvas.gameObject.SetActive(false);
        FindObjectOfType<GameManager>().isPaused = false;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Main");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GameOverScreen()
    {
        finalScore.SetText("Score:\n" + gameManager.GetScore());
        gameOverCanvas.gameObject.SetActive(true);
        FindObjectOfType<GameManager>().isPaused = false;
    }


}
