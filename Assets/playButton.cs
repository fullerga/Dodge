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

    void OnMouseDown()
    {
        gameSettings.isPlaying = true;
        gameSettings.isMainScreen = false;
        gameSettings.needGameScreen = true;
        Destroy(GameObject.Find("mainScreen(Clone)"));
        Destroy(gameObject);
    }
}
