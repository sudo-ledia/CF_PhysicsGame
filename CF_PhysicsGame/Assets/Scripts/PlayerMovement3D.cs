using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{
    Rigidbody rb;
    public Vector3 jump;
    public float speed = 0.5f;
    public float laneSpeed = 10f;
    public float jumpForce = 0.5f;
    public bool isGrounded;
    public int score = 0;

    public float gravityMultiplier = 2.0f; // Increase this value to make gravity stronger

    int whichLane = 2;

    public GameObject centerLane;
    public GameObject leftLane;
    public GameObject rightLane;
    public GameObject lanes;






    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    void OnCollisionStay()
    	{
    		isGrounded = true;
    	}
    void OnCollisionExit()
    	{
    		isGrounded = false;
    	}

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, lanes.transform.position.z);

        if(Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            isGrounded = false;
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            whichLane--;
            
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            whichLane++;
            
        }

        if(whichLane > 3)
        {
            whichLane = 3;
        }
        
        if(whichLane < 1)
        {
            whichLane = 1;
        }

        SwitchLane();
        

        
    }

    void SwitchLane()
        {
            Vector3 targetPosition = transform.position;
            switch (whichLane)
            {
                case 1:
                targetPosition.x = leftLane.transform.position.x;
                Debug.Log("Lane1");
                break;

                case 2:
                targetPosition.x = centerLane.transform.position.x;
                Debug.Log("Lane2");
                break;

                case 3:
                targetPosition.x = rightLane.transform.position.x;
                Debug.Log("Lane3");
                break;
            }
            
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, laneSpeed * Time.deltaTime);
            
        }

    void FixedUpdate()
    {
        // rb.AddForce(Vector3.forward * speed, ForceMode.Impulse);
        
        rb.AddForce(Physics.gravity * gravityMultiplier, ForceMode.Acceleration);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Treasure")
        {
            GameManager.Instance.score++;
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "Enemy")
        {
            GameManager.Instance.score--;
            Destroy(collision.gameObject);
            //SceneManagement.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    // private void OnTriggerEnter(Collider collision)
    // {
    //     if(collision.gameObject.tag == "Treasure")
    //     {
    //         GameManager.Instance.score++;
    //         Destroy(collision.gameObject);
    //     }
    // }
        
        
}

