
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
    void Start()
    {
        SpeedStop = false;
        EndPoint = RightEnd;
        HasFired = false;
        Speed = -6;
        Turn = 0;
        HasSpawned = true;
        Pin = GameObject.FindGameObjectsWithTag("Pin");
        PinSpawn = GameObject.FindGameObjectsWithTag("PinSpawn"); //Unused variable initially used to reset pin positions before scene reseting was used.

        //Code as a whole resets the value to default for the start of each scene.


        //PinSpawn = Pin.transform.position;
        //AisleChecker = GameObject.FindGameObjectsWithTag("AisleChecker");
    }

    // Update is called once per frame
    void Update()
    { 
        if (TurnIncrease == false)
        {
            TurnIncrease = true; //Resets the TurnIncrease immediately to prevent Turn being counted multiple times.

            //Pin.transform.position = PinSpawn; //Was meant to place pins back in spawn position prior to scene reseting being used.
            Turn = Turn + 1;
        }

        TurnProcess(); //Begins the process of the cannon moving down its pathway.
    }

    void TurnProcess()
    {
        if(SpeedStop == false & EndPoint == RightEnd)
        {
            transform.Translate(0,0,1 * Speed * Time.deltaTime);
        }
        //Travels the cannon down across the right if code detects its end destination is the RightEnd.
        if(SpeedStop == false & EndPoint == LeftEnd)
        {
             transform.Translate(0,0,-1 * Speed * Time.deltaTime);
        }
        //Swaps the direction around if the LeftEnd is found to be the end destination.
        if(SpeedStop == true)
        {
            transform.Translate(0,0,0 * Speed * Time.deltaTime);
        }
        //Stops movement entirely, used when cannon reaches its end point.

        Position = gameObject.transform.position.x; //Keeps track of the cannons position on the X axis.

        if (RightEnd == EndPoint & Position >= RightEnd) //>= used over = or == to prevent cannon going slightly over the EndPoint position and continuing to move endlessly.
        {
            SpeedStop = true; //Stops the cannon in place.
            StartCoroutine(DirectionChange()); //Begins a timed coroutine for the turning process.
        }
        if (LeftEnd == EndPoint & Position <= LeftEnd)
        {
            //PinSpawner();
            SpeedStop = true;
            StartCoroutine(Loop()); //Peforms different task when the cannon and reached the left endpoint.
        }

        if (LeftEnd == EndPoint) //Prevents player firing before cannon has completed its initial path.
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
            //HasFired value used to prevent player from firing multiple times per aisle.
            //Game will check current scene to assure this is a scene where the player is allowed to fire, preventing player firing in scenes designed for CPU.

        }

        /*if (Input.GetButtonDown("Fire2"))
        {
            SceneManager.LoadScene("Game1");
        }*/
        //Old code from alpha versions of game to allow for quick reseting of the game.

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
        //Each of these alter the cannon's speed based on the Checkpoint's randomised values.
    }
    void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("AisleChecker"))
            {
                HasFired = false;
            }
            //Returns player's ability to fire upon the cannon moving out of the aisle the player has already fired in.

            if (other.gameObject.CompareTag("Checkpoint"))
            {
                CheckValue = other.GetComponent<Checkpoints>().Value;
            }
            //Reads the checkpoint's assigned value and copies it onto a local variable.

            if (other.gameObject.CompareTag("StartCheckpoint"))
            {
                TurnIncrease = false;
            }
            //determines original position being reached.

            if ((other.gameObject.CompareTag("CPUFire")) && (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game3")) && (LeftEnd == EndPoint))
            { 
                Instantiate(ball, FirePoint.transform.position, transform.rotation);
                HasFired = true;
            }
            //Code determines that when a CPUFire point has been reached, if the scene is a CPU player scene, and if the end point has been moved to the left end, the CPU may fire.
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
            //These scenes are used for VS CPU Mode, code detects what scene is currently being used and swaps to the other appropriate game.
            if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("Game2"))
            {
                SceneManager.LoadScene ("Game2");
            }
            //Scene is used for Practise Mode, simply reloads the current scene.
            if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("Game4"))
            {
                SceneManager.LoadScene ("Game5");
            }
            if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("Game5"))
            {
                SceneManager.LoadScene ("Game4");
            }
            //Scenes used for Party Mode, swaps between the scenes in the fashion as the VS CPU scenes.

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
        //Old code intended to respawn pins prior to scene resets being used.
        
        HasSpawned = true;
        SpeedStop = false;
        EndPoint = RightEnd;
        HasFired = false;
        Speed = -6;
        //Values to be reset as in Void Start since Start would not end up being called again.
        
        TurnProcess();*/
    }
    IEnumerator DirectionChange()
    {
        yield return new WaitForSeconds(2);
        SpeedStop = false;
        EndPoint = LeftEnd; //Moves Cannon's destination to opposite end of the path.
    }

    /*public void OnTriggerEnter(Collider Endcheck)
    {
        SpeedStop = true; //Old code intended to halt cannon's movement at end of track.
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
        //Pre-scene reset code.
    }*/

    //Unity API used to assist with SceneManager code (https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.GetSceneByName.html, https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.GetActiveScene.html, https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.LoadScene.html)
}
