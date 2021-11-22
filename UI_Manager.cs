using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
  [SerializeField]
  private Text _scoreText;
  [SerializeField]
  private Sprite[] _liveSprites;
  [SerializeField]
  private Image _LivesImg;
  [SerializeField]
  private Text _gameOver;
  // Start is called before the first frame update
  void Start()
  {
    _scoreText.text = "Score: " + 0;
  }

  public void UpdateScore(int score)
  {
    _scoreText.text = "Score: " + score.ToString();
  }

  public void UpdateLives(int livesLeft)
  {
      _LivesImg.sprite = _liveSprites[livesLeft];
  }

  public void GameOver()
  {
      _gameOver.text = "LOL NOOB";
  }
}
