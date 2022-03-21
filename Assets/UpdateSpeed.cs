using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSpeed : MonoBehaviour
{
    public Text speedometer;
    public float speedLimit;

    public float speed { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        speed = GetComponent<Rigidbody>().velocity.magnitude * 3.6f;
        speedometer.text = (int)speed + " km/h";

        if (speed >= speedLimit)
        {
            speedometer.color = Color.red;
        }
    }

}
