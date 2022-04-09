using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public bool isLevelDone { get; set; }
    public bool isLevelFail { get; set; }

    public AudioSource passSound;
    public AudioSource failSound;
    private bool togglePlayed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isLevelDone && !togglePlayed)
        {
            passSound.Play();
            togglePlayed = true;
        }
        
        if (isLevelFail && !togglePlayed)
        {
            failSound.Play();
            togglePlayed = true;
        }
        
    }
}
