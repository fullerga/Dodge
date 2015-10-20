using UnityEngine;
using System.Collections;

public class mainMenuButton : MonoBehaviour {

    void OnMouseDown()
    {
		Application.LoadLevel("MainMenu");
    }
}
