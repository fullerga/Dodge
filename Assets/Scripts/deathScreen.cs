using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class deathScreen : MonoBehaviour {

    public  GameObject mainMenuButton;
    public GameObject playAgainButton;

    // Use this for initialization
    void Start () {

        Instantiate(mainMenuButton, new Vector3(0, -3, -1), Quaternion.identity);
        Instantiate(playAgainButton, new Vector3(0, -2, -1), Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {

    }
}
