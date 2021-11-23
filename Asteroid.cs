using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
  [SerializeField]
  private float _rotateSpeed = 19.0f;

  [SerializeField]
  private GameObject _player;
  [SerializeField]
  private GameObject _explosion;

  [SerializeField]
  private Spawn_Manager _spawnManager;
  // Start is called before the first frame update
  void Start()
  {
    _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<Spawn_Manager>();
  }

  // Update is called once per frame
  void Update()
  {
    transform.Rotate(Vector3.forward * _rotateSpeed * Time.deltaTime);
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Lazer")
    {
      Destroy(this.gameObject, 0.25f);
      Instantiate(_explosion, transform.position, Quaternion.identity);
      Destroy(other.gameObject);
      _spawnManager.StartSpawning();
    }
  }
}
