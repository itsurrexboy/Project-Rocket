using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillatorScript : MonoBehaviour
{

    [SerializeField] Vector3 movementVector;
    [SerializeField] float period = 2f;
    Vector3 startingPos;
    float movementFactor;

    void Start()
    {
        startingPos = transform.position; //this will get the initial position of the object.
    }
    void Update()
    {
        if(period == 0) {  return; }    
        float cycles = Time.time / period;
        const float tau = MathF.PI * 2;

        float rawSinWave = MathF.Sin(cycles * tau);

        movementFactor = (rawSinWave + 1f) / 2f;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
    }

}
