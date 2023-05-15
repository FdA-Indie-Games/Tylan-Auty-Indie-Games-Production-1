using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPURandom : MonoBehaviour
{
    Vector3 Displacement;
   
    // Start is called before the first frame update
    void Start()
    {
        Displacement.x = Random.Range(-1.25f, 1.25f);

        transform.Translate(Displacement);
    }
    //Randomly moves the CPU Firing areas in order to randomise when the CPU fires into the aisle.
}
