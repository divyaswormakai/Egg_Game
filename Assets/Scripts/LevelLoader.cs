using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;
    public float transitiontTime = 1f;


    void Update()
    {
        
    }

    public void LoadGame()
    {
        LoadLevel(SceneManager.GetActiveScene().buildIndex+1);
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("end");

        yield return new WaitForSeconds(transitiontTime);

        SceneManager.LoadScene(levelIndex);
    }
}
