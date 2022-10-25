using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public Disappear arenaBreak;
    private State state;
    public enum State { IDLE, DEAD, WIN }

    void Start()
    {
        DetectFloor.playerDead += playerDead;
        SpawnController.winGame += WinGame;
        state = State.IDLE;
    }

    void Update()
    {
        switch (state)
        {
            case State.IDLE:
                if (Input.GetMouseButton(0))
                {
                    arenaBreak.enabled = true;
                }
                break;
            case State.WIN:
                Win();
                break;
            case State.DEAD:
                Death();
                break;
            default:
                Debug.Log("There is no state called" + state);
                break;
        }
    }

    private void WinGame()
    {
        state = State.WIN;
    }

    private void playerDead()
    {
        state = State.DEAD;
    }

    private void Win()
    {
        player.GetComponent<Movement>().enabled = false;
        Debug.Log("You win :)");
    }

    private void Death()
    {
        player.GetComponent<SpriteRenderer>().enabled = false;
        player.GetComponent<Movement>().enabled = false;
        Debug.Log("You died so sad :(");
        DetectFloor.playerDead -= playerDead;
    }
}
