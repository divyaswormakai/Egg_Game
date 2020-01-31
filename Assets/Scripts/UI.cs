using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI scoreBoard;
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
        scoreBoard.SetText("Score:\n" + score.ToString());
    }
    
}
