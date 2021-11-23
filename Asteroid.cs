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
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    transform.Rotate(Vector3.forward * _rotateSpeed * Time.deltaTime);
  }

  private void OnTriggerEnter2D(Collider2d other)
  {
    Player player = other.transform.GetComponent<Player>();

    if (other.tag == player)
    {
      Vector3 currentLocation = new Vector3(0, 0, 0);
      GameObject newExplion = Instantiate(_explosion, currentLocation, Quaternion.identity);
      Destory(this.gameObject);
    }
  }
}
