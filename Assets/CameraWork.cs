using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraWork : MonoBehaviour
{
    //Unityちゃんのオブジェクト
    private GameObject unitychan;
    //Unityちゃんとカメラの距離
    private Vector3 offset = Vector3.zero;

    // シーン開始時に一度だけ呼ばれる関数
    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.FindGameObjectWithTag("UnitychanTag");
        //Unityちゃんとカメラの位置の差を求める
        offset = transform.position - unitychan.transform.position;
    }

    // シーン中にフレーム毎に呼ばれる関数
    void LateUpdate()
    {
        if( unitychan != null)
        {
            Vector3 newPosition = transform.position;
            newPosition.x = unitychan.transform.position.x + offset.x;
            newPosition.z = unitychan.transform.position.z + offset.z;
            transform.position = newPosition;
        }
        
    }
}
