using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FunCounter : MonoBehaviour
{
    private TextMeshProUGUI label;
    private int funPoints = 0;

    // Start is called before the first frame update
    void Start()
    {
        AddFunPoints(0);
    }

    void AddFunPoints(int points)
    {
        funPoints += points;
        label.text = "Funs: " + funPoints;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
