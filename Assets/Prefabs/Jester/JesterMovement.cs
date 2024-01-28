using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JesterMovement : MonoBehaviour
{
    float lean = 0; // Unicycle leaning -1..0..1 for left-stable-right

    private Rigidbody2D rb;

    // Awake is before first frame
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHorizontalMovement();
    }


    void UpdateHorizontalMovement()
    {
        var horizontal_input = Input.GetAxis("Horizontal");
        float leanSpeed = 100f;

        rb.AddForce(horizontal_input * Vector3.right * leanSpeed);

        print(rb.transform.eulerAngles.z);
    }

}
