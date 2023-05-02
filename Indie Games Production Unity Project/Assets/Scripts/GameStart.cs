using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
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
        SceneManager.LoadScene("Game2");
    }

    public void PartyMode()
    {
        SceneManager.LoadScene("Game4");
    }

    public void VsCpu()
    {
        SceneManager.LoadScene("Game1");
    }

    //https://www.youtube.com/watch?v=zc8ac_qUXQY used for initial understanding of UI elements
}