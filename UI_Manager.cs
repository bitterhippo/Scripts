﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "Score: " + 50;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
