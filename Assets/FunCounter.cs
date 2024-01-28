using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FunCounter : MonoBehaviour
{
    private TextMeshProUGUI scoreLabel;
    private int funPoints = 0;

    float timeLeft = 60f;
    public TextMeshProUGUI timeLabel;

    public TextMeshProUGUI finalLabel;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        scoreLabel = GetComponent<TextMeshProUGUI>();
        AddFunPoints(0);

        if (finalLabel != null)
        {
            finalLabel.color = Color.clear;
        }

    }

    public void AddFunPoints(int points)
    {
        funPoints += points;
        //label.text = "Funs: " + funPoints;
    }


    // Update is called once per frame
    void Update()
    {
        if (scoreLabel != null)
        {
            scoreLabel.text = "" + funPoints;
        }


        timeLeft -= Time.deltaTime;
        if (timeLabel != null)
        {
            timeLabel.text = ((int)timeLeft).ToString();
        }


        if (timeLeft <= 0)
        {
            EndTheGame();
        }
    }

    private void EndTheGame()
    {
        if (scoreLabel != null)
        {
            scoreLabel.color = Color.clear;
        }
        if (finalLabel != null)
        {
            finalLabel.color = Color.white;
        }


        finalLabel.text = "Time's up! \n Score: " + funPoints;
        gameOver = true;

        Invoke("RestartGame", 3f);
    }

    private void RestartGame()
    {
        print("Restarting game");
        GameObject[] ballObjects = GameObject.FindGameObjectsWithTag("Ball");
        foreach (GameObject ballObject in ballObjects)
        {
            GameObject.Destroy(ballObject);
        }

        GameObject ballSpawnerObject = GameObject.FindGameObjectWithTag("BallSpawner");
        BallSpawner ballSpawner = ballSpawnerObject.GetComponent<BallSpawner>();
        for (int i = 0; i < 4; i++)
        {
            ballSpawner.SpawnBall();
        }

        if (finalLabel != null)
        {
            finalLabel.color = Color.clear;
        }
        if (scoreLabel != null)
        {
            scoreLabel.color = Color.white;
        }
        if (timeLabel != null)
        {
            timeLabel.color = Color.white;
        }



        timeLeft = 60.0f;
        gameOver = false;
        funPoints = 0;

    }
}
