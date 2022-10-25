using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private float transitionTime = 1f;
    public Animator transition;

    public void StartGame()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void EndGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void BackToMenu()
    {
        StartCoroutine(LoadLevel(0));
    }

    public void Credits()
    {
        SceneManager.LoadScene(4);
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
