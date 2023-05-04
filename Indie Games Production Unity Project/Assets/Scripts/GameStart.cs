using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public static float GameMode;
    public static float RoundTotal;
    // Start is called before the first frame update
    void Start()
    {
  
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
        else
        {
            SceneManager.LoadScene("Game1");
        }
    }

    //https://www.youtube.com/watch?v=zc8ac_qUXQY used for initial understanding of UI elements
}