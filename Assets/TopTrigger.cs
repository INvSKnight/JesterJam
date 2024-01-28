using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Ball")
        {
            print("Juggling ball has reached the ceiling");
        } else
        {
            print("Unexpected item took flight: " + collider.gameObject.tag);
        }
    }
}
