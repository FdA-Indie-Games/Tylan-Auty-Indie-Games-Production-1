using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int Points;
    public Text UIPoints;
    public GameObject[] Pins;
    
    // Start is called before the first frame update
    void Start()
    {
        //HitCheck PinHit = GetComponent<HitCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        Pins = GameObject.FindGameObjectsWithTag ("Pin");
        Points = 80 - Pins.Length;
        //Points = GetComponent<HitCheck>().PinHit;
        UIPoints.text = Points.ToString();
    }
}
