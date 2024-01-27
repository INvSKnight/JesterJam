using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juggling : MonoBehaviour
{
    public Transform handLeft;
    public Transform handRight;

    public Ball ballLeft = null;
    public Ball ballRight = null;

    private CircleCollider2D catchArea;
    public LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        catchArea = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Trying to catch some juggling balls
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(catchArea.transform.position, catchArea.radius, layerMask);

        if (hitColliders.Length > 0)
        {
            print("Juggling balls: " + hitColliders.Length);
        }

        CatchBall(hitColliders);


        // Throwing ball
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ThrowBallLeft();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            ThrowBallRight();
        }

        // Testing voice recognition
        if (Input.GetKeyDown(KeyCode.T))
        {
            TryToThrowBall("hello");
        }
    }



    public void CatchBall(Collider2D[] hitColliders)
    {
        if (hitColliders.Length == 0) return;


        Collider2D closestBall = hitColliders[0];
        float closestDistance = 9999f;
        
        foreach (Collider2D c in hitColliders)
        {
            if (c.tag != "Ball") continue;
            Ball ballToCatch = c.GetComponent<Ball>();
            if (ballToCatch.grabbed) continue;
            if (!ballToCatch.isGrabbable()) continue;

            Rigidbody2D ballBody = c.GetComponent<Rigidbody2D>();
            // Avoid grabbing right after thrown
             

            float dist = Vector3.Distance(c.transform.position, this.transform.position);
            if (dist < closestDistance)
            {
                closestDistance = dist;
                closestBall = c;
            }
        }

        Ball ball = closestBall.GetComponent<Ball>();


        if (ball.grabbed) return;
        if (!ball.isGrabbable()) return;


        if (ballLeft == null)
        {
            ballLeft = ball;
            ball.grabbed = true;
            ball.grabLocation = handLeft.transform;
        }
        
        else
        {
            if (ballRight == null)
            {
                ballRight = ball;
                ball.grabbed = true;
                ball.grabLocation = handRight.transform;
            }
        }
    }

    public void ThrowBallLeft()
    {
        if (ballLeft == null) return;
        ballLeft.GetComponent<Ball>().Throw();
        ballLeft = null;
    }

    public void ThrowBallRight()
    {
        if (ballRight == null) return;
        ballRight.GetComponent<Ball>().Throw();
        ballRight = null;
    }


    // Only allows the throw if the correct word is said. Input parameter must match one of the held balls.
    public void TryToThrowBall(string spokenWord)
    {
        print("Trying to throw a ball with word " + spokenWord);
        if (ballLeft == null && ballRight == null) return;

        // Check if either of the held juggling balls matches the word from voice recognition
        if (ballLeft != null && ballLeft.MatchesWord(spokenWord))
        {
            ballLeft.Throw();
            ballLeft = null;
        }
        if (ballRight != null && ballRight.MatchesWord(spokenWord))
        {
            ballRight.Throw();
            ballRight = null;
        }


    }


}
