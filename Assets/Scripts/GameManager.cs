using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float moveSpeed = 2f;
    private int score = 0;
    private float CompareLimit = 0.9f;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }
    public void IncreaseSpeed()
    {
        //increase speed
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
            CompareLimit -= 0.5f;
            Mathf.Clamp(CompareLimit, 0.5f, 0.9f);
        }
    }

    public float GetCompareLimit()
    {
        return CompareLimit;
    }
}
