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
                instructMessage = "Objective: Perform a right hand turn on the 2nd turning lane at the junction ahead.\n" +
                    "Ensure that you turn into the middle lane on the next street\nInfo: 2nd turning lane is the 2nd lane from the right.";
                break;
            case 2:
                instructMessage = "Objective: Avoid the bus lane as you enter the main street and\n" +
                    "return to left-most lane when it is okay to.\nTip: Take note of the bus lane markings.";
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
