using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckBehaviour : MonoBehaviour
{
   
    public float friction = 0.98f;    
    public float maxSpeed = 10f;        
    public float forceMultiplier = 10f; 
    public Vector3 startPosition;
    private Rigidbody rb;

    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        rb.useGravity = false; 
        rb.drag = 0f;          
        rb.angularDrag = 0.5f;
    }

    void Update()
    {
        if (rb.velocity.magnitude > 0)
        {
            rb.velocity *= friction;
        }
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    public void ApplyForce(Vector3 direction)
    {
        rb.AddForce(direction * forceMultiplier, ForceMode.Impulse);
    }
    public void ResetPuck()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = startPosition;
    }
}
