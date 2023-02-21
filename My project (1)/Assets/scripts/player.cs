using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
   // player variables
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private GameObject _LaserPrefab;
    [SerializeField]
    private float _FireRate = 0.15f;
    private float _CanFire = -1f;
    [SerializeField]
    private int _Lives = 3;
    SpawnManager _SpawnManager;
    private bool _TripleShotActive = false;
    [SerializeField]
    private GameObject _TripleShotPrefab;
    private bool _ShieldsActive = false;
    [SerializeField]
    private GameObject _ShieldVisual;
    private int _score = 0;
    private UiManager _UiManager;

// Start is called before the first frame update
void Start()
    {
        // take current pos and assign new pos (0, 0, 0)
        transform.position = new Vector3(0, 0, 0);

        // Find the SpawnManager.
        _SpawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        // Find the UiManager.
        _UiManager = GameObject.Find("Canvas").GetComponent<UiManager>();

        // If Spawn Manager is null:
        // Error
        if (_SpawnManager == null)
        {
            Debug.LogError("The SpawnManager is null.");
        }

        if (_UiManager == null)
        {
            Debug.LogError("The UiManager is null.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        FireLaser();
    }
    
    void FireLaser()
    {
        // Spawn laser with a 0.15 second cooldown.
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= _CanFire)
        {
            // Calculate cooldown.
            _CanFire = Time.time + _FireRate;

            // If _TripleShotActive = true:
            // Fire TripleShot.
            if (_TripleShotActive == true)
            {
                Instantiate(_TripleShotPrefab, new Vector3(transform.position.x - 0.47f, transform.position.y + 1.01f, transform.position.z), Quaternion.identity);
            }
            else
            {
                // Spawn laser.
                Instantiate(_LaserPrefab, new Vector3(transform.position.x, transform.position.y + 1.05f, transform.position.z), Quaternion.identity);
            }
        }
    }
    void CalculateMovement () 
    {
        // movement
        float horizontal_input = Input.GetAxis("Horizontal");
        float vertical_input = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * horizontal_input * _speed * Time.deltaTime);
        transform.Translate(Vector3.up * vertical_input * _speed * Time.deltaTime);

        // player restraints
        if (transform.position.y >= 0) 
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y <=-4) 
        {
            transform.position = new Vector3(transform.position.x, -4, 0);
        }
        if (transform.position.x >= 9.24f) 
        {
            transform.position = new Vector3(9.24f, transform.position.y, 0);
        }
        else if (transform.position.x <= -9.24f) 
        {
            transform.position = new Vector3(-9.24f, transform.position.y, 0);
        }
    }

    public void Damage()
    {
        // If Shields are active:
        if (_ShieldsActive == true)
        {
            // Disable shields.
            _ShieldsActive= false;

            // Disable ShieldVisual.
            _ShieldVisual.SetActive(false);

            // Stop damage function.
            return;
        }
        // _Lives - 1
        _Lives -= 1;

        // If Lives is == 0:
        if (_Lives == 0)
        {
            // Call OnPlayerDeath function.
            _SpawnManager.OnPlayerDeath();

            //Destroy PLayer.
            Destroy(this.gameObject);
        }
    }

    public void TripleShotActivate()
    {
        // Enable TripleShot.
        _TripleShotActive = true;

        // Start TripleShotPowerDownRoutine
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    IEnumerator TripleShotPowerDownRoutine()
    {
        // Wait 5 seconds.
        yield return new WaitForSeconds(5);

        // Disable TripleShot.
        _TripleShotActive= false;
    }

    public void SpeedActivate()
    {
        // Enable speed.
        _speed = 6.5f;

        // Start SpeedPowerDownRoutine.
        StartCoroutine(SpeedPowerDownRoutine());
    }

    IEnumerator SpeedPowerDownRoutine()
    {
        // Wait 5 seconds.
        yield return new WaitForSeconds(5);

        // Disable speed.
        _speed = 3.5f;
    }

    public void ShieldsActivate()
    {
        // Turn on shields.
        _ShieldsActive= true;

        // Enable ShieldVisual.
        _ShieldVisual.SetActive(true);
    }

    public void AddScore(int points)
    {
        // Add 100 to score.
        _score += points;
        _UiManager.UpdateScore(_score);
    }
} 