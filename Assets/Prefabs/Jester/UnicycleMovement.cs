using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class UnicycleMovement : MonoBehaviour
{
    public WheelJoint2D unicycle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        print("Axis: " + horizontal);
        JointMotor2D motor = unicycle.motor;

        motor.motorSpeed = horizontal * Time.deltaTime * 1000.0f * 10.0f;
        unicycle.motor = motor;

        print("Motor speed: " + motor.motorSpeed);
    }

    
}
