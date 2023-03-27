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
        SceneManager.LoadScene("Game1");
    }

    public void VsCpu()
    {
        SceneManager.LoadScene("Game3");
    }
}