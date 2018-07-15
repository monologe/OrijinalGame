using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    // ゲームオーバテキスト
    private GameObject gameOverText;
    private GameObject continueText;
    private GameObject HomeText;

    // ゲームオーバの判定
    private bool isGameOver = false;

    public bool isGame = false;


    // Use this for initialization
    void Start()
    { }

    // Update is called once per frame
    void Update()
    { }

    public void GameOver()
    {
        // シーンビューからオブジェクトの実体を検索する
        this.gameOverText = GameObject.FindWithTag("GameOverTag");
        this.continueText = GameObject.FindWithTag("TapAnywhereTag");
        this.HomeText = GameObject.FindWithTag("HomeTag");
        // ゲームオーバになったときに、画面上にゲームオーバを表示する
        this.gameOverText.GetComponent<Text>().text = "GameOver!!";
        this.continueText.GetComponent<Text>().text = "Retry?";
        this.HomeText.GetComponent<Text>().text = "Home?";

        this.isGameOver = true;
    }

    //　スタートボタンを押したら実行する
    public void GameStart()
    {
        SceneManager.LoadScene("GameScene");
        isGame = true;
    }

    public void Home()
    {
        SceneManager.LoadScene("SampleScene1");
        isGame = false;
    }

 
  