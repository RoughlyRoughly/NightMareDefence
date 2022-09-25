using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager i;

    bool isGameStart = false;
    public bool GAMESTART { get { return isGameStart; } }

    bool isGameOver = false;
    public bool GAMEOVER { get { return isGameOver; } }

    // Start is called before the first frame update
    void Start()
    {
        i = this;
        GameStart();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        isGameStart = true;
    }

    public void GameOver()
    {
        isGameOver = true;
    }
}
