using System.Collections;
using UnityEngine;

public class PipeGenerator : ObjectPool
{
    [SerializeField]
    private GameObject _template;
    [SerializeField]
    private float _timeBetweenSpawn;
    [SerializeField]
    private float _maxSpawnPositionY;
    [SerializeField]
    private float _minSpawnPositionY;

    private void Start()
    {
        Initialize(_template);
        StartCoroutine(GeneratePipe());
    }

    private IEnumerator GeneratePipe()
    {
        while (Time.timeScale == 1)
        {
            yield return new WaitForSeconds(_timeBetweenSpawn);

            if (TryGetObject(out GameObject pipe))
            {
                float spawnPositionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);
                Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
                pipe.SetActive(true);
                pipe.transform.position = spawnPoint;

                DisableObjectAbroadScreen();
            }
        }
    }
}
