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
        Paused = false; //Prevents pause function from being activated at start of game.
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            Paused = !Paused; //Toggles the pause function.
        }

        if(Paused == true)
        {
            Time.timeScale = 0f; //Stops scene entirely.
        }
        else
        {
            Time.timeScale = 1f; //Sets scene back to regular speed.
        }

        PauseText.SetActive(Paused); //Sets the pause text, and its attached menu, based on the pause bool.
    }

    public void Resume()
    {
        Paused = false; //Ends pause state upon the Resume button being activated.
    }

    public void Menu()
    {
        SceneManager.LoadScene("StartUI"); //Sets game back to its start screen.
    }

    public void Quit()
    {
        Application.Quit(); //Completely quits out of the game.
    }

    //https://gamedevbeginner.com/the-right-way-to-pause-the-game-in-unity/, https://gamedevbeginner.com/how-to-quit-the-game-in-unity/ and https://forum.unity.com/threads/show-hide-text-on-ui-via-script.317211/ used to help with code
}
