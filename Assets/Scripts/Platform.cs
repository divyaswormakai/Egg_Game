using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private int width;

    public float moveSpeed;
    public bool isMovingRight;

    void Start()
    {
        width = Screen.width;
        isMovingRight = Random.Range(0f, 1f) > 0.5 ? true : false;

        UpdateSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }

    public void MovePlatform()
    {
        Vector2 platformPos = transform.position;
        Vector3 posOnScreen = Camera.main.WorldToScreenPoint(platformPos);          //Give position in pixels wrt screen

        if (posOnScreen.x > width-100f || posOnScreen.x < 100f)
        {
            isMovingRight = !isMovingRight;
            FindObjectOfType<Egg>().ChangeStats();
        }

        if (isMovingRight)
        {
            platformPos.x += moveSpeed * Time.deltaTime;
        }
        else
        {
            platformPos.x -= moveSpeed * Time.deltaTime;
        }
        transform.position = platformPos;
    }

    public void UpdateSpeed()
    {
        moveSpeed = FindObjectOfType<GameManager>().GetSpeed();
    }
}
