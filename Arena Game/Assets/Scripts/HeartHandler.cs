using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartHandler : MonoBehaviour
{
    private int i = 2;
    private GameObject[] hearts;
    private float start = -2.25f;
    private float offset = .25f;

    // Start is called before the first frame update
    void Start()
    {
        // Sorts hearts from left to right
        hearts = new GameObject[i+1];
        foreach (GameObject heart in GameObject.FindGameObjectsWithTag("Heart"))
        {
            for (int j = 0; j <= i; j++)
            {
                if (hearts[j] == null)
                {
                    heart.GetComponent<Heart>().SetX(start + offset * j);
                    hearts[j] = heart;
                    break;
                }
            }
        }
    }

    // Update is called once per frame
    public void Damage()
    {
        hearts[i].GetComponent<Heart>().Die();
        i--;
    }
}
