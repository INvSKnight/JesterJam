using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomlessPit : MonoBehaviour
{
    BoxCollider2D pitArea;

    // Start is called before the first frame update
    void Start()
    {
        pitArea = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Ball")
        {
            Ball ball = collider.gameObject.GetComponent<Ball>();
            if (ball == null) return;
            if (ball.grabbed) return;

            print("Ball entered bottomless pit");

            GameObject spawnerObject = GameObject.FindGameObjectWithTag("BallSpawner");
            BallSpawner spawner = spawnerObject.GetComponent<BallSpawner>();
            spawner.SpawnBall(true);

            GameObject.Destroy(collider.gameObject);
        }
        else
        {
            print("Unexpected pit item: " + collider.gameObject.tag);
        }
    }
}
