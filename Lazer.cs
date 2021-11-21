﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
  [SerializeField]
  private float _speed = 8.0f;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    transform.Translate(Vector3.up * _speed * Time.deltaTime);

    //If the translate.position.y > 8 ? delete object : nothing
    if (transform.position.y > 8f)
    {
      if (transform.parent != null)
      {
        Destroy(transform.parent.gameObject);
      }
      Destroy(gameObject);
    }
  }
}
