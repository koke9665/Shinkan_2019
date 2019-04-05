using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_End : MonoBehaviour {


	[SerializeField]
	Fade fade = null;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Jump")){
			// naichilab.RankingLoader.Instance.SendScoreAndShowRanking (200,0);
			 Fadeout();
			 Invoke("Sceneload",2F);
		}
	}
	void Fadeout()
	{
		fade.FadeIn (1, () =>
		{
		});
	}

	void Sceneload(){
		SceneManager.LoadScene("Title");
	}


}
