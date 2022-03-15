using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Steering : MonoBehaviour
{
    public ActionBasedController leftController;
    public ActionBasedController rightController;
    public Transform offset;
    public Transform steeringWheel;
    public Transform steeringWheelChild;
    public WheelCollider wheelFL;
    public WheelCollider wheelFR;
    public WheelCollider wheelBL;
    public WheelCollider wheelBR;
    public Transform wheelFLTransform;
    public Transform wheelFRTransform;
    public float accelerationForce;
    public float breakForce;
    public float maxSteerAngle;

    private Transform target;
    private Vector3 fromVector;
    private bool hasSteered;
    private float angleBetween;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            offset.position = target.position;
            offset.localPosition = new Vector3(offset.localPosition.x, 0, offset.localPosition.z);
            Vector3 dir = offset.position - transform.position;
            Quaternion rot = Quaternion.LookRotation(dir, transform.up);
            steeringWheel.rotation = rot;

            if (hasSteered)
            {
                angleBetween = Vector3.Angle(fromVector, dir);
                Vector3 cross = Vector3.Cross(fromVector, dir);
                if (cross.z > 0)
                {
                    angleBetween = -angleBetween;
                }
                fromVector = dir;
                //Debug.Log(angleBetween);

                float angle = wheelFL.steerAngle;
                angle += angleBetween / 10;
                Debug.Log(angle);
                angle = Mathf.Clamp(angle, -maxSteerAngle, maxSteerAngle);
                wheelFL.steerAngle = angle;
                wheelFR.steerAngle = angle;
                AngleWheel(wheelFL, wheelFLTransform);
                AngleWheel(wheelFR, wheelFRTransform);
                //Debug.Log(angle);
            }
            else
            {
                hasSteered = true;
                fromVector = dir;
            }
        }

        if (leftController.activateAction.action.ReadValue<float>() > 0.0f)
        {
            Debug.Log("Brake");
            wheelFL.brakeTorque = breakForce;
            wheelFR.brakeTorque = breakForce;
            wheelBL.brakeTorque = breakForce;
            wheelBR.brakeTorque = breakForce;
        }
        else
        {
            wheelFL.brakeTorque = 0;
            wheelFR.brakeTorque = 0;
            wheelBL.brakeTorque = 0;
            wheelBR.brakeTorque = 0;
        }

        if (rightController.activateAction.action.ReadValue<float>() > 0.0f)
        {
            Debug.Log("Accelerate");
            wheelBL.motorTorque = accelerationForce;
            wheelBR.motorTorque = accelerationForce;
        }
        else
        {
            wheelBL.motorTorque = 0;
            wheelBR.motorTorque = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            target = other.transform;

            offset.position = target.position;
            offset.localPosition = new Vector3(offset.localPosition.x, 0, offset.localPosition.z);
            Vector3 dir = offset.position - transform.position;
            Quaternion rot = Quaternion.LookRotation(dir, transform.up);

            steeringWheelChild.SetParent(null);
            steeringWheel.rotation = rot;
            steeringWheelChild.SetParent(steeringWheel);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            target = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            target = null;
            hasSteered = false;
        }
    }

    private void AngleWheel(WheelCollider w, Transform t)
    {
        Vector3 pos;
        Quaternion rot;

        w.GetWorldPose(out pos, out rot);
        t.rotation = rot;
    }
}
