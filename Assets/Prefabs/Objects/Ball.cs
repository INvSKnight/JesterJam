using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using TMPro;
using UnityEditor.UI;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public TextMeshProUGUI label;
    public GameObject HUD;

    public bool grabbed = false;
    public Transform grabLocation;

    private Rigidbody2D rb;

    private float timeOfLastThrow = 0;
    private float timeOfCreation = 0;

    public string magicWord = "hello";


    public string[] allMagicWords = new string[] { "hello", "left", "right",
                                                "blue", "green", "red", "yellow",
                                                "ball", "juggle", "throw",
                                                "jester", "king", "tomato"};

    // Start is called before the first frame update
    void Start()
    {
        timeOfCreation = Time.time;

        RandomizeMagicWord();

        rb = GetComponent<Rigidbody2D>();
        label.canvas.worldCamera = Camera.main;

        label.text = magicWord;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        HUD.transform.rotation = Quaternion.Euler(0, 0, 0);

        if (grabbed)
        {
            this.transform.position = grabLocation.position;
        }

        label.text = magicWord;
    }

    // The ball cannot be caught by the jester if already caught or just thrown
    public bool isGrabbable()
    {
        if (grabbed) return false;
        float timeSinceLastThrow = Time.time - timeOfLastThrow;
        if (timeSinceLastThrow < 2.0) return false;

        return true;
    }

    public void Throw()
    {
        timeOfLastThrow = Time.time;
        grabbed = false;
        //rb.AddForce(Vector3.up * 200f);

        Vector3 y = Vector3.up * (7f + Random.RandomRange(-1.0f, 1.0f));
        Vector3 x = Vector3.right * 0f; // Random.RandomRange(-0.5f, 0.5f);
        rb.velocity = y + x;
    }

    public bool MatchesWord(string word)
    {
        if (word == null) return false;
        return magicWord.ToLower().Trim().Contains(word.ToLower().Trim());
    }

    public void RandomizeMagicWord()
    {
        int index = (int)Random.RandomRange(0, allMagicWords.Length - 1);
        this.magicWord = allMagicWords[index];
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // Ignore collisions right after being spawned, to prevent infinite loop in spawn area
        float secondsExisting = Time.time - timeOfCreation;
        if (secondsExisting < 0.2f) return;

        // Splatter if the other object is a ball
        if (collision.otherCollider == null) return;
        if (collision.otherCollider.gameObject.tag != "Ball") return;
        // For some reason it still triggers on the rope. Hacky solution: 
        if (this.transform.position.y < -2.0f) return; 

        GameObject spawnerObject = GameObject.FindGameObjectWithTag("BallSpawner");
        BallSpawner spawner = spawnerObject.GetComponent<BallSpawner>();

        
        spawner.SpawnBall();
        //spawner.SpawnBall();


        GameObject.Destroy(collision.otherCollider.gameObject);
        GameObject.Destroy(this.gameObject);
        
    }


}
