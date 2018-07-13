using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUnitychan : MonoBehaviour
{
    //アニメーションするためのコンポーネントを入れる
    Animator animator;
    //Unityちゃんを移動させるコンポーネントを入れる
    Rigidbody2D rigid2D;

    // 地面の位置
    private float groundLevel = -3.0f;

    // Use this for initialization
    void Start()

    {
        // アニメータのコンポーネントを取得する
        this.animator = GetComponent<Animator>();
        // 着地しているかどうかを調べる
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);
    }
}
