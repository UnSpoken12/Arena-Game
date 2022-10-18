using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    private Vector3 offset = new (0, 0, -10);

    private void Update()
    {
        transform.position = player.position + offset;
    }
}
