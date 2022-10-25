using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartHandler : MonoBehaviour
{
    private int i = 2;
    private GameObject[] hearts;

    // Start is called before the first frame update
    void Start()
    {
        // Sorts hearts from left to right
        hearts = new GameObject[i+1];
        foreach (GameObject heart in GameObject.FindGameObjectsWithTag("Heart"))
        {
            GameObject next = heart;
            GameObject temp;
            for (int j = 0; j <= i; j++)
            {
                if (hearts[j] == null)
                {
                    hearts[j] = next;
                    break;
                }
                else if (hearts[j].transform.position.x > next.transform.position.x)
                {
                    temp = hearts[j];
                    hearts[j] = next;
                    next = temp;
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
