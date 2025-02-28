using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laneMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float laneSpeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, laneSpeed);
    }
}
