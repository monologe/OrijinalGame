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

    // ゲームオーバの判定
    private bool isGameOver = false;

    // Use this for initialization
    void Start()
    {
        // シーンビューからオブジェクトの実体を検索する
        this.gameOverText = GameObject.FindWithTag("GameOverTag");
        this.continueText = GameObject.FindWithTag("TapAnywhereTag");

    }

    // Update is called once per frame
    void Update()
    {
        // ゲームオーバーになった場合
        if (this.isGameOver)
        {
            // クリックされたらシーンをロードする
            if (Input.GetMouseButtonDown(0))
            {
                //GameSceneを読み込む（追加）
                SceneManager.LoadScene("GameScene");
            }
        }
    }

    public void GameOver()
    {
        // ゲームオーバになったときに、画面上にゲームオーバを表示する
        this.gameOverText.GetComponent<Text>().text = "GameOver!!";
        this.continueText.GetComponent<Text>().text = "Please Tap Anywhere";

        this.isGameOver = true;
    }
}
