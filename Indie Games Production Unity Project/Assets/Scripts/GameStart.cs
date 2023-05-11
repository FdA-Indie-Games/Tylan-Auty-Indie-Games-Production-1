using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public static float GameMode;
    public static float RoundTotal;
    public float RoundTotal2;
    // Start is called before the first frame update
    void Start()
    {
        RoundTotal2 = RoundTotal;
        //Workaround for glitch where static float would not work on GetComponent used on Score.cs.
    }
    public void PressStart()
    {
        SceneManager.LoadScene("StartUIGame");
    }

    public void PracticeMode()
    {
        //SceneManager.LoadScene("Game2");
        GameMode = 1;
        SceneManager.LoadScene("RoundSelect");
    }

    public void PartyMode()
    {
        //SceneManager.LoadScene("Game4");
        GameMode = 2;
        SceneManager.LoadScene("RoundSelect");
    }

    public void VsCpu()
    {
        //SceneManager.LoadScene("Game1");
        GameMode = 3;
        SceneManager.LoadScene("RoundSelect");
    }

    public void Back()
    {
        SceneManager.LoadScene("StartUIGame");
    }

    public void Quit()
    {
        Application.Quit();
    }

    //Each of these are simple UI functions that activate their voids upon a button being used in-game.
    public void FiveRounds()
    {
        RoundTotal = 5;
    }

    public void TenRounds()
    {
        RoundTotal = 10;
    }

    public void TwentyRounds()
    {
        RoundTotal = 20;
    }

    public void Unlimited()
    {
        RoundTotal = 4192;
    }

    //Each of these set a certain number of rounds to be played, is the screen given after the player selects their game mode of choice.

    public void LoadGame()
    {
        if (GameMode == 1)
            {
                SceneManager.LoadScene("Game2");
            }
            if (GameMode == 2)
            {
                SceneManager.LoadScene("Game4");
            }
            if (GameMode == 3)
            {
                SceneManager.LoadScene("Game1");
            }
    }
    //Takes the previously given GameMode value and translates it into one of the 3 game modes.
        

    //https://www.youtube.com/watch?v=zc8ac_qUXQY used to assist with initial void systems.
}