using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningObjectController : MonoBehaviour
{
    [SerializeField]
    float speed = 50.0F;

    [SerializeField]
    int[] spawningPoints;

    Rigidbody2D _rb;
    SpawnManager _spawnManager;

    private void Start()
    {
        _spawnManager = SpawnManager.Instance;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb.velocity = Vector2.left * speed * Time.fixedDeltaTime * _spawnManager.GetSpeedMultiplier();
    }

    public int[] GetSpawningPoints()
    {
        return spawningPoints;
    }
}
