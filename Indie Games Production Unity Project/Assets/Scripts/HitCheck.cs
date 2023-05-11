using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheck : MonoBehaviour
{

    public float StartPointX;
    public float CurrentPointX;
    public bool NewTurn;

    public int PinHit;
    public GameObject Pin;
    public float DestroyTime;
    //public int Hits;
    
    // Start is called before the first frame update
    void Start()
    {
        StartPointX = gameObject.transform.position.x;
        //Grabs the position of the pin at the start of the game.
        PinHit = 0;
        //Ensures score has been reset on a new scene being loaded.
    }

    // Update is called once per frame
    void Update()
    {
        CurrentPointX = gameObject.transform.position.x;

        if(CurrentPointX != StartPointX) //Compared the pin's starting position to its current position and activates the code below if the values no longer match.
        {
            PinHit = 1; //Determines pin has been hit.
            DestroyTime = DestroyTime + Time.deltaTime;
            if (DestroyTime >= 1)
            {
                Destroy(gameObject);
            }
            //Deletes the pin.

            //Hits += 1;
        }

        
        /*NewTurn = GetComponent<Movement>().TurnIncrease;
        if (NewTurn == true)
        {
            Instantiate(Pin, StartPoint, transform.rotation);
        }*/
        //Unused code from before scene resets were used to respawn pins and reset current scores.
    }

    void TurnProcess()
    {
        Destroy(gameObject);
    }
    //Seemingly unused code meant to reset pins on a new turn beginning, was to be used alongside the above code to prevent pins spawning on top of still existing pins.
}
