using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform center;
    private float spawnTime = 12f;
    private float dispacementAmount = .3f;
    private int waves = 3;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnTime);
    }

    private void SpawnEnemy()
    {
        // Spawn Slime prefab
        if (waves > 0)
        {
            Instantiate(enemyPrefabs[0], transform.position, transform.rotation);
            waves--;
        }
        else if (waves <= 0)
        {
            this.enabled = false;
        }

        // Change location of the spawner to move closer to the center
        Vector2 currPos = transform.position;
        if (currPos.x < center.position.x)
        {
            transform.Translate(Vector2.right * dispacementAmount);
        }
        else if (currPos.x > center.position.x)
        {
            transform.Translate(Vector2.left * dispacementAmount);
        }
        if (currPos.y < center.position.y)
        {
            transform.Translate(Vector2.up * dispacementAmount);
        }
        else if (currPos.y > center.position.y)
        {
            transform.Translate(Vector2.down * dispacementAmount);
        }
    }
}