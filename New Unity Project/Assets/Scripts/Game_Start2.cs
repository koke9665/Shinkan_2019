using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Start2 : MonoBehaviour {


	[SerializeField]
	Fade fade = null;

	// Use this for initialization
	void Start () {
		Fadeout();
	}

	// Update is called once per frame
	void Update () {



	}
	void Fadeout()
	{
		fade.FadeIn (1, () =>
		{

		});
	}


}
