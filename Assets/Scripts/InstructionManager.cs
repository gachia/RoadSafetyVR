using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionManager : MonoBehaviour
{
    public Text instructionText;
    [Tooltip("Based on level number")]
    public int level;

    private string instructMessage;

    // Start is called before the first frame update
    void Start()
    {
        switch (level)
        {
            case 1:
                instructMessage = "Objective: Peform a right hand turn at the junction ahead.\nEnsure that you turn into the correct lane.";
                break;
            case 2:
                instructMessage = "Objective: Avoid the bus lane and keep into left-most lane after.\nLook out for the road markings.";
                break;
            default:
                instructMessage = "";
                break;
        }

        instructionText.text = instructMessage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
