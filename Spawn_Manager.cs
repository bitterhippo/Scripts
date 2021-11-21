using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
  [SerializeField]
  private GameObject _enemyPrefab;
  [SerializeField]
  private GameObject _tripleShotPrefab;

  [SerializeField]
  private GameObject _enemyContainer;

  [SerializeField]
  private bool _playerAlive = true;





  // Start is called before the first frame update
  void Start()
  {
      StartCoroutine(SpawnEnemeyRoutine());
      StartCoroutine(SpawnPowerUpRoutine());
  }

  // Update is called once per frame
  void Update()
  {

  }

  IEnumerator SpawnEnemeyRoutine()
  {

    while (_playerAlive)
    {
      Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
      GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
      newEnemy.transform.parent = _enemyContainer.transform;
      yield return new WaitForSeconds(0.5f);
    }
  }

  IEnumerator SpawnPowerUpRoutine()
  {
    while (_playerAlive)
    {
      Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
      GameObject newTripleShot = Instantiate(_tripleShotPrefab, posToSpawn, Quaternion.identity);
      yield return new WaitForSeconds(10.0f);
    }
  }

  public void OnPlayerDeath()
  {
      _playerAlive = false;
  }
}
