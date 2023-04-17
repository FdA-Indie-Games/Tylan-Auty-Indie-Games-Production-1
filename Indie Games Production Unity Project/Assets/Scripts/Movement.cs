using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{

    public float Speed;
    public bool SpeedStop;
    //public GameObject Endcheck;
    public float Position;
    float EndPoint;
    float RightEnd = 22.5f;
    float LeftEnd = -22.5f;
    public GameObject ball;
    public bool HasFired;
    public GameObject FirePoint;
    public float CheckValue;
    public float Turn;
    public bool TurnIncrease;
    public GameObject[] Pin;
    public GameObject[] PinSpawn;
    public GameObject NewPin;
    public bool HasSpawned;
    //public GameObject[] AisleChecker;

    // Start is called before the first frame update
    void Start()
    {
        SpeedStop = false;
        EndPoint = RightEnd;
        HasFired = false;
        Speed = -6;
        Turn = 0;
        HasSpawned = true;
        Pin = GameObject.FindGameObjectsWithTag("Pin");
        PinSpawn = GameObject.FindGameObjectsWithTag("PinSpawn");
        //Pin = GameObject.FindGameObjectsWithTag("Pin");
        //PinSpawn = Pin.transform.position;
        //AisleChecker = GameObject.FindGameObjectsWithTag("AisleChecker");
    }

    // Update is called once per frame
    void Update()
    {
     Debug.Log(HasSpawned);   
        if (TurnIncrease == false)
        {
            TurnIncrease = true;
            //Pin.transform.position = PinSpawn;
            Turn = Turn + 1;
        }

        TurnProcess();
    }

    void TurnProcess()
    {
        if(SpeedStop == false & EndPoint == RightEnd)
        {
            transform.Translate(0,0,1 * Speed * Time.deltaTime);
        }
        if(SpeedStop == false & EndPoint == LeftEnd)
        {
             transform.Translate(0,0,-1 * Speed * Time.deltaTime);
        }
        if(SpeedStop == true)
        {
            transform.Translate(0,0,0 * Speed * Time.deltaTime);
        }

        Position = gameObject.transform.position.x;

        if (RightEnd == EndPoint & Position >= RightEnd)
        {
            SpeedStop = true;
            StartCoroutine(DirectionChange());
        }
        if (LeftEnd == EndPoint & Position <= LeftEnd)
        {
            PinSpawner();
            SpeedStop = true;
            StartCoroutine(Loop());
        }

        if (LeftEnd == EndPoint)
        {
            if ((HasFired == false) && (Input.GetButtonDown("Fire1")))
            {
                Instantiate(ball, FirePoint.transform.position, transform.rotation);
                HasFired = true;
            }
        }

        if (Input.GetButtonDown("Fire2"))
        {
            SceneManager.LoadScene("Game1");
        }

        if (CheckValue == -1)
        {
            Speed = -8;
        }

        if (CheckValue == 0)
        {
            Speed = -10;
        }

        if (CheckValue == 1)
        {
            Speed = -12;
        }
    }
    void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("AisleChecker"))
            {
                HasFired = false;
            }

            if (other.gameObject.CompareTag("Checkpoint"))
            {
                CheckValue = other.GetComponent<Checkpoints>().Value;
            }

            if (other.gameObject.CompareTag("StartCheckpoint"))
            {
                TurnIncrease = false;
            }
        }
    IEnumerator Loop()
    {
        yield return new WaitForSeconds(2);
        for (int i = 0; i < Pin.Length; i++)
        {
           Destroy(Pin[i]);
        }
        {
            if(HasSpawned == false)
            for (int i = 0; i < PinSpawn.Length; i++)
            {
            Instantiate(NewPin, PinSpawn[i].transform);
            }
            HasSpawned = true;
        }
        
        HasSpawned = true;
        SpeedStop = false;
        EndPoint = RightEnd;
        HasFired = false;
        Speed = -6;
        
        
        TurnProcess();
    }
    IEnumerator DirectionChange()
    {
        yield return new WaitForSeconds(2);
        SpeedStop = false;
        EndPoint = LeftEnd;
    }

    /*public void OnTriggerEnter(Collider Endcheck)
    {
        SpeedStop = true;
    }*/

    void PinSpawner()
    {
        if (HasSpawned != true)
        {
            HasSpawned = true;
            for (int i = 0; i < PinSpawn.Length; i++)
            {
                Instantiate(NewPin, PinSpawn[i].transform);
            }
            HasSpawned = true;
        }
    }
}
