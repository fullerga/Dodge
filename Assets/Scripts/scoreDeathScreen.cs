﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoreDeathScreen : MonoBehaviour {

    private Text text;

    void Start()
    {
        text = GetComponent<Text>();

        text.text = GameStats.points.ToString();
    }
}
