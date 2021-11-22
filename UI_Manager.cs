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
  [SerializeField]
  private Text _restart;
  private Game_Manager _gameManager;
  // Start is called before the first frame update
  void Start()
  {
    _scoreText.text = "Score: " + 0;
    _gameManager = GameObject.Find("Game_Manager").GetComponent<Game_Manager>();

    if (_gameManager == null)
    {
        Debug.LogError("Game Manager is NULL");
    }
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
      _gameManager.GameOver();
      _gameOver.text = "LOL NOOB";
      _restart.text = "Press the 'R' key to restart";
  }

  public void Restart()
  {
      _gameOver.text = "";
      _restart.text = "";
  }
}
