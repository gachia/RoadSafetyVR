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
                instructMessage = "Objective: Perform a right hand turn on the\n2nd turning lane at the junction ahead.\nEnsure that you turn into the correct lane - 2nd lane to 2nd lane.";
                break;
            case 2:
                instructMessage = "Objective: Avoid the bus lane and keep to left-most lane after.\nLook out for the road markings.";
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
