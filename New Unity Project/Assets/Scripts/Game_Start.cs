using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Start : MonoBehaviour {


	[SerializeField]
	Fade fade = null;

	public GameObject Start_Se;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Jump")){
			Start_Se.active = true;
			 Fadeout();
			 Invoke("Sceneload",2F);
		}
		if (Input.GetKey(KeyCode.Escape))UnityEngine.Application.Quit();;
	}
	void Fadeout()
	{
		fade.FadeIn (1, () =>
		{
		});
	}

	void Sceneload(){
		SceneManager.LoadScene("Main");
	}
}
