using UnityEngine;
using System.Collections.Generic;

public class SpawnerBehaviour : MonoBehaviour
{
    public GameObject target;

    private float _nextSpawnTime = 0;
    private List<GameObject> _spawnedList = new List<GameObject>();

    private void FixedUpdate()
    {
        if (Time.time > _nextSpawnTime)
        {
            _nextSpawnTime = Time.time + Random.Range(3, 5);
            _spawnedList.Add(Instantiate(target, this.transform));
        }
    }

    public void Reset()
    {
        foreach (var gameObj in _spawnedList)
        {
            Destroy(gameObj);
        }

        _spawnedList.Clear();
        _nextSpawnTime = Time.time + Random.Range(3, 5);
    }
}
