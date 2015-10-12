using UnityEngine;
using System.Collections;

public class explosion : MonoBehaviour {

    int frame = 0;

	// Use this for initialization
	void Start () {

        if (!titleScreen.isPlaying)
        {
            return;
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (!titleScreen.isPlaying)
        {
            return;
        }

        frame += 1;

        if (frame >= 60)
        {
            Destroy(gameObject);
        }
	}
}