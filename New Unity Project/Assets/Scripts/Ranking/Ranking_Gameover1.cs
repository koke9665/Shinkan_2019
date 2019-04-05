using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCMB;

public class Ranking_Gameover1 : MonoBehaviour {

	// Use this for initialization
	void Start () {

		// クラスのNCMBObjectを作成
NCMBObject testClass = new NCMBObject("TestClass");

// オブジェクトに値を設定

testClass["message"] = "Welcome_reiwa";
// データストアへの登録
testClass.SaveAsync();

// Type == Number の場合

	}

	// Update is called once per frame
	void Update () {


	}

	public void OnClick() {
	Debug.Log("Button click!");
	naichilab.RankingLoader.Instance.SendScoreAndShowRanking (Game_Master.Score,0);
}
}
