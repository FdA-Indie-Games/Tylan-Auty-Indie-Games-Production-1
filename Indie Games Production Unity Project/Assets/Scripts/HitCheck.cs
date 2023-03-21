using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheck : MonoBehaviour
{

    public float StartPoint;
    public float CurrentPoint;
    public float DespawnTime;

    public int PinHit;
    //public int Hits;
    
    // Start is called before the first frame update
    void Start()
    {
        StartPoint = gameObject.transform.position.x;
        PinHit = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentPoint = gameObject.transform.position.x;

        if(CurrentPoint != StartPoint)
        {
            Debug.Log("Hit");
            PinHit = 1;
            DespawnTime = DespawnTime + Time.deltaTime;

            if(DespawnTime >= 2)
            {
                Destroy(gameObject);
            }

            //Hits += 1;
        }
    }
}
