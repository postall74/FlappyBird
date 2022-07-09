using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : ObjectPool
{
    [SerializeField] private List<GameObject> _tamplates;
    [SerializeField] private float _secondsBetweenSpawn = 2.5f;
    [SerializeField] private float _maxSpawnPositionY;
    [SerializeField] private float _minSpawnPositionY;

    private float _elepsedTime = 0f;

    private void Start()
    {
        foreach (var item in _tamplates)
        {
            Initialize(item);
        }
    }

    private void Update()
    {
        _elepsedTime += Time.deltaTime;

        for (int i = 0; i < _tamplates.Count; i++)
        {
            if (_elepsedTime > _secondsBetweenSpawn)
            {
                if (TryGetObject(out GameObject obstacle))
                {
                    _elepsedTime = 0;

                    float spawnPositionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);
                    Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

                    obstacle.SetActive(true);
                    obstacle.transform.position = spawnPoint;

                    DisableObjectAbroadScreen();
                }
            }
        }
    }
}
