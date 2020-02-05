using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float moveSpeed = 2f;
    private int score = 0;
    private float CompareLimit = 0.2f;

    public bool isPaused = false;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("Pause");
            isPaused = !isPaused;
            if (isPaused)
            {
                FindObjectOfType<UI>().PauseScreen();
            }
            else
            {
                FindObjectOfType<UI>().UnPauseScreen();
            }
        }
    }

    public float GetSpeed()
    {
        return moveSpeed;
    }

    public int GetScore()
    {
        return score;
    }

    public void IncScore(int incAmt)
    {
        score += incAmt;
        if (score % 10 == 0)
        {
            CompareLimit += 0.5f;                   //Increase probabilty of moving platform
            Mathf.Clamp(CompareLimit, 0.2f, 0.8f);

            moveSpeed += 0.1f;
            Mathf.Clamp(moveSpeed, 2f, 4f);
        }
    }

    public float GetCompareLimit()
    {
        return CompareLimit;
    }
}
