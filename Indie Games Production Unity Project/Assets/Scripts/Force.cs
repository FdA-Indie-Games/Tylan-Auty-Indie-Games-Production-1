using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour
{

    Rigidbody Rigid;
    public float force;
    float time;
    float gravity = -9.81f;
    void Start()
    {
        Rigid = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Rigid.velocity = new Vector3(0,0,-1) * force * gravity;

        //Allows the bowling balls being fired to go towards the pins, taking force and gravity into consideration.

        time = time + Time.deltaTime;

        if (time > 3)
        {
            Destroy(gameObject);
        }

        //Destroys the game object after 3 seconds have concluded.
    }
}
