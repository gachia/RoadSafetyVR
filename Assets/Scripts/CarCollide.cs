using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollide : MonoBehaviour {

    public string text;
    public bool guiOn;
    public Rect boxSize = new Rect(0, 0, 200, 100);
    public GUISkin customSkin;

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
            guiOn = true;
        }
    }

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
            GUI.Label(boxSize, text);
            GUI.EndGroup();
        }
    }
}
