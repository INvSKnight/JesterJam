using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopePiece : MonoBehaviour
{
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (rb == null) return;

        if (collision.collider.gameObject.tag == "Ball")
        {
            print("BALL HIT THE ROPE!");
            Ball ballOnRope = collision.collider.gameObject.GetComponent<Ball>();
            ballOnRope.ResetCombo();

        } else
        {
            //print("What is this?: " + collision.collider.gameObject.tag);
        }
    }
}
