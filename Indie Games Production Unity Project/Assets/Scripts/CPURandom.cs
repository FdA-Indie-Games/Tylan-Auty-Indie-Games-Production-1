using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPURandom : MonoBehaviour
{
    Vector3 Displacement;
    void Start()
    {
        Displacement.x = Random.Range(-1.25f, 1.25f);

        transform.Translate(Displacement);
        //This code is connected to the CPU Firing positions, which on the editor have been placed on the checkpoints.  This code will displace these firing points, emulating a computer player.
    }
}
