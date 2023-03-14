using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float Speed;
    public bool SpeedStop;
    public GameObject Endcheck;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SpeedStop == false)
        {
            transform.Translate(0,0,1 * Speed * Time.deltaTime);
        }
        if(SpeedStop == true)
        {
            transform.Translate(0,0,0 * Speed * Time.deltaTime);
        }
    }

    public void OnTriggerEnter(Collider Endcheck)
    {
        SpeedStop = true;
    }
}
