using UnityEngine;
using System.Collections;

public class gameScreen : MonoBehaviour {

    public GameObject player;

    // Use this for initialization
    void Start () {

        Instantiate(player, new Vector2(0, 0), Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
