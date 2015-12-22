using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class level : MonoBehaviour
{

    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = GameStats.level.ToString();
    }
}

