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
    
    // Start is called before the first frame update
    void Start()
    {
        //HitCheck PinHit = GetComponent<HitCheck>();
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("Game3"))
        {
            Total1 = Total1 + Points;
        }
        else
        {
            Total2 = Total2 + Points;
        }
        Points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Pins = GameObject.FindGameObjectsWithTag ("Pin");
        Points = 80 - Pins.Length;
        //Points = GetComponent<HitCheck>().PinHit;
        UIPoints.text = "Hits: " + Points.ToString();
        UITotal1.text = "P1 Total: " + Total1.ToString();
        UITotal2.text = "CPU Total: " + Total2.ToString();
    }
}
