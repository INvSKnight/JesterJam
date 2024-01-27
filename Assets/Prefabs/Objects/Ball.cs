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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        label.canvas.worldCamera = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        HUD.transform.rotation = Quaternion.Euler(0, 0, 0);

        if (grabbed)
        {
            this.transform.position = grabLocation.position;
        }
    }

    // The ball cannot be caught by the jester if already caught or just thrown
    public bool isGrabbable()
    {
        if (grabbed) return false;
        float timeSinceLastThrow = Time.time - timeOfLastThrow;
        if (timeSinceLastThrow < 1.0) return false;

        return true;
    }

    public void Throw()
    {
        timeOfLastThrow = Time.time;
        grabbed = false;
        //rb.AddForce(Vector3.up * 200f);
        rb.velocity = Vector3.up * 8f + Vector3.right * Random.RandomRange(-0.5f, 0.5f);
    }
}
