using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UnitychanController : MonoBehaviour
{
    //アニメーションするためのコンポーネントを入れる
    Animator animator;
    //Unityちゃんを移動させるコンポーネントを入れる
    Rigidbody2D rigid2D;

    // 地面の位置
    private float groundLevel = -3.0f;

    public float scroll = 0.01f;

    //ジャンプの速度の減少
    private float dump = 1f;
    //ジャンプの速度
    float jumpVelocity = 20;

    // ゲームオーバになる位置
    private float deadLine = -9;

    //GameOverか判定
    public bool isGameOver = false;

    public UIController m_gameManager;

    // Use this for initialization
    void Start()
    {
        // アニメータのコンポーネントを取得する
        this.animator = GetComponent<Animator>();
        // Rigidbody2Dのコンポーネントを取得する
        this.rigid2D = GetComponent<Rigidbody2D>();
        //ロード
    }

    // Update is called once per frame
    void Update()
    {
        // xの正方向にscrollスピードで移動
        if (!isGameOver)
        {
            //移動
            rigid2D.velocity = new Vector2(scroll, rigid2D.velocity.y);
        }


        if (Music.IsJustChangedAt(0, 0, 0))
        {
            isGameOver = true;
        }

        if (Music.IsJustChangedAt(4, 0, 0))
        {
            isGameOver = false;
        }

        // 走るアニメーションを再生するために、Animatorのパラメータを調節する
        this.animator.SetFloat("Horizontal", 1f);
        // 着地しているかどうかを調べる
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);

        //ジャンプ操作
        // 着地状態でクリックされた場合
        if (Input.GetMouseButtonDown(0) && isGround)
            // 上方向の力をかける
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);

        //ウェイト操作(ボタンを押している間待機)
        if (Music.IsJustChangedAt(0, 0, 0))
        {
            isGameOver = true;
        }


        //画面外に出てゲームオーバー
        if (transform.position.y < this.deadLine)
        {
            // UIControllerのGameOver関数を呼び出して画面上に「GameOver」と表示する
            GameObject.FindWithTag("GameOverTag").GetComponent<UIController>().GameOver();
            isGameOver = true;
            this.animator.SetFloat("Horizontal", 0f);
            //BGMを止める
            GameObject.FindWithTag("BGMTag").GetComponent<AudioSource>().volume = 0;
            // ユニティちゃんを破棄する
            Destroy(gameObject);

        }
    }

    //障害物とぶつかってゲームオーバー
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "DamageObject")
        {
            // UIControllerのGameOver関数を呼び出して画面上に「GameOver」と表示する
            //GameObject.FindWithTag("GameOverTag").GetComponent<UIController>().GameOver();
            m_gameManager.GameOver();
            isGameOver = true;
            //BGMを止める
            GameObject.FindWithTag("BGMTag").GetComponent<AudioSource>().volume = 0;
            //ユニティちゃんを停止させる
            rigid2D.velocity = new Vector2(0, 0);
            GetComponent<Animator>().SetTrigger("Damage Layer");
            //タップでコンティニュー

        }
        if (collision.gameObject.name == "Uni")
        {
            // UIControllerのGameOver関数を呼び出して画面上にGameOver()を表示する
            //GameObject.FindWithTag("GameOverTag").GetComponent<UIController>().GameOver();
            m_gameManager.GameOver();
            //BGMを止める
            GameObject.FindWithTag("BGMTag").GetComponent<AudioSource>().volume = 0;
            isGameOver = true;
            //ユニティちゃんを停止させる
            rigid2D.velocity = new Vector2(0, 0);
            GetComponent<Animator>().SetTrigger("idleTrigger");

        }
    }



    public class SpeedController : MonoBehaviour
    {
        // speedを制御する
        public float speed = 10;

        void FixedUpdate()
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            Rigidbody rigidbody = GetComponent<Rigidbody>();

            // xとzにspeedを掛ける
            rigidbody.AddForce(x * speed, 0, y * speed);
        }


    }
}