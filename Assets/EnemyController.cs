using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //アニメーションするためのコンポーネントを入れる
    Animator animator;
    //Uniを移動させるコンポーネントを入れる
    Rigidbody2D rigid2D;

    //浮遊(通常)
    // 振幅
    public float amplitude = 0.01f;
    // フレームカウント
    private int frameCnt = 0;
    //浮遊判定
    public bool isfluff = false;

    public GameObject GameObject { get; private set; }




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

        //浮遊(通常)
        if (!isfluff)
        {
            frameCnt += 1;
            if (10000 <= frameCnt)
            {
                frameCnt = 0;
            }
            if (0 == frameCnt % 2)
            {
                // 上下に振動させる（ふわふわを表現）
                float posYSin = Mathf.Sin(2.0f * Mathf.PI * (float)(frameCnt % 200) / (200.0f - 1.0f));
                iTween.MoveAdd(gameObject, new Vector3(0, amplitude * posYSin, 0), 0.0f);
            }
        }
    }
    // 指定した小節、拍、ユニットに来たフレームで true になる
    public void escape()
    {
        if (Music.IsJustChangedAt(7, 2, 3))
        {
            GameObject = GameObject.Find("Uni");
            isfluff = true;
            iTween.MoveTo(this.gameObject, iTween.Hash("y", 5f));
        }

    }
}
