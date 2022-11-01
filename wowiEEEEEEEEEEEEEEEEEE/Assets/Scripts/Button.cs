using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public Transform point;

    private void Awake()
    {
        point = GameObject.Find("Point").GetComponent<Transform>();
    }

    public void ChangeMenuToTutorial()
    {
        point.position = new Vector3(18, 0, 0);
    }

    public void ChangeMenuToPlayMenu()
    {
        point.position = Vector3.zero;
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
