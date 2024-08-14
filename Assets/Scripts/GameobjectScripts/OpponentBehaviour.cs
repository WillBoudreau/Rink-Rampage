using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentBehaviour : MonoBehaviour
{
    public enum State
    {
        Idle,
        Chasing,
        Shooting
    }
    public GameObject puck;
    float ShotTimer;
    bool IsShooting;
    public float movementSpeed = 5f;
    float MinDistPuck = 3f;
    private State currentState;
    public Rigidbody rb;    
    PuckBehaviour puckScript;

    // Start is called before the first frame update
    void Start()
    {
        puckScript = puck.GetComponent<PuckBehaviour>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState)
        {
            case State.Idle:
                if(Vector3.Distance(transform.position, puck.transform.position) > MinDistPuck)
                {
                    currentState = State.Chasing;
                }
                break;
            case State.Chasing:
                transform.LookAt(puck.transform);
                transform.position += transform.forward * movementSpeed * Time.deltaTime;
                if(Vector3.Distance(transform.position, puck.transform.position) < MinDistPuck)
                {
                    currentState = State.Shooting;
                }
                break;
            case State.Shooting:
                //Shoot the puck
                if(!IsShooting)
                {
                    ShotTimer = 3f;
                    IsShooting = true;
                }
                ShotTimer -= Time.deltaTime;
                if(ShotTimer <= 0)
                {
                    if(Vector3.Distance(transform.position, puck.transform.position) < 2f)
                    {
                        puckScript.ApplyForce(transform.forward);
                    }
                }
                IsShooting = false;
                currentState = State.Idle;
                break;
        }
    }

}
