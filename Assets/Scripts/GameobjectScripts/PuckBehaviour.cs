using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckBehaviour : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 StartPOS;  
    public GameObject Player;  
    public Vector3 velocity;
    // Get the player's forward direction
    public Vector3 playerForward;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartPOS = transform.position;
        Player = GameObject.Find("Player");
        playerForward = Player.transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        if(velocity.y <= -15)
        {   
            transform.position = StartPOS;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // Add force in the player's forward direction
            Debug.Log("Player Hit");
            rb.AddForce(playerForward * 10, ForceMode.Impulse);
        }
    }
}
