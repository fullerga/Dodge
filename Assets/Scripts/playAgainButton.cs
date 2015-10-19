using UnityEngine;
using System.Collections;

public class playAgainButton : MonoBehaviour {

	void OnMouseDown()
    {
		Application.LoadLevel("Level1");
    }
}
