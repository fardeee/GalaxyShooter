using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Laser behavior variables
    [SerializeField]
    private int _speed = 8;

    // Update is called once per frame
    void Update()
    {
        // Move laser.
        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        // If laser y position is greater than 8:
        if (transform.position.y >= 8)
        {
            // If Laser has a parent:
            if (transform.parent != null)
            {
                // Destroy the parent & Laser.
                Destroy(transform.parent.gameObject);
            }
            else
            {
                // Destroy the laser.
                Destroy(this.gameObject);
            }
        }
    }
}