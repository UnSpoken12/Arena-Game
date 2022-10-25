using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new(-2, -1, 0);

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset;
    }

    public void Die()
    {
        this.enabled = false;
        Destroy(this.gameObject);
    }
}
