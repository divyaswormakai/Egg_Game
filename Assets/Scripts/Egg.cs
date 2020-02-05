using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Egg : MonoBehaviour
{
    private bool isInAir = false;
    private GameObject currPlatform;
    private float jumpPosX;
    
    public float force = 9.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isInAir)
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up*force,ForceMode2D.Impulse);           //Jump
            isInAir = true;
            GetComponent<AudioSource>().Play();
            jumpPosX = GetComponent<Rigidbody2D>().transform.position.x;                            //Get and set jump position in X axis at the time of jumping
        }
        if (isInAir)                                                                                //To make the egg stay in constant x-axis while jumping
        {
            GetComponent<Rigidbody2D>().transform.position = new Vector2(jumpPosX, GetComponent<Rigidbody2D>().transform.position.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Check if collision hit the lower border
        print(collision.collider.name);
        if (collision.collider.name == "Border")
        {
            print("Die");
            FindObjectOfType<UI>().GameOverScreen();
        }
        else
        {
            if (GetComponent<Rigidbody2D>().velocity.y <= 0f)
            {                                               //If fallingthen only check
                if (currPlatform != null && currPlatform.name != collision.collider.name)                   //If it falls on another platform then check
                {
                    FindObjectOfType<PlatformController>().PlacePlatform(Int32.Parse(collision.collider.name));        //Spawn Platform to up
                    FindObjectOfType<GameManager>().IncScore(1);                                                    //Increase score
                    FindObjectOfType<UI>().SetScore();                                                              //Set score on UI ScoreBoard
                }
                currPlatform = collision.collider.gameObject;
                isInAir = false;
                transform.parent = collision.transform;             //set position of egg wrt to the current platform            
            }
        }
    }

}
