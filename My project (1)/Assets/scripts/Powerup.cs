using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{

    // Powerup Ids:
    // 0 for TripleShot,
    // 1 for Speed,
    // and 2 for Shield.

    // Basic variables.
    [SerializeField]
    private float _speed = 3;
    [SerializeField]
    private int _PowerupId;

    // Update is called once per frame
    void Update()
    {
        // Move TripleShotPowerUp down.
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        // If TRipleShotPowerUp goes off-screen:
        // Destroy TripleShotPowerUp
        if (transform.position.y <= -5.5f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // If collider's tag is TripleShotPowerUp:
        if (other.tag == "player")
        {
            // Communicate with the player.
            player player = other.transform.GetComponent<player>();

            // If player exists:
            if (player != null)
            {
                switch (_PowerupId)
                {
                    // If Powerup is TripleShotPowerUp:
                    case 0:
                        // Enable TripleShot.
                        player.TripleShotActivate();

                        // Destroy this TripleShotPowerUp
                        Destroy(this.gameObject);

                        // Finish.
                        break;

                    // If Powerup is SpeedPowerup:
                    case 1:
                        // Activate Speed
                        player.SpeedActivate();

                        // Destroy this SpeedPowerup.
                        Destroy(this.gameObject);

                        // Finish.
                        break;

                    // If there is no Powerup:
                    // Let the console know.
                    default:
                        Debug.Log("False alarm, no Powerup here!");

                        // Finish.
                        break;
                }
            }
        }
    }
}