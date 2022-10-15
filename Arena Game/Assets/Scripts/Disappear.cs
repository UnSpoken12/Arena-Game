using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Disappear : MonoBehaviour
{
    public float seconds = 5;


    void Start()
    {
        StartCoroutine(BreakGround());
    }

    IEnumerator BreakGround()
    {
        yield return new WaitForSeconds(seconds);
    }
}
