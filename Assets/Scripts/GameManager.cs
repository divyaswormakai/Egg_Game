using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float moveSpeed = 2f;
    private int score = 0;

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
    }
}
