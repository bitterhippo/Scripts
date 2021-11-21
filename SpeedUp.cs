﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
  [SerializeField]
  public float _speed = 3.0f;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    Movement();

    if (transform.position.y < -6.0f)
    {
      Destroy(gameObject);
    }
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Player")
    {
      Player player = other.transform.GetComponent<Player>();

      if (player != null)
      {
        Destroy(this.gameObject);
        player.UpdateSpeed();
      }
    }
  }

  private void Movement()
  {
    transform.Translate(Vector3.down * _speed * Time.deltaTime);

  }
}