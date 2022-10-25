using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform center;
    public float dispacementAmount = .5f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, 5f);
    }

    private void SpawnEnemy()
    {
        // Spawn Slime prefab
        Instantiate(enemyPrefabs[0], transform.position, transform.rotation);

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