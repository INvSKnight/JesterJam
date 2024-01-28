using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FunCounter : MonoBehaviour
{
    private TextMeshProUGUI scoreLabel;
    private int funPoints = 0;

    float timeLeft = 10f;
    public TextMeshProUGUI timeLabel;

    public TextMeshProUGUI finalLabel;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        scoreLabel = GetComponent<TextMeshProUGUI>();
        AddFunPoints(0);

        finalLabel.enabled = false;
    }

    public void AddFunPoints(int points)
    {
        funPoints += points;
        //label.text = "Funs: " + funPoints;
    }


    // Update is called once per frame
    void Update()
    {
        scoreLabel.text = "" + funPoints;

        timeLeft -= Time.deltaTime;
        timeLabel.text = ((int)timeLeft).ToString();

        if (timeLeft <= 0)
        {
            EndTheGame();
        }
    }

    private void EndTheGame()
    {
        scoreLabel.enabled = false;
        finalLabel.enabled = true;

        finalLabel.text = "Time's up! \n Score: " + funPoints;
        gameOver = true;
    }
}
