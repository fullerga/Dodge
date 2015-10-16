using UnityEngine;
using System.Collections;

public class mainMenuButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        gameSettings.isMainScreen = true;
        gameSettings.needMainScreen = true;
        gameSettings.isDead = false;
        Destroy(GameObject.Find("deadScreen(Clone)"));
        Destroy(GameObject.Find("playAgainButton(Clone)"));
        Destroy(gameObject);
    }
}
