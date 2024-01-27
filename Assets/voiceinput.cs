using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class voiceinput : MonoBehaviour
{
    Juggling juggling;

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    private void Start()
    {
        juggling = GameObject.Find("Juggling").GetComponent<Juggling>();
        actions.Add("left", Up);
        actions.Add("right", Down);
        actions.Add("tomato", Tomato);
        actions.Add("blue", Blue);
        actions.Add("hello", Hello);
        actions.Add("green", Green);
        actions.Add("red", Red);
        actions.Add("ball", Roundthing);
        actions.Add("juggle", Throwthing);
        actions.Add("throw", Lunge);
        actions.Add("jester", Jester);
        actions.Add("king", King);


        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }
    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void Up()
    {
        print("Voice LEFT");
        juggling.ThrowBallLeft();
    }
    private void Down()
    {
        print("Voice RIGHT");
        juggling.ThrowBallRight();
    }

    private void Tomato() 
    {
        juggling.TryToThrowBall("tomato");  
    }

    private void Blue()
    {
        juggling.TryToThrowBall("blue");
    }

    private void Hello() 
    {
        juggling.TryToThrowBall("hello");
    }

    private void Red() 
    {
        juggling.TryToThrowBall("red");
    }

    private void Lunge() 
    {
        juggling.TryToThrowBall("throw");
    }

    private void Jester()
    {
        juggling.TryToThrowBall("jester");
    }

    private void King() 
    {
        juggling.TryToThrowBall("king");
    }

    private void Green() 
    {
        juggling.TryToThrowBall("green");
    }

    private void Roundthing() 
    {
        juggling.TryToThrowBall("ball");
    }

    private void Throwthing()
    {
        juggling.TryToThrowBall("juggle");
    }
}