using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class score : MonoBehaviour {
	
	private Text text;
	
	void Start () {

        text = GetComponent<Text> ();
	}
	
	void Update () {
        text.text = gameStats.points.ToString();
	}
}

