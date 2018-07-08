using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    // Use this for initialization
    void Start()
    {
        // アニメータのコンポーネントを取得する
        this.animator = GetComponent<Animator>();
        // Rigidbody2Dのコンポーネントを取得する
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //スタート表示


        //

        // xの正方向にscrollスピードで移動
        rigid2D.velocity = new Vector2(scroll, rigid2D.velocity.y);
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

        //画面外に出てゲームオーバー
        if (transform.position.y < this.deadLine)
        {
            // UIControllerのGameOver関数を呼び出して画面上に「GameOver」と表示する
            GameObject.FindWithTag("GameOverTag").GetComponent<UIController>().GameOver();
            // ユニティちゃんを破棄する
            Destroy(gameObject);
        }

        //障害物とぶつかってゲームオーバー
        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == "オブジェクト名")
            {
                Application.LoadLevel("gameover");
                GameObject.FindWithTag("GameOverTag").GetComponent<UIController>().GameOver();
            }
        }
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

  