using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Disappear : MonoBehaviour
{
    [SerializeField]
    private float seconds = 5f;
    private float flashSeconds = .5f;
    public TilemapRenderer[] tilemap;

    void Start()
    {
        StartCoroutine(FlashFloor());
    }

    /* Flash indicator for when the floor starts disappearing
     * over an array of tilemaps 
     */
    IEnumerator FlashFloor()
    {
        bool flash = false;
        foreach (TilemapRenderer t in tilemap)
        {
            yield return new WaitForSeconds(seconds);
            for (int i = 0; i < 7; i++)
            {
                yield return new WaitForSeconds(flashSeconds);
                if (i % 2 == 0)
                {
                    flash = false;
                }
                else if (i % 2 == 1)
                {
                    flash = true;
                }
                t.enabled = flash;
            }
            t.tag = "Void";
            t.enabled = false;
        }
    }
}
