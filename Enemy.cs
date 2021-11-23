using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  [SerializeField]
  private float _movementSpeed = 4.0f;

  private Player _player;
  private Animator _anim;
  // Start is called before the first frame update
  void Start()
  {
    _player = GameObject.Find("Player").GetComponent<Player>();

    if (_player == null)
    {
      Debug.LogError("@Enemy.cs > _player = null");
    }

    _anim = GetComponent<Animator>();

    if (_anim == null)
    {
      Debug.LogError("@Enemy.cs > _anim = null");
    }
  }

  // Update is called once per frame
  void Update()
  {
    Movement();

    if (transform.position.y < -6.0f)
    {
      float randomX = Random.Range(-8.0f, 8.0f);
      transform.position = new Vector3(randomX, 7, 0);
    }
  }

  void Movement()
  {
    transform.Translate(Vector3.down * _movementSpeed * Time.deltaTime);
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    Player player = other.transform.GetComponent<Player>();

    if (other.tag == "Player")
    {

      if (player != null)
      {
        player.Damage();
      }
      _anim.SetTrigger("OnEnemyDeath");
      _movementSpeed = 0;
      Destroy(this.gameObject, 2.8f);
    }

    if (other.tag == "Lazer")
    {
      Destroy(other.gameObject);
      if (_player != null)
      {
        _player.UpdateScore(10);
      }
      _anim.SetTrigger("OnEnemyDeath");
      _movementSpeed = 0;
      Destroy(this.gameObject, 2.8f);
    }
  }
}
