using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_4 : MonoBehaviour {

	public GameObject Bullet_Enter;
	public GameObject Enemy_Object;
	public GameObject Enemy_Bullet;
	public GameObject Enemy_Bullet2;
	public GameObject Rikabary;

	public GameObject Hit_Se_1;
	public GameObject Damege_Effect;

	public bool rikabary=true;
	GameObject Stage;
	public float Live_Time;
	public float attack_Time;
	public float kakuritu;
	public GameObject Player;
	public int jager = 2500;
	GameObject Bullet;
	GameObject Bullet2;
	GameObject Obj;
		GameObject Hit_Se_Obj;
	public 	GameObject Explotion_Se_Obj;


	// Use this for initialization
	void Start () {
		kakuritu = Random.Range(0f,6f);
		Stage = GameObject.FindGameObjectWithTag("Stage");
	}

	// Update is called once per frame
	void Update () {

		Live_Time += Time.deltaTime;

		if(jager<=0){
			Instantiate(Explotion_Se_Obj, this.transform.position, Quaternion.identity);
			Instantiate(Damege_Effect, this.transform.position, Quaternion.identity);

			Destroy (Enemy_Object);

			if(kakuritu<2){
			if(rikabary){
			Obj = (GameObject)Instantiate (Rikabary,new Vector3(this.transform.position.x + 0.1f,this.transform.position.y,this.transform.position.z), Quaternion.identity);
			Obj.transform.parent = Stage.transform;
			rikabary = false;
		}
	}
			Debug.Log("破壊！");
			Game_Master.Score = Game_Master.Score + 200;

		}

		if(Live_Time>0.05f){
			attack_Time = Random.Range(0f,11f);
			Live_Time=0;
			if(attack_Time<5){
			Bullet = (GameObject)Instantiate (Enemy_Bullet,new Vector3(this.transform.position.x + 0.1f,this.transform.position.y,this.transform.position.z), Quaternion.identity);
			Bullet.transform.parent = Stage.transform;
		}else if(attack_Time >5){
		Bullet2 = (GameObject)Instantiate (Enemy_Bullet2,new Vector3(this.transform.position.x + 0.1f,this.transform.position.y,this.transform.position.z), Quaternion.identity);
		Bullet2.transform.parent = Stage.transform;
	}
		}
	}

	void OnTriggerEnter(Collider other)
    {

 		if(other.CompareTag("Bullet")){

			jager = jager -15;

			Instantiate (Hit_Se_1,new Vector3(this.transform.position.x + 0.1f,this.transform.position.y,this.transform.position.z), Quaternion.identity);


 		}

		if(other.CompareTag("Bullet_Sp")){

			jager = jager -20;

			Instantiate (Hit_Se_1,new Vector3(this.transform.position.x + 0.1f,this.transform.position.y,this.transform.position.z), Quaternion.identity);

		}
		if(other.CompareTag("Bullet_Reiwa")){
			jager = jager -10000;
		}
		if(other.CompareTag("Player")){
		Player.active = false;
		}
		if(other.CompareTag("Deth")){
			Destroy(this.gameObject);
			Debug.Log("的破壊");
		}
		}

}
