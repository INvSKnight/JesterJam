using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using TMPro;
using UnityEditor.UI;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public TextMeshProUGUI wordLabel;
    public TextMeshProUGUI scoreLabel;

    public GameObject HUD;

    public bool grabbed = false;
    public Transform grabLocation;
  

    private Rigidbody2D rb;

    private float timeOfLastThrow = 0;
    private float timeOfCreation = 0;
    public float timeOfLastCollision = 0;

    public string magicWord = "hello";


    public string[] allMagicWords = new string[] { "hello", "left", "right",
                                                "blue", "green", "red", "yellow",
                                                "ball", "juggle", "throw",
                                                "jester", "king", "tomato"};

    private AudioSource sfxThrow;
    private int throwCount = 0;

    private bool waffle = false;
    public Sprite waffleTexture;

    // Start is called before the first frame update
    void Start()
    {
        timeOfCreation = Time.time;

        RandomizeMagicWord();

        rb = GetComponent<Rigidbody2D>();
        wordLabel.canvas.worldCamera = Camera.main;

        wordLabel.text = magicWord;
        scoreLabel.text = "";

        sfxThrow = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        HUD.transform.rotation = Quaternion.Euler(0, 0, 0);

        if (grabbed)
        {
            this.transform.position = grabLocation.position;
        }

        wordLabel.text = magicWord;
        if (throwCount <= 1)
        {
            scoreLabel.text = "";
        } else
        {
            scoreLabel.text = "" + throwCount;
        }
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
        throwCount++;
        timeOfLastThrow = Time.time;
        grabbed = false;
        //rb.AddForce(Vector3.up * 200f);

        Vector3 y = Vector3.up * (7f + Random.RandomRange(-1.0f, 1.0f));
        Vector3 x = Vector3.right * 0f; // Random.RandomRange(-0.5f, 0.5f);
        rb.velocity = y + x;

        sfxThrow.Play();

        // Scoring the throw
        GameObject scoreObject = GameObject.FindGameObjectWithTag("FunCounter");
        FunCounter funCounter = scoreObject.GetComponent<FunCounter>();
        if (!funCounter.gameOver)
        {
            funCounter.AddFunPoints(throwCount);
        }

        RandomizeMagicWord();

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

    public void ResetCombo()
    {
        throwCount = 0;
        timeOfLastCollision = Time.time;

        RandomizeMagicWord();
    }

    public void ReduceCombo()
    {
        throwCount -= 1;

        RandomizeMagicWord();
    }

    public void EnableWaffleMode()
    {
        waffle = true;
        SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.sprite = waffleTexture;

        spriteRenderer.transform.localScale = Vector3.one;
        CircleCollider2D circle = GetComponent<CircleCollider2D>();
        circle.radius = 0.5f;

        scoreLabel.color = Color.yellow;
    }

    public bool isWaffle()
    {
        return waffle;
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        // Ignore collisions right after being spawned, to prevent infinite loop in spawn area
        float secondsExisting = Time.time - timeOfCreation;
        if (secondsExisting < 0.2f) return;

        // Splatter if the other object is a ball
        if (collision.otherCollider == null) return;
        if (collision.otherCollider.gameObject.tag != "Ball") return;
        if (grabbed) return;
        // For some reason it still triggers on the rope. Hacky solution: 
        if (this.transform.position.y < -2.0f) return;



        float timeSinceLastCollision = Time.time - timeOfLastCollision;
        timeOfLastCollision = Time.time;


        this.throwCount += 1;

        //RandomizeMagicWord();

        /*
        GameObject spawnerObject = GameObject.FindGameObjectWithTag("BallSpawner");
        BallSpawner spawner = spawnerObject.GetComponent<BallSpawner>();

        
        spawner.SpawnBall();
        //spawner.SpawnBall();

        GameObject.Destroy(collision.otherCollider.gameObject);
        GameObject.Destroy(this.gameObject);
        */

    }


}
