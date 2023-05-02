using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public bool Paused;
    public GameObject PauseText;
    // Start is called before the first frame update
    void Start()
    {
        Paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            Paused = !Paused;
        }

        if(Paused == true)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }

        PauseText.SetActive(Paused);
    }

    public void Resume()
    {
        Paused = false;
    }

    public void Menu()
    {
        SceneManager.LoadScene("StartUI");
    }

    public void Quit()
    {
        Application.Quit();
    }

    //https://gamedevbeginner.com/the-right-way-to-pause-the-game-in-unity/, https://gamedevbeginner.com/how-to-quit-the-game-in-unity/ and https://forum.unity.com/threads/show-hide-text-on-ui-via-script.317211/ used to help with code
}
