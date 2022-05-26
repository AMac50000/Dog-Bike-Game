using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    private static GameManagerScript _instance;

    public static GameManagerScript Instance { get { return _instance; } }

    [SerializeField] int startingLives;

    int score, lives;

    GameObject player;
    [SerializeField] GameObject GameOverUI;
    List<GameObject> Hearts = new List<GameObject>();



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

    private void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        GameOverUI.SetActive(false);
        lives = startingLives;
        foreach (GameObject heart in GameObject.FindGameObjectsWithTag("Heart"))
        {

            Hearts.Add(heart);
        }
    }

    private void Update()
    {
        if(lives <= 0)
        {
            GameOver();
        }

        //Debug Statment remove for full release
        if (Input.GetKeyDown(KeyCode.L))
        {
            LooseLife();
        }
    }
    public void AddScore(int lScore)
    {
        score += lScore;
    }

    public int GetScore()
    {
        return score;
    }

    public void LooseLife()
    {
        lives -= 1;
        Debug.Log(lives);
        Hearts[lives].SetActive(false);
    }

    public void AddLives(int lLives)
    {
        if(lives <= 3)
        {
            lives += lLives;
        }
        Hearts[lives-1].SetActive(true);
    }

    public void RemoveLives(int lLives)
    {
        lives -= lLives;
    }

    public int GetLives()
    {
        return lives;
    }

    public void GameOver()
    {
        GameObject.Destroy(player);
        GameOverUI.SetActive(true);
    }
}
