using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuControl : MonoBehaviour
{
    public GameObject levels;
    // Start is called before the first frame update
    void Start()
    {
        levels.SetActive(false);
    }

    // Update is called once per frame
    public void ExitGame()
    {
        Application.Quit();
    }
    public void PlayButton()
    {
        levels.SetActive(true);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }public void LoadScene1()
    {
        SceneManager.LoadScene("level1");
    }
    public void LoadScene2()
    {
        SceneManager.LoadScene("level2");
    }
    public void LoadScene3()
    {
        SceneManager.LoadScene("level3");
    }public void LoadScene4()
    {
        SceneManager.LoadScene("level4");
    }
}
