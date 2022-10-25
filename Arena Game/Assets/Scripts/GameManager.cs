using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;
    public ArenaGrounds arenaBreak;
    public int numOfKills = 0;
    private State state;
    public enum State { IDLE, DEAD, WIN }

    void Start()
    {
        DetectFloor.playerDead += playerDead;
        Movement.playerDead += playerDead;
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
                if (numOfKills == 12)
                {
                    state = State.WIN;
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
        //player.GetComponent<Movement>().enabled = false;
        Debug.Log("You win :)");
        SceneManager.LoadScene(3);
    }

    private void Death()
    {
        player.GetComponent<SpriteRenderer>().enabled = false;
        player.GetComponent<Movement>().enabled = false;
        Debug.Log("You died so sad :(");
        SceneManager.LoadScene(2);
        DetectFloor.playerDead -= playerDead;
        Movement.playerDead -= playerDead;
    }

    public void AddKill()
    {
        Debug.Log("hi");
        numOfKills += 1;
    }
}
