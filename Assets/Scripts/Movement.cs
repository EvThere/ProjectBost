﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float mainThrust =100f;
    [SerializeField] float rotationThrust = 100f;
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
        ProcessRotation();
    }


    void ProcessRotation()
    {
       

        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
        }

    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; //freezing rotation so that we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if(!audioSource.isPlaying)
            {
                audioSource.Play();
            }
           

        }
        else
        {
            audioSource.Stop();
        }
    }


}
