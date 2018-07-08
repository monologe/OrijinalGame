using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameControllerbak : MonoBehaviour
{

    private GameObject player;
    private GameObject start;
    private GameObject gameOver;
    public static bool isPlaying;

    void Awake()
    {
        player = GameObject.Find("Player");
        start = GameObject.Find("Start");
        gameOver = GameObject.Find("GameOver");
    }

    void Start()
    {
        gameOver.SetActive(false);
        isPlaying = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            Application.LoadLevel("StageSample");
        }
    }

    public void GameStart()
    {
        start.SetActive(false);
        isPlaying = true;
    }
}

