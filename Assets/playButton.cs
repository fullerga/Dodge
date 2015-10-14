using UnityEngine;
using System.Collections;

public class playButton : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onClick()
    {
        titleScreen.isPlaying = true;
        GameObject.Find("title").active = false;
        GameObject.Find("uiPlayButton").active = false;
    }
}
