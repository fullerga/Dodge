using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timer : MonoBehaviour {
	
	private Text text;
	
	void Start () {
		text = GetComponent<Text> ();
	}
	
	void Update () {
		float time = Time.timeSinceLevelLoad;
		int minutes =  (int)time / 60;
		int seconds =  (int)time % 60;
		text.text = string.Format ("{0:0}:{1:00}", minutes, seconds); 
	}
}

