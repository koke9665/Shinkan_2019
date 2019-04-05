using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCMB;

public class Ranking_Test : MonoBehaviour {

	// Use this for initialization
	void Start () {

		// クラスのNCMBObjectを作成
NCMBObject testClass = new NCMBObject("TestClass");

// オブジェクトに値を設定

testClass["message"] = "Welcome_reiwa";
// データストアへの登録
testClass.SaveAsync();

// Type == Number の場合

naichilab.RankingLoader.Instance.SendScoreAndShowRanking (10);

	}

	// Update is called once per frame
	void Update () {


	}
}
