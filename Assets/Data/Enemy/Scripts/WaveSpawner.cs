using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies = new List<Enemy>();
    [Tooltip("This * wave number of enemies will spawn in the wave")]
    [SerializeField] private int _waveEnemyMultiplier;
    private int _currentWave;
    private List<GameObject> _enemiesToSpawn = new List<GameObject>();
    public readonly List<EnemyBase> _spawnedEnemies = new List<EnemyBase>();

    [SerializeField] Transform _spawnLocation;
    [SerializeField] int _maxWaveDuration;
    private int _totalWaveCost;
    private float _maxWaveTimer;
    private float _timeBetweenEachEnemySpawn;
    private float _timeToSpawnNewEnemy;
    private int _maxEnemiesInWave;
    void Start()
    {
        Events.EnemyDead += RemoveFromSpawnedEnemies;
        _currentWave = 1;
        UpdateWaveHUD();
        GenerateWave();
    }

    private void OnDisable()
    {
        Events.EnemyDead -= RemoveFromSpawnedEnemies;
    }
    // Update is called once per frame
    void Update()
    {
        if (_timeToSpawnNewEnemy < 0)
        {
            if (_enemiesToSpawn.Count > 0)
            {
                GameObject enemy = Instantiate(_enemiesToSpawn[0], _spawnLocation.position, Quaternion.identity);
                _enemiesToSpawn.RemoveAt(0);
                _spawnedEnemies.Add(enemy.GetComponent<EnemyBase>());
                _timeToSpawnNewEnemy = _timeBetweenEachEnemySpawn;
                UpdateZombieHUD();
            }
            else
            {
                _maxWaveTimer = 0;
            }
        }
        else
        {
            _timeToSpawnNewEnemy -= Time.fixedDeltaTime;
            _maxWaveTimer -= Time.fixedDeltaTime;
            UpdateZombieHUD();
        }
        //_max wave timer helps to keep the waves from ending abruptly
        // eg if i spawned the first enemy and then manage to kill it before a new one is spawned
        //it will be removed from spawn enemies list and if no wave timer is there assumed that the wave has ended
        if (_maxWaveTimer <= 0 && _spawnedEnemies.Count <= 0)
        {
            _currentWave++;
            GenerateWave();
            UpdateZombieHUD();
            UpdateWaveHUD();
        }
    }

    public void GenerateWave()
    {
        _totalWaveCost = _currentWave * _waveEnemyMultiplier;
        GenerateEnemies();
        _timeBetweenEachEnemySpawn = _maxWaveDuration / _enemiesToSpawn.Count;
        _maxWaveTimer = _maxWaveDuration;
        UpdateZombieHUD();
    }

    public void GenerateEnemies()
    {
        List<GameObject> generatedEnemies = new List<GameObject>();
        while (_totalWaveCost > 0)
        {
            int randomEnemy = Random.Range(0, _enemies.Count);
            int cost = _enemies[randomEnemy].cost;

            if (_totalWaveCost - cost >= 0)
            {
                generatedEnemies.Add(_enemies[randomEnemy]._enemyPrefab);
                _totalWaveCost -= cost;
            }
            else if (_totalWaveCost < 0)
                break;
        }
        _enemiesToSpawn.Clear();
        _enemiesToSpawn = generatedEnemies;
        _maxEnemiesInWave = _enemiesToSpawn.Count;
    }

    [System.Serializable]

    public class Enemy
    {
        public GameObject _enemyPrefab;
        public int cost;
    }

    public void RemoveFromSpawnedEnemies(EnemyBase enemy)
    {
        _spawnedEnemies.Remove(enemy);
        UpdateZombieHUD();
    }

    private void UpdateZombieHUD()
    {
        Events.UpdateZombieCount?.Invoke(_spawnedEnemies.Count, _maxEnemiesInWave);
    }
    private void UpdateWaveHUD()
    {
        Events.UpdateWaveCount?.Invoke(_currentWave);
    }
}
