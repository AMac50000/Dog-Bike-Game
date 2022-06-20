using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    private static SceneManagerScript _instance;

    public static SceneManagerScript Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    public void Title()
    {
        SceneManager.LoadScene("Title Scene");
    }

    public void Level1Act1()
    {
        SceneManager.LoadScene("Level1 Act1");
    }

    public void Level1Act2()
    {
        SceneManager.LoadScene("Level1 Act2");
    }

    public void Level2Act1()
    {
        SceneManager.LoadScene("Level2 Act1");
    }


    public void Level2Act2()
    {
        SceneManager.LoadScene("Level2 Act2");
    }


    public void Level3Act1()
    {
        SceneManager.LoadScene("Level3 Act1");
    }

    public void Level3Act2()
    {
        SceneManager.LoadScene("Level3 Act2");
    }

    public void Level4Act1()
    {
        SceneManager.LoadScene("Level4 Act1");
    }

    public void Level4Act2()
    {
        SceneManager.LoadScene("Level4 Act2");
    }


    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
