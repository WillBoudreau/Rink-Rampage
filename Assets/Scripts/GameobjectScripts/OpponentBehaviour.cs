using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentBehaviour : MoveableSettings
{
    public enum State
    {
        Idle,
        Chasing,
        Shooting,
        Check,
    }
    public GameObject puck;
    public float ShotTimer = 1f;
    public bool IsShooting;
    private State currentState;
    public Rigidbody rb;    
    PuckBehaviour puckScript;

    // Start is called before the first frame update
    void Start()
    {
        puckScript = puck.GetComponent<PuckBehaviour>();
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeState();
    }
    void ChangeState()//Change the state of the AI
    {
        switch(currentState)
        {
            case State.Idle:
                //Check if the puck is close enough to start chasing
                Debug.Log("Idle");
                if(Vector3.Distance(transform.position, puck.transform.position) > AIMinDistPuck)
                {
                    currentState = State.Chasing;
                }
                else if(Vector3.Distance(transform.position, puck.transform.position) < AIMinDistPuck)
                {
                    currentState = State.Shooting;
                }
                else
                {
                    transform.LookAt(puck.transform);
                }
                break;
            case State.Chasing:
                //Chase the puck
                Debug.Log("Chasing");
                transform.LookAt(puck.transform);
                transform.position += transform.forward * AISpeed * Time.deltaTime;
                if(Vector3.Distance(transform.position, puck.transform.position) < AIMinDistPuck)
                {
                    currentState = State.Shooting;
                }
                break;
            case State.Shooting:
                //Shoot the puck
                Debug.Log("Shooting");
                puckScript.ApplyForce(transform.forward);
                currentState = State.Idle;
                // if(!IsShooting)
                // {
                //     ShotTimer = 1f;
                //     IsShooting = true;
                // }
                // ShotTimer -= Time.deltaTime * 100;
                // Debug.Log(ShotTimer);
                // if(ShotTimer <= 0)
                // {
                //     Debug.Log("Shot");
                //     if(Vector3.Distance(transform.position, puck.transform.position) < MinDistPuck)
                //     {
                //         puckScript.ApplyForce(transform.forward);
                //     }
                //     else
                //     {
                //         currentState = State.Idle;
                //     }
                // }
                // IsShooting = false;
                // ShotTimer = 1f;
                break;
            case State.Check:
                // Push the player away from the puck
                Debug.Log("Check");

                break;
        }

    }
}
