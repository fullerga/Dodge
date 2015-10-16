using UnityEngine;
using System.Collections;

public class explosion : MonoBehaviour {

    int frame = 0;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        frame += 1;

        if (frame >= 60)
        {
            gameSettings.isDead = true;
            gameSettings.needDeadScreen = true;
            Destroy(GameObject.Find("gameScreen(Clone)"));
            Destroy(gameObject);
        }
	}
}