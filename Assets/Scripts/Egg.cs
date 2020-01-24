using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Egg : MonoBehaviour
{
    private bool isInAir = false;
    private GameObject currPlatform;

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
            GetComponent<Rigidbody2D>().AddForce(transform.up*force,ForceMode2D.Impulse);
            isInAir = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(GetComponent<Rigidbody2D>().velocity.y <= 0f){                                               //If fallingthen only check
            if (currPlatform != null && currPlatform.name != collision.collider.name)                   //If it falls on another platform then check
            {
                FindObjectOfType<PlatformSpawner>().PlacePlatform(Int32.Parse(collision.collider.name));
            }
            currPlatform = collision.collider.gameObject;
            isInAir = false;
            transform.parent = collision.transform;
        }
    }

}
