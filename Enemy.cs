using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _movementSpeed = 4.0f;
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

        if (other.tag == "Player") 
        {
            Player player = other.transform.GetComponent<Player>();
            
            if (player != null)
            {
                player.Damage();
            }

            Destroy(this.gameObject);
        }

        if (other.tag == "Lazer")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
