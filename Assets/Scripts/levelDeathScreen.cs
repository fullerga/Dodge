using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class levelDeathScreen : MonoBehaviour {

    private Text text;

    void Start()
    {
        text = GetComponent<Text>();

        text.text = GameStats.level.ToString();
    }
}
