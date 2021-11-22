﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
  [SerializeField]
  private bool _isGameOver;

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.R) && _isGameOver == true)
    {
        SceneManager.LoadScene("Game");
    }
  }

  public void GameOver()
  {
    _isGameOver = true;
  }

}
