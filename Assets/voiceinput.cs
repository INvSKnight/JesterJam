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
}