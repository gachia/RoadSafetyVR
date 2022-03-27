using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CarController : MonoBehaviour
{
    public Transform steeringWheel;
    public Transform target;

    private Transform hand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hand)
        {
            target.position = hand.position;
            target.localPosition = new Vector3(target.localPosition.x, target.localPosition.y, 0);
            Vector3 dir = target.position - steeringWheel.position;
            Quaternion rot = Quaternion.LookRotation(dir, transform.up);

            steeringWheel.rotation = rot;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            hand = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            hand = null;
        }
    }
}
