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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            SpawnBall();
        }    
    }

    void SpawnBall()
    {
        print("Spawning ball");
        GameObject.Instantiate(Ball, spawnPoint.position + Vector3.right * Random.RandomRange(-6f, 6f), Quaternion.identity, this.transform);
    }


}
