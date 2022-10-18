using UnityEngine;

public class DetectFloor : MonoBehaviour
{
    private bool onFloor = true;

    private void Update()
    {
        if (!onFloor)
        {
            Destroy(this.gameObject);
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
