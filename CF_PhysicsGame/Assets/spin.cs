using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour
{

    public float rotationSpeed = 90f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate around the Y-axis (change this vector if you want a different rotation axis)
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
    
}
