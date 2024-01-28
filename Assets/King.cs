using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour
{

    public SpriteRenderer bubbleStart;
    public SpriteRenderer bubbleEnd;

    // Start is called before the first frame update
    void Start()
    {
        bubbleStart.enabled = true;
        bubbleEnd.enabled = false;
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReactToJugglingStart()
    {
        bubbleStart.enabled = false;
        bubbleEnd.enabled = false;
    }

    public void ReactToGameOver()
    {
        bubbleStart.enabled = false;
        bubbleEnd.enabled = true;
    }
}
