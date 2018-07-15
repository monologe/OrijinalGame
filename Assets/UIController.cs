using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    // ゲームオーバテキスト
    public GameObject gameOverText;
    public GameObject continueText;
    public GameObject HomeText;
    public GameObject StartText;

    // ゲームオーバの判定
    private bool isGameOver = false;

    public bool isGame = false;


    // Use this for initialization
    void Start()
    {
        ShowUI(false);
    }

    // Update is called once per frame
    void Update()
    { }

    public void GameOver()
    {
        ShowUI(true);
        this.isGameOver = true;
    }

    void ShowUI(bool isActive)
    {
        gameOverText.SetActive(isActive);
        continueText.SetActive(isActive);
        HomeText.SetActive(isActive);
    }


    //　スタートボタンを押したら実行する
    public void GameStart(bool isActive)
    {

        StartText.SetActive(isActive);
        SceneManager.LoadScene("GameScene");
        isGame = true;
    }

    public void Home()
    {
        SceneManager.LoadScene("SampleScene1");
        isGame = false;
    }

    public void Continue()
    {
        SceneManager.LoadScene("GameScene");
        isGame = true;
    }
}   