using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public Disappear arenaBreak;
    private State state;
    public enum State { IDLE, COMBAT, DEAD }

    void Start()
    {
        DetectFloor.playerDead += playerDead;
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
            case State.DEAD:
                Death();
                break;

            default:
                Debug.Log("There is no state called" + state);
                break;
        }
    }

    private void playerDead()
    {
        state = State.DEAD;
    }

    private void Death()
    {
        player.GetComponent<SpriteRenderer>().enabled = false;
        player.GetComponent<Movement>().enabled = false;
    }
}
