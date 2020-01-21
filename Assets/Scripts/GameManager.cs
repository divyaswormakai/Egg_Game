using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float moveSpeed = 0.5f;

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

}
