using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet_3 : MonoBehaviour {

	public GameObject Enemy_Bullet1;
	public GameObject Bullet_Destroy_Effect;
	public GameObject Bullet_Destroy_Se;
	public float kakudo;
	// Use this for initialization
	void Start () {
kakudo=Random.Range(-0.2f,-2f);
	}

	// Update is called once per frame
	void Update () {

Enemy_Bullet1.transform.Translate(-0.5f,kakudo,0);
	}

	void OnTriggerEnter(Collider other)
		{
if(other.CompareTag("Player")){
Destroy(Enemy_Bullet1);
}

if(other.CompareTag("Bullet_Sp")){
	Destroy(this.gameObject);
	Instantiate(Bullet_Destroy_Effect, this.transform.position, Quaternion.identity);
	Instantiate(Bullet_Destroy_Se, this.transform.position, Quaternion.identity);
	Game_Master.Score = Game_Master.Score + 5;
}


if(other.CompareTag("Bullet_Reiwa")){
	Destroy(this.gameObject);
	Instantiate(Bullet_Destroy_Effect, this.transform.position, Quaternion.identity);
	Instantiate(Bullet_Destroy_Se, this.transform.position, Quaternion.identity);
	Game_Master.Score = Game_Master.Score + 10;
}

if(other.CompareTag("Deth")){
	Destroy(this.gameObject);
	Debug.Log("的破壊");
}


		}
}
