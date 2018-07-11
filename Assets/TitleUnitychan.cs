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

    // Use this for initialization
    void Start () 

    {
    // アニメータのコンポーネントを取得する
    this.animator = GetComponent<Animator>();
    }

		
	
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("GameScene");
            }	
	}
}


