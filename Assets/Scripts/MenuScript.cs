using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuScript : MonoBehaviour
{
    public TextMeshProUGUI toast;

    private float toastTimeout = 0f;

    void Update()
    {
        if (toastTimeout > 0f)
        {
            toastTimeout -= Time.deltaTime;
            if (toastTimeout <= 0.2f)
            {
                toast.gameObject.SetActive(false);
            }
        }
    }
    public void PlayBtn()
    {
        SceneManager.LoadScene("Main");
    }

    public void ExitBtn()
    {
        Application.Quit();
    }

    public void GoogleSignIn()
    {
        toastTimeout = 2f;
        toast.gameObject.SetActive(true);
    }
}
