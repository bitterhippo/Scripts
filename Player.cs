using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  // Start is called before the first frame update
  [SerializeField]
  private float _speed = 3.5f;
  [SerializeField]
  private GameObject _laserPrefab;
  [SerializeField]
  private GameObject _tripleShot;
  [SerializeField]
  private float _fireRate = 0.15f;
  private float _canFire = -1f;
  [SerializeField]
  private int _lives = 3;
  private Spawn_Manager _spawnManager;
  [SerializeField]
  private bool _shieldActive = false;

  [SerializeField]
  private GameObject _shieldPrefab;

  [SerializeField]
  private int _score = 0;

  private bool TripleShot = false;
  private UI_Manager _uiManager;


  void Start()
  {
    //Assign the starting position
    //Whatever current position is assign it to some kind of default.
    transform.position = new Vector3(0, 0, 0);
    _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<Spawn_Manager>();
    _uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();

    if (_spawnManager == null)
    {
      Debug.LogError("The Spawn Manager is NULL.");
    }

    if (_uiManager == null)
    {
      Debug.LogError("The UI Manager is NULL");
    }
  }

  // Update is called once per frame
  void Update()
  {
    CalculatedMovement();

    if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
    {
      ShootLaser();
    }
  }

  void CalculatedMovement()
  {
    float horizontalInput = Input.GetAxis("Horizontal");
    float verticalInput = Input.GetAxis("Vertical");

    transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * _speed * Time.deltaTime);

    transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0), 0);

    if (transform.position.x <= -11.0f)
    {
      transform.position = new Vector3(11.0f, transform.position.y, 0);
    }
    else if (transform.position.x >= 11.0f)
    {
      transform.position = new Vector3(-11.0f, transform.position.y, 0);
    }
  }

  void ShootLaser()
  {
    _canFire = Time.time + _fireRate;

    if (TripleShot)
    {
      Instantiate(_tripleShot, transform.position + new Vector3(0, 1.05f, 0), Quaternion.identity);
    }
    else
    {
      Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.05f, 0), Quaternion.identity);
    }
  }

  public void Damage()
  {
    if (_shieldActive != true)
    {
      _lives -= 1;
      _uiManager.UpdateLives(_lives);

      if (_lives < 1)
      {
        GameOverSequence();
      }
    }
  }

  void GameOverSequence()
  {
    _spawnManager.OnPlayerDeath();
    _uiManager.UpdateLives(_lives);
    _uiManager.GameOver();
    Destroy(this.gameObject);
  }
  
  public void UpdateWeapon()
  {
    TripleShot = true;
    StartCoroutine(TripleShotPowerDownRoutine());
  }

  IEnumerator TripleShotPowerDownRoutine()
  {
    yield return new WaitForSeconds(5.0f);
    TripleShot = false;
  }

  public void UpdateSpeed()
  {
    _speed = 10.0f;
    StartCoroutine(SpeedUpPowerDownRoutine());
  }

  IEnumerator SpeedUpPowerDownRoutine()
  {
    yield return new WaitForSeconds(10.0f);
    _speed = 3.5f;
  }

  public void UpdateShield()
  {
    _shieldActive = true;
    _shieldPrefab.SetActive(true);
    StartCoroutine(ShieldActivePowerDownRoutine());
  }

  IEnumerator ShieldActivePowerDownRoutine()
  {
    yield return new WaitForSeconds(5.0f);
    _shieldPrefab.SetActive(false);
    _shieldActive = false;
  }

  public void UpdateScore(int score)
  {
    _score += score;
    _uiManager.UpdateScore(_score);
  }
}
