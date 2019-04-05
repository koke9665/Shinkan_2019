using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour {

	public GameObject Enemy_Bullet1;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
Enemy_Bullet1.transform.Translate(-0.5f,0,0);
	}

	void OnTriggerEnter(Collider other)
		{

			if(other.CompareTag("Bullet_Sp")){
				Destroy(this.gameObject);
				Game_Master.Score = Game_Master.Score + 5;
			}

			if(other.CompareTag("Bullet_Reiwa")){
				Destroy(Enemy_Bullet1);
				Game_Master.Score = Game_Master.Score + 10;
			}

if(other.CompareTag("Player")){
Destroy(Enemy_Bullet1);
}

if(other.CompareTag("Deth")){
	Destroy(this.gameObject);
	Debug.Log("的破壊");
}


		}
}
