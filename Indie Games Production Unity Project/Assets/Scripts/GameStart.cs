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
    }
    //Used to patch glitch where GetComponent would not work on static value.
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

    //Each of these load the next scene in the menu whilst assigning a static float to be called later on.

    public void Quit()
    {
        Application.Quit();
    }
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

    //These 3 assign a number of rounds to be used to determine the maximum number of rounds.

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
    //Loads the appropriate scenes based on the value given beforehand.
        

    //https://www.youtube.com/watch?v=zc8ac_qUXQY used for initial understanding of UI elements
}