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
        PinHit = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentPointX = gameObject.transform.position.x;

        if(CurrentPointX != StartPointX)
        {
            PinHit = 1;
            DestroyTime = DestroyTime + Time.deltaTime;
            if (DestroyTime >= 1)
            {
                Destroy(gameObject);
            }
            //Hits += 1;
        }

        
        /*NewTurn = GetComponent<Movement>().TurnIncrease;
        if (NewTurn == true)
        {
            Instantiate(Pin, StartPoint, transform.rotation);
        }*/
    }

    void TurnProcess()
    {
        Destroy(gameObject);

    }
}
