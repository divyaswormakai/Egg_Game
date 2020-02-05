using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public GameObject[] platforms;
    public GameObject cameraFollowObject;

    public void PlacePlatform(int currPlat)
    {
        //Move platform
        MovePlatform(currPlat);

        //Relocate the lowest platform
        int toPlacePlatformIndex = (currPlat + 2) % 5;
        Vector3 toPlacePosition = platforms[currPlat].transform.position;
        toPlacePosition.y += 9;
        toPlacePosition.x = Random.Range(-3f, 3f);
        platforms[toPlacePlatformIndex].transform.position = toPlacePosition;
        platforms[toPlacePlatformIndex].GetComponentInChildren<Platform>().SetStats();

        //Reposition the camera
        Vector3 objPos = cameraFollowObject.transform.position;
        objPos.y += 4.5f;
        cameraFollowObject.transform.position = objPos;

        //If concurrent platform moving in same direction then stop next platform
        if(platforms[currPlat].GetComponentInChildren<Platform>().toMove && platforms[(currPlat + 1) % 5].GetComponentInChildren<Platform>().toMove)
        {
            if (platforms[currPlat].GetComponentInChildren<Platform>().isMovingRight == platforms[(currPlat + 1) % 5].GetComponentInChildren<Platform>().isMovingRight)
            {
                print("Same movement direction");
                platforms[(currPlat + 1) % 5].GetComponentInChildren<Platform>().toMove = false;
            }
        }
    }

    //After egg jumps on platform move the platform
    private void MovePlatform(int currPlat)
    {
        if (!platforms[(currPlat + 1) % 5].GetComponentInChildren<Platform>().toMove)
        {
            platforms[currPlat].GetComponentInChildren<Platform>().toMove = true;
        }
    }
}
