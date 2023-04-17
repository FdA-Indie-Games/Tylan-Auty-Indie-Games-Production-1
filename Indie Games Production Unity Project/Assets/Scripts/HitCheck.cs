using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheck : MonoBehaviour
{

    public Vector3 StartPoint;
    public Vector3 CurrentPoint;
    public bool NewTurn;

    public int PinHit;
    public GameObject Pin;
    //public int Hits;
    
    // Start is called before the first frame update
    void Start()
    {
        StartPoint = gameObject.transform.position;
        PinHit = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentPoint = gameObject.transform.position;

        if(CurrentPoint != StartPoint)
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
}
