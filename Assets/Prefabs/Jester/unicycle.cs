using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unicycle : MonoBehaviour
{
    public HingeJoint2D joint;

    public Rigidbody2D jesterBody;
    public Rigidbody2D counterWeight;

    float wheelDirection = 0f;
    float decelleration = 2.5f;

    public void Awake()
    {
        joint = GetComponent<HingeJoint2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        wheelDirection += horizontal * Time.deltaTime * 250.0f;
        wheelDirection = Mathf.Clamp(wheelDirection, -100f, 100f);

        
        //print("Axis: " + horizontal);
        JointMotor2D motor = joint.motor;

        motor.motorSpeed = wheelDirection * 15f;
        joint.motor = motor;
        

        wheelDirection *= (1.0f - decelleration * Time.deltaTime);
        
        //print("Wheel direction: " + wheelDirection);

        jesterBody.AddForce(Time.deltaTime * wheelDirection * Vector3.right * 6f);
        counterWeight.AddForce(Time.deltaTime * wheelDirection * Vector3.right * 3f);
    }
}
