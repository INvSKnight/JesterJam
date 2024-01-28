using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject Ball;
    public Transform spawnPoint;

    

    // Start is called before the first frame update
    void Start()
    {
        int ballsToSpawn = 4;
        for (int i = 0; i < ballsToSpawn; i++)
        {
            SpawnBall(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            SpawnBall();
        }    
    }

    public void SpawnBall(bool waffle = false)
    {
        Vector3 x = Vector3.right * Random.RandomRange(-5f, 5f);
        Vector3 y = Vector3.up * Random.RandomRange(0.0f, 3.0f);

        GameObject newBall;
        newBall = (GameObject)Instantiate(Ball, spawnPoint.position + x + y, Quaternion.identity, this.transform);

        Ball ballClass = newBall.GetComponent<Ball>();
        ballClass.EnableWaffleMode();
    }


}
