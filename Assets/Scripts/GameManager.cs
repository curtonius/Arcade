using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static int lives = 6;
    public static int HighScore = 0;
    public static int CurrentScore = 0;
    public int numberOfGames;
    public static GameManager current;
    public List<int> games = new List<int>();
    private List<int> gameHolder = new List<int>();
    public int currentGame = 0;
    public bool playing;

    GameManager()
    {
        current = this;
    }
    void Start()
    {
        for(int i=0; i<numberOfGames; ++i)
        {
            gameHolder.Add(i);
        }
        DontDestroyOnLoad(gameObject);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        ArrangeGames();
    }
    public void ArrangeGames()
    {
        for (int i = 0; i < numberOfGames; ++i)
        {
            int index = Random.Range(0, gameHolder.Count);
            games.Add(gameHolder[index]);
            gameHolder.RemoveAt(index);
        }
    }

    public void Die()
    {
        --lives;
        if(lives != 0)
            GetNextGame();
        else
        {
            playing = false;
            SceneManager.LoadScene(0);
        }
    }
    public void AddPoints(int points)
    {
        CurrentScore += points;
    }
    public void GetNextGame()
    {
        ++currentGame;
        if (currentGame == numberOfGames)
        {
            for(int i=0; i<numberOfGames; ++i)
        {
            gameHolder.Add(i);
        }
            ArrangeGames();
            currentGame = 0;
        }
        SceneManager.LoadScene(currentGame+1);
    }
    void Update()
    {
        if (Input.GetAxisRaw("Cancel") == 1)
        {
            //Die();
            GetNextGame();
        }
        if (playing) return;
        if (lives == 0 && CurrentScore > HighScore)
        {
            HighScore = CurrentScore;
            CurrentScore = 0;
        }
        if(Input.GetAxisRaw("Submit") == 1)
        {
            lives = 3;
            playing = true;
            SceneManager.LoadScene(1);
        }
    }
}
