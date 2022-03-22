using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarCollide : MonoBehaviour {

    public string message;
    public Text resultsText;
    /*
    public bool guiOn;
    public Rect boxSize = new Rect(0, 0, 200, 100);
    public GUISkin customSkin;
    */

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            resultsText.enabled = true;
            resultsText.text = message;
        }
    }

    /*
    void OnTriggerExit() {
        guiOn = false;
    }

    private void OnGUI() {
        if (customSkin != null) {
            GUI.skin = customSkin;
        }

        if (guiOn == true) {
            GUI.BeginGroup(new Rect(( Screen.width - boxSize.width ) / 2, ( Screen.height - boxSize.height ) / 2,
                boxSize.width, boxSize.height));
            GUI.Label(boxSize, message);
            GUI.EndGroup();
        }
    }
    */
}
