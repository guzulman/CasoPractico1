using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    [SerializeField]
    Transform[] spawningObjects;

    [SerializeField]
    Transform[] spawningPoints;

    [SerializeField]
    float timebetweenSpawn = 5.0F;

    float _currentTime;
    float _speedMultiplier;

    bool _spawningEnabled = true; // Variable para controlar el spawning


    private void Start()
    {   
        _currentTime = timebetweenSpawn;

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

    }

    private void Update()
    {
        if (!_spawningEnabled) return; // Si el spawning está desactivado, no hacer nada

        _currentTime += Time.deltaTime;

        _speedMultiplier += Time.deltaTime * 0.1F;

        if (_currentTime >= timebetweenSpawn)
        {
            _currentTime = 0.0F;

            int spawningIndex = Random.Range(0, spawningObjects.Length);
            Transform prefab = spawningObjects[spawningIndex];

            SpawningObjectController controller = prefab.GetComponent<SpawningObjectController>();
            int[] spawningPoints = controller.GetSpawningPoints();
            spawningIndex = spawningPoints[Random.Range(0, spawningPoints.Length)];

            foreach (Transform point in this.spawningPoints)
            {
                if (point.gameObject.name.Equals("Point" + spawningIndex.ToString()))
                {
                    Instantiate(prefab, point.position, Quaternion.identity);
                    break;
                }
            }
        }
    }

    public float GetSpeedMultiplier()
    {
        return _speedMultiplier;
    }

    public void StopSpawning()
    {
        _spawningEnabled = false;
    }
}
