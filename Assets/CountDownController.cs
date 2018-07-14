using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownController : MonoBehaviour
{
    //カウントダウンスクリプト
    public GameObject CountdownText;
    public float totalTime;
    int seconds;

    //カウントダウン判定
    public bool isCount = false;

    // Use this for initialization
    void Start()
    {
        this.CountdownText = GameObject.Find("Countdown");
    }

    // Update is called once per frame
    void Update()
    {
        //カウントダウンスクリプト
        if (isCount)
        {
            totalTime -=  2 * Time.deltaTime;
            seconds = (int)totalTime;
            this.CountdownText.GetComponent<Text>().text = seconds.ToString();
            if (totalTime <= 1)
            {
                //ここに処理
                Destroy(gameObject);
            }
        }

        if (Music.IsJustChangedAt(3, 1, 0))
        {
            isCount = true;
        }
    }
    

}