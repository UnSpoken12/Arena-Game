using UnityEngine;

public class DetectFloor : MonoBehaviour
{
    private bool onFloor = true;
    public delegate void PlayerDead();
    public static event PlayerDead playerDead;

    private void Update()
    {
        if (!onFloor)
        {
            playerDead?.Invoke();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Void"))
        {
            onFloor = false;
        }
    }
}
