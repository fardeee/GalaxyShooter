using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Behavior variables.
    [SerializeField]
    private int _speed = 4;

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        //Move enemy down at a rate of 4 meters per second.
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        // If enemy y position <= -8.5.
        // Move enemy to (random x between -9.24 and 9.24, 7.5 y, z).
        if (transform.position.y <= -8.5f)
        {
            transform.position = new Vector3(Random.Range(-9.24f, 9.24f), 7.5f, transform.position.z);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // If other is Player:
        // Damage Player &
        // Destroy Enemy.
        if (other.tag == "player")
        {
            // Get player component
            player player = other.transform.GetComponent<player>();

            // If player exists
            // Damage Player.
            if (player != null)
            {
                player.Damage();
            }

            // Destroy Enemy.
            Destroy(this.gameObject);
        }
        
        // If other is Laser:
        // Destroy Laser &
        // Destroy Enemy.
        if (other.tag == "Laser")
        { 
            // Destroy Enemy.
            Destroy(this.gameObject);

            //Destroy Laser
            Destroy(other.gameObject);
        }
    }
}