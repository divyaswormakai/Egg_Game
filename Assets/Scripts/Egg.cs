using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    private bool isMovingRight;
    private bool isInAir = false;

    public float moveSpeed =1f;

    GameObject currPlatform;
    // Start is called before the first frame update
    void Start()
    {
        UpdateSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isInAir)
        {
            print("Go up");
            GetComponent<Rigidbody2D>().AddForce(transform.up*8f,ForceMode2D.Impulse);
            isInAir = true;
        }
        MoveEgg(isMovingRight, moveSpeed);
    }

    public void MoveEgg(bool isMovingRight,float moveSpeed)
    {
        Vector2 pos = transform.position;
        if (isMovingRight)
        {
            pos.x += moveSpeed*Time.deltaTime;
        }
        else
        {
            pos.x -= moveSpeed*Time.deltaTime;
        }
        transform.position = pos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.collider.name);
        currPlatform = collision.collider.gameObject;
        ChangeStats();
        isInAir = false;
    }

    public void ChangeStats()
    {
        isMovingRight = currPlatform.GetComponentInChildren<Platform>().isMovingRight;
        print("Is moving right: " + isMovingRight);
    }

    public void UpdateSpeed()
    {
        moveSpeed = FindObjectOfType<GameManager>().GetSpeed();
    }
}
