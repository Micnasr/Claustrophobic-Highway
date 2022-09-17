using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public GameObject tutorialmenu;

    void Start()
    {
        tutorialmenu.SetActive(false);
    }
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Tutorial()
    {
        tutorialmenu.SetActive(true);
    }

    public void Back()
    {
        tutorialmenu.SetActive(false);
    }
}
