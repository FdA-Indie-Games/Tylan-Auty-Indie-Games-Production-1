using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public static int Points;
    public Text UIPoints;
    public GameObject[] Pins;
    public static int Total1;
    public static int Total2;
    public Text UITotal1;
    public Text UITotal2;
    public static int Turn;
    public static int Round = 1;
    public Text UIRound;
    public float MaxRounds;
    public GameObject Instructions;
    public float ActiveTime;
    public bool IsActive;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Turn);
        //HitCheck PinHit = GetComponent<HitCheck>();

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("RoundSelect"))
        {
            Total1 = 0;
            Total2 = 0;
            Points = 0;
            Round = 1;
            Turn = 0;
            //Resets all values, including static values, upon the scene prior to any of the actual games being active.
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("ScoreScreen"))
        {
            Points = 0;
            Round = 1;
            Turn = 0;
            //Resets all values besides the static values to allow game to read and translate final scores to text.
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("Game1"))
        {
            Total2 = Total2 + Points;
            Turn += 1;
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("Game2"))
        {
            Total1 = Total1 + Points;
            Turn += 1;
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("Game3"))
        {
            Total1 = Total1 + Points;
            Turn += 1;
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("Game4"))
        {
            Total2 = Total2 + Points;
            Turn += 1;
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("Game5"))
        {
            Total1 = Total1 + Points;
            Turn += 1;
        }
        //Sends total gained points in the round to the appropriate total upon a new game being started.

        if (Turn == 3)
        {
            Turn = 1;
            Round += 1;
        }
        //Counts up a round each time 2 turns have concluded.
        Points = 0; //Resets points on a new game after game has added points to the appropriate player.
    }
    public void ReplayReset()
    {
        Total1 = 0;
        Total2 = -80; //Game was automatically giving Total2 80 points at start, -80 is to cancel that out

        //void used to allow player to replay game from the score screen.
    }
    // Update is called once per frame
    void Update()
    {
        MaxRounds = gameObject.GetComponent<GameStart>().RoundTotal2; //Reads the non-static value from GameStart to determine how many rounds are to be played.
        
        Pins = GameObject.FindGameObjectsWithTag ("Pin");
        Points = 80 - Pins.Length; //There are 80 pins in the game by default, meaning the start calculation is 80 - 80, for every pin destroyed the points will increase.

        //Points = GetComponent<HitCheck>().PinHit; //Old code for determining how many pins had been hit, removed in favour for functioning above code.

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("Game1"))
        {
            UIPoints.text = "Hits: " + Points.ToString();
            UITotal1.text = "P1 Total: " + Total1.ToString();
            UITotal2.text = "CPU Total: " + Total2.ToString();
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("Game3"))
        {
            UIPoints.text = "Hits: " + Points.ToString();
            UITotal1.text = "P1 Total: " + Total1.ToString();
            UITotal2.text = "CPU Total: " + Total2.ToString();
        }
        //Determines UI elements used for VS CPU Mode.

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("Game2"))
        {
            UIPoints.text = "Hits: " + Points.ToString();
            UITotal1.text = "Total: " + Total1.ToString();
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("Game4"))
        {
            UIPoints.text = "Hits: " + Points.ToString();
            UITotal1.text = "P1 Total: " + Total1.ToString();
            UITotal2.text = "P2 Total: " + Total2.ToString();
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("Game5"))
        {
            UIPoints.text = "Hits: " + Points.ToString();
            UITotal1.text = "P1 Total: " + Total1.ToString();
            UITotal2.text = "P2 Total: " + Total2.ToString();
        }
        //Determines UI elements for other two modes.

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("ScoreScreen"))
        {
            UITotal1.text = "P1 Total: " + Total1.ToString();
            UITotal2.text = "P2 Total: " + Total2.ToString();
        }
        //Sends final scores to score screen.

        UIRound.text = "Round " + Round.ToString() + "/" + MaxRounds.ToString(); //Translates the current round and total rounds to text.


        if(Round > MaxRounds)
        {
            SceneManager.LoadScene("ScoreScreen");
        }
        //Loads the score screen if the current round number has exceeded the maximum round number.

        if(Round == 1 && Turn == 1) //Determines system can only be used during the very first turn.
        {
            IsActive = true;
            ActiveTime = ActiveTime + Time.deltaTime;
            if (ActiveTime >= 3)
            {
                IsActive = false;
            }
        }
        Instructions.SetActive(IsActive); //Sets the instructions to only be active when the corresponding bool is set to true.
    }
}
//Code often based on existing code from within this project.