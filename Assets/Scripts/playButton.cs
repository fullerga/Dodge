using UnityEngine;
using System.Collections;

public class playButton : MonoBehaviour
{
    void OnMouseDown()
    {
		Application.LoadLevel("Level1");
    }
}
