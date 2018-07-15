using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartScript : MonoBehaviour {
    
    //ゲームスタートテキスト
    private GameObject SongNameText;
    private GameObject AreYouReadyText;
    private GameObject SongNameSampleText;

    // Use this for initialization
    void Start () {
        this.SongNameText = GameObject.Find("SongName");
        this.AreYouReadyText = GameObject.Find("AreYouReady");
        this.SongNameSampleText = GameObject.Find("SongNameSample");
    }
	
	// Update is called once per frame
	void Update () {
        //スタート前
        if (Music.IsJustChangedAt(0, 0, 0))
        {
            this.SongNameText.GetComponent<Text>().text = "Song Name";
            this.SongNameSampleText.GetComponent<Text>().text = "Summer Secret Base";
            
        }
        if (Music.IsJustChangedAt(1, 3, 3))
        {
            Destroy(GameObject.Find("SongName"));
            Destroy(GameObject.Find("SongNameSample"));

        }
        if (Music.IsJustChangedAt(2, 0, 0))
        {
            this.AreYouReadyText.GetComponent<Text>().text = "Are you ready?";
        }
        if (Music.IsJustChangedAt(4, 0, 0))
        {
            Destroy(GameObject.Find("AreYouReady"));
        }
    }
}
