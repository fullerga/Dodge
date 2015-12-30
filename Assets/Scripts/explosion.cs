using UnityEngine;
using System.Collections;

public class explosion : MonoBehaviour {

    int frame = 0;

	void Update () {
        frame += 1;
        if (frame >= 60)
        {
            Destroy(GameObject.Find("health"));
            Destroy(GameObject.Find("healthBarEmpty"));
            Destroy(GameObject.Find("Canvas"));
            Destroy(GameObject.Find("EventSystem"));
            Destroy(GameObject.Find("level"));
            Destroy(GameObject.Find("topBar"));
            Destroy(GameObject.Find("powerupSpawner"));
            Destroy(gameObject);
			Application.LoadLevel("GameOver");
        }
	}
}