using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 100f;
    Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        ProcessThrust();
        ProcessRotaion();
    }
    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            Debug.Log("Space is pressed!");
        }
    }

    void ProcessRotaion()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotaion(rotationThrust);
            Debug.Log("A is pressed!"); 
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotaion(-rotationThrust);
            Debug.Log("D is pressed!");

        }
    }

    void ApplyRotaion(float rotationThisFrame)
    {
        rb.freezeRotation = true; //freezing rotation, so we can manually rorate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;  //unfreezing rotation so the physics system can take over
    }


}
