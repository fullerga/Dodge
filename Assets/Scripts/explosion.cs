using UnityEngine;
using System.Collections;

public class explosion : MonoBehaviour {

    int frame = 0;

	void Update () {
        frame += 1;
        if (frame >= 60)
        {
            Destroy(gameObject);
			Application.LoadLevel("GameOver");
        }
	}
}