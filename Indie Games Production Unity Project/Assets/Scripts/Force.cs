using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour
{

    Rigidbody Rigid;
    public float force;

    float gravity = -9.81f;
    // Start is called before the first frame update
    void Start()
    {
        Rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Rigid.velocity = new Vector3(0,0,-1) * force * gravity;
    }
}
