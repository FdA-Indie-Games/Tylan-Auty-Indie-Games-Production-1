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

    public GameObject FirePoint;
    // Start is called before the first frame update
    void Start()
    {
        SpeedStop = false;
        EndPoint = RightEnd;
    }

    // Update is called once per frame
    void Update()
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
            SpeedStop = true;
        }

        if (LeftEnd == EndPoint)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Instantiate(ball, FirePoint.transform.position, transform.rotation);
            }
        }

        if (Input.GetButtonDown("Fire2"))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    IEnumerator DirectionChange()
    {
        yield return new WaitForSeconds(2);
        SpeedStop = false;
        EndPoint = LeftEnd;
    }

    /* public void OnTriggerEnter(Collider Endcheck)
    {
        SpeedStop = true;
    }*/
}
