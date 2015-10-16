using UnityEngine;
using System.Collections;

public class playAgainButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        gameSettings.isPlaying = true;
        gameSettings.isDead = false;
        gameSettings.needGameScreen = true;
        Destroy(GameObject.Find("deadScreen(Clone)"));
        Destroy(GameObject.Find("mainMenuButton(Clone)"));
        Destroy(gameObject);
    }
}
