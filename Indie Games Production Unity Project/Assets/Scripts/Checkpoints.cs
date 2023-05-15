using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    // Start is called before the first frame update
    public float Variable;
    public GameObject[] Checkpoint;
    public float Value;
    void Start()
    {
        Checkpoint = GameObject.FindGameObjectsWithTag("Checkpoint");
        for (int i = 0; i < Checkpoint.Length; i++)
        {
            Variable = Random.Range (0,3f);

            if (Variable <= 3 && Variable >= 2)
            {
                Value = 1;
            } 

            if (Variable <= 2 && Variable >= 1)
            {
                Value = 0;
            } 

            if (Variable <= 1 && Variable >= 0)
            {
                Value = -1;
            } 
        //Code here creates a random value for each checkpoint in the game, and then simplifies the value to one of 3 numbers.
        }
    }
}
//Code primarily based on code used on programming project.
