using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Nessesarry variables
    [SerializeField]
    private GameObject _EnemyPrefab;
    [SerializeField]
    private GameObject _EnemyContainer;
    private IEnumerator _coroutine;
    private bool _StopSpawning = false;
    [SerializeField]
    private GameObject[] _Powerups;

    // Start is called before the first frame update
    void Start()
    {
        // Start enemy spawn system.
        _coroutine = EnemySpawnRoutine();
        StartCoroutine(_coroutine);

        //start TripleShotPowerUp spawn sytstem.
        StartCoroutine(PowerUpSpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Spawn Enemy every second
    IEnumerator EnemySpawnRoutine()
    {
        while (_StopSpawning == false)
        {
            // Spawn Enemy at (random x, 7.5 y, 0);
            GameObject NewEnemy = Instantiate(_EnemyPrefab, new Vector3(Random.Range(-9.24f, 9.24f), 7.5f, 0), Quaternion.identity);
            NewEnemy.transform.parent = _EnemyContainer.transform;
            // Wait 1 second.
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator PowerUpSpawnRoutine()
    {
        while (_StopSpawning == false)
        {
            int RandomPowerup = Random.Range(0, 2);

            // Spawn TripleShotPowerUp.
            Instantiate(_Powerups[RandomPowerup], new Vector3(Random.Range(-9, 9), 8, 0), Quaternion.identity);

            // Wait 3-7 seconds.
            yield return new WaitForSeconds(Random.Range(10, 15));
        }
    }

    // Stop spawning function.
    public void OnPlayerDeath()
    {
        _StopSpawning = true;
    }
}