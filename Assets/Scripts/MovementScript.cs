using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 100f;
    [SerializeField] AudioClip thrustSound;
    [SerializeField] ParticleSystem thrusterParticle;
    [SerializeField] ParticleSystem thrusterLeftParticle;
    [SerializeField] ParticleSystem thrusterRightParticle;

    Rigidbody rb;
    AudioSource audioSource;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    void ProcessRotaion()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateRight();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateLeft();
        }
        else
        {
            thrusterLeftParticle.Stop();
            thrusterRightParticle.Stop();
        }
    }

    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(thrustSound);
        }
        if (!thrusterParticle.isPlaying)
        {
            thrusterParticle.Play();
        }
    }
    void StopThrusting()
    {
        audioSource.Stop();
        thrusterParticle.Stop();
    }

    

    
    private void RotateRight()
    {
        ApplyRotaion(rotationThrust);
        if (!thrusterRightParticle.isPlaying)
        {
            thrusterRightParticle.Play();
        }
    }
    private void RotateLeft()
    {
        ApplyRotaion(-rotationThrust);
        if (!thrusterLeftParticle.isPlaying)
        {
            thrusterLeftParticle.Play();
        }
    }

    

    void ApplyRotaion(float rotationThisFrame)
    {
        rb.freezeRotation = true; //freezing rotation, so we can manually rorate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;  //unfreezing rotation so the physics system can take over
        
    }


}
