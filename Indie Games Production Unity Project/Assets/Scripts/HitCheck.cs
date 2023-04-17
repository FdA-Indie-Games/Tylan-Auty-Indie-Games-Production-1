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
            Debug.Log("Hit");
            PinHit = 1;
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
