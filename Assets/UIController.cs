using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    //ゲームスタートテキスト
    private GameObject SongNameText;
    private GameObject AreYouReadyText;

    // ゲームオーバテキスト
    private GameObject gameOverText;
    private GameObject continueText;
    // ゲームオーバの判定
    private bool isGameOver = false;

    //


    // Use this for initialization
    void Start()
    {
        // シーンビューからオブジェクトの実体を検索する
        this.gameOverText = GameObject.FindWithTag("GameOverTag");
        this.continueText = GameObject.FindWithTag("TapAnywhereTag");
        this.SongNameText = GameObject.Find("SongName");
        this.AreYouReadyText = GameObject.Find("AreYouReady");
    }

    // Update is called once per frame
    void Update()
    {
        //スタート前
            if (Music.IsJustChangedAt(0, 0, 0))
            {
                this.SongNameText.GetComponent<Text>().text = "Song Name 夏の秘密基地";
            }
            if (Music.IsJustChangedAt(1, 3, 3))
            {
            Destroy(GameObject.Find("SongName"));
            }
            if (Music.IsJustChangedAt(2, 0, 0))
            {
                this.AreYouReadyText.GetComponent<Text>().text = "Are you ready?";
            }
            if (Music.IsJustChangedAt(4, 0, 0))
            {
            Destroy(GameObject.Find("AreYouReady"));
            }


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

    public void GameLoad()
    {
        // ゲームオーバになったときに、画面上にゲームオーバを表示する
        this.gameOverText.GetComponent<Text>().text = "GameOver!!";
        this.continueText.GetComponent<Text>().text = "Please Tap Anywhere";

        this.isGameOver = true;
    }

    public void GameOver()
    {
        // ゲームオーバになったときに、画面上にゲームオーバを表示する
        this.gameOverText.GetComponent<Text>().text = "GameOver!!";
        this.continueText.GetComponent<Text>().text = "Please Tap Anywhere";

        this.isGameOver = true;
    }

    //　スタートボタンを押したら実行する
    public void GameStart()
    {
        SceneManager.LoadScene("GameScene");
    }

    //フェードインスクリプト
    public class Fade : MonoBehaviour
    {
        public GameObject Panel;
        float a;

        void Start()
        {
            a = Panel.GetComponent<Image>().color.a;
        }

        //Aキーを押されたらフェード開始
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                StartCoroutine(FadePanel());
            }
        }

        //フェードアウト自体は↓の処理
        IEnumerator FadePanel()
        {
            while (a < 1)
            {
                Panel.GetComponent<Image>().color += new Color(0, 0, 0, 0.01f);
                a += 0.01f;
                yield return null;
            }
        }
    }
}
  