
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
    public static float Turn;
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

        //Sets all the values to the defaults.
    }

    // Update is called once per frame
    void Update()
    { 
        if (TurnIncrease == false)
        {
            TurnIncrease = true;
            //Pin.transform.position = PinSpawn;
            Turn = Turn + 1;
        }
        //Detects the end of a turn and adds the turn number up.

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
        //Both of these have the cannon travel in the direction towards the endpoint based on where the endpoint is currently assigned.

        if(SpeedStop == true)
        {
            transform.Translate(0,0,0 * Speed * Time.deltaTime);
        }
        //Stops the cannon when game requires cannon to stop.

        Position = gameObject.transform.position.x;

        if (RightEnd == EndPoint & Position >= RightEnd)
        {
            SpeedStop = true;
            StartCoroutine(DirectionChange());
        }
        //Detects when the cannon has reached the right end and has the cannon prepare to move back to the left end.

        if (LeftEnd == EndPoint & Position <= LeftEnd)
        {
            //PinSpawner();
            SpeedStop = true;
            StartCoroutine(Loop());
        }
        //Stops the cannon at the left end, loads a different coroutine.

        if (LeftEnd == EndPoint)
        {
            if ((HasFired == false) && (SceneManager.GetActiveScene() == (SceneManager.GetSceneByName ("Game1")) && (Input.GetButtonDown("Fire1"))))
            {
                Instantiate(ball, FirePoint.transform.position, transform.rotation);
                HasFired = true;
            }
            if ((HasFired == false) && (SceneManager.GetActiveScene() == (SceneManager.GetSceneByName ("Game2")) && (Input.GetButtonDown("Fire1"))))
            {
                Instantiate(ball, FirePoint.transform.position, transform.rotation);
                HasFired = true;
            }
            if ((HasFired == false) && (SceneManager.GetActiveScene() == (SceneManager.GetSceneByName ("Game4")) && (Input.GetButtonDown("Fire1"))))
            {
                Instantiate(ball, FirePoint.transform.position, transform.rotation);
                HasFired = true;
            }
            if ((HasFired == false) && (SceneManager.GetActiveScene() == (SceneManager.GetSceneByName ("Game5")) && (Input.GetButtonDown("Fire1"))))
            {
                Instantiate(ball, FirePoint.transform.position, transform.rotation);
                HasFired = true;
            }
            //Determines the scenes and circumstances in which the player is allowed to fire, such as if the player has already fired within an aisle.

        }

        /*if (Input.GetButtonDown("Fire2"))
        {
            SceneManager.LoadScene("Game1");
        }*/
        //Old code used to manually restart the scene

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
        //Sets a speed for the cannon to travel in based on the checkpoint value detected
    }
    void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("AisleChecker"))
            {
                HasFired = false;
            }
            //Resets the player's ability to fire upon entering a new aisle.

            if (other.gameObject.CompareTag("Checkpoint"))
            {
                CheckValue = other.GetComponent<Checkpoints>().Value;
            }
            //Finds the checkpoints value in order to alter the cannons speed.

            if (other.gameObject.CompareTag("StartCheckpoint"))
            {
                TurnIncrease = false;
            }
            //Sets turn increase to false upon reaching the start checkpoint.

            if ((other.gameObject.CompareTag("CPUFire")) && (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game3")) && (LeftEnd == EndPoint))
            {
                Instantiate(ball, FirePoint.transform.position, transform.rotation);
                HasFired = true;
            }
            //Allows the CPU to fire in their appropriate scenes.
        }
    IEnumerator Loop()
        {
            yield return new WaitForSeconds (2);
            if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("Game3"))
            {
                SceneManager.LoadScene ("Game1");
            }
            if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("Game1"))
            {
                SceneManager.LoadScene ("Game3");
            }
            if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("Game2"))
            {
                SceneManager.LoadScene ("Game2");
            }
            if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("Game4"))
            {
                SceneManager.LoadScene ("Game5");
            }
            if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("Game5"))
            {
                SceneManager.LoadScene ("Game4");
            }
            //Loads the next scene based on what scene is currently loaded.

        /*yield return new WaitForSeconds(2);
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
        //Was intended to destroy any remaining pins and respawn them during a new turn starting, replaced with scene reset.
        
        HasSpawned = true;
        SpeedStop = false;
        EndPoint = RightEnd;
        HasFired = false;
        Speed = -6;
        
        
        TurnProcess();*/
    }
    IEnumerator DirectionChange()
    {
        yield return new WaitForSeconds(2);
        SpeedStop = false;
        EndPoint = LeftEnd;
    }
    //Changes the direction of the Endpoint after 2 seconds.


    /*public void OnTriggerEnter(Collider Endcheck)
    {
        SpeedStop = true;
    }*/

    /*void PinSpawner()
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
        //Old code from before scene resetting was used to reload the game.
    }*/

    //Unity API used to assist with SceneManager code
}
