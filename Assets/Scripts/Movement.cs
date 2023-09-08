using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rigidbody;
    [SerializeField] float thrustForce = 1000f;
    [SerializeField] float rotateForce = 200f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust() 
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody.AddRelativeForce(thrustForce * Time.deltaTime * Vector3.up);
        }

    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            ApplyRotation(1);
        }
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            ApplyRotation(-1);
        }
    }

    private void ApplyRotation(float direction)
    {
        rigidbody.freezeRotation = true;
        transform.Rotate(direction * RotationForce);
        rigidbody.freezeRotation = false;
    }

    private Vector3 RotationForce
    {
        get
        {
            return Vector3.forward * rotateForce * Time.deltaTime;
        }
    }
}
