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

    public void SpawnBall()
    {
        GameObject.Instantiate(Ball, 
                                spawnPoint.position + Vector3.right * Random.RandomRange(-6f, 6f) 
                                    + Vector3.up * Random.RandomRange(0.0f, 3.0f),
                                Quaternion.identity, this.transform);
    }


}
