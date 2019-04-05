using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver_result : MonoBehaviour {

	public int Reiwa_Nen;
	public float Score_result;
	public Text Score_Text;
	public Text PlayTime_Text;

	// Use this for initialization
	void Start () {

		Reiwa_Nen = Game_Master.Time2;
		Score_result = Game_Master.Score;
		Score_Text.text = ""+Reiwa_Nen;
		PlayTime_Text.text = ""+Score_result;

	}

	// Update is called once per frame
	void Update () {

	}
}
