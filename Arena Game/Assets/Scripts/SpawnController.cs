using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform parent;
    public float xBound = 1f;
    public float yBound = 1f;

    private void Start()
    {
        InvokeRepeating(nameof(spawnEnemy), 1f, 5f);
    }

    private void spawnEnemy()
    {
        // Spawn Slime
        Instantiate(enemies[0], transform.position, transform.rotation);

        // Change location of the spawner to a random location between two boundaries
        transform.position = new Vector2(Random.Range(-1, xBound), Random.Range(-1, yBound));
    }
}