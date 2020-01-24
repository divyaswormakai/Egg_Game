using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject[] platforms;
    public GameObject cameraFollowObject;

    public void PlacePlatform(int currPlat)
    {
        int toPlacePlatformIndex = (currPlat + 2) % 5;
        Vector3 toPlacePosition = platforms[currPlat].transform.position;
        toPlacePosition.y += 9;
        toPlacePosition.x = Random.Range(0f, 1.7f);
        platforms[toPlacePlatformIndex].transform.position = toPlacePosition;
        platforms[toPlacePlatformIndex].GetComponentInChildren<Platform>().SetStats();
         
        CheckAlternateMovement(currPlat);
        print("curr:" + currPlat);
        //Reposition the camera
        Vector3 objPos = cameraFollowObject.transform.position;
        objPos.y += 4.5f;
        cameraFollowObject.transform.position = objPos;
    }

    private void CheckAlternateMovement(int currPlat)
    {
        if (!platforms[currPlat].GetComponentInChildren<Platform>().toMove)
        {
            int nextPlat = (currPlat + 1) % 5;
            platforms[nextPlat].GetComponentInChildren<Platform>().toMove = true;
        }
    }

}
