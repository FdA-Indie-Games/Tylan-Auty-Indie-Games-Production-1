using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public static int Points;
    public Text UIPoints;
    public GameObject[] Pins;
    public static int Total1;
    public static int Total2;
    public Text UITotal1;
    public Text UITotal2;
    public static int Turn;
    public static int Round = 1;
    public Text UIRound;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Turn);
        //HitCheck PinHit = GetComponent<HitCheck>();
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("Game1"))
        {
            Total2 = Total2 + Points;
            Turn += 1;
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("Game2"))
        {
            Total1 = Total1 + Points;
            Turn += 1;
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("Game3"))
        {
            Total1 = Total1 + Points;
            Turn += 1;
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("Game4"))
        {
            Total2 = Total2 + Points;
            Turn += 1;
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("Game5"))
        {
            Total1 = Total1 + Points;
            Turn += 1;
        }

        if (Turn == 3)
        {
            Turn = 1;
            Round += 1;
        }
        Points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Pins = GameObject.FindGameObjectsWithTag ("Pin");
        Points = 80 - Pins.Length;
        //Points = GetComponent<HitCheck>().PinHit;

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("StartUIGame"))
        {
            Total1 = 0;
            Total2 = 0;
            Points = 0;
            Round = 1;
            Turn = 0;
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("Game1"))
        {
            UIPoints.text = "Hits: " + Points.ToString();
            UITotal1.text = "P1 Total: " + Total1.ToString();
            UITotal2.text = "CPU Total: " + Total2.ToString();
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("Game3"))
        {
            UIPoints.text = "Hits: " + Points.ToString();
            UITotal1.text = "P1 Total: " + Total1.ToString();
            UITotal2.text = "CPU Total: " + Total2.ToString();
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("Game2"))
        {
            UIPoints.text = "Hits: " + Points.ToString();
            UITotal1.text = "Total: " + Total1.ToString();
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("Game4"))
        {
            UIPoints.text = "Hits: " + Points.ToString();
            UITotal1.text = "P1 Total: " + Total1.ToString();
            UITotal2.text = "P2 Total: " + Total2.ToString();
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("Game5"))
        {
            UIPoints.text = "Hits: " + Points.ToString();
            UITotal1.text = "P1 Total: " + Total1.ToString();
            UITotal2.text = "P2 Total: " + Total2.ToString();
        }

        UIRound.text = "Round " + Round.ToString();
    }
}
