using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public GameObject Bullet_Enter;
	public GameObject Enemy_Object;
	public GameObject Enemy_Bullet;
	public GameObject Stage;

	public GameObject Hit_Se_1;
	public GameObject Damege_Effect;

	public float Live_Time;
	public GameObject Player;
	public int jager = 100;
	GameObject Bullet;
	GameObject Hit_Se_Obj;
	public GameObject Explotion_Se_Obj;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		Live_Time += Time.deltaTime;

		if(jager<=0){
			Instantiate(Explotion_Se_Obj, this.transform.position, Quaternion.identity);
			Instantiate(Damege_Effect, this.transform.position, Quaternion.identity);

			Destroy (Enemy_Object);
			Debug.Log("破壊！");
			Game_Master.Score = Game_Master.Score + 10;
		}

		if(Live_Time>3){
			Live_Time = 0;
			Bullet = (GameObject)Instantiate (Enemy_Bullet,new Vector3(this.transform.position.x + 0.1f,this.transform.position.y,this.transform.position.z), Quaternion.identity);
			Bullet.transform.parent = Stage.transform;
		}
	}

	void OnTriggerEnter(Collider other)
    {

 		if(other.CompareTag("Bullet")){

			jager = jager -15;
			Hit_Se_Obj = (GameObject)Instantiate (Hit_Se_1,new Vector3(this.transform.position.x + 0.1f,this.transform.position.y,this.transform.position.z), Quaternion.identity);
			Hit_Se_Obj.transform.parent = Stage.transform;


 		}

		if(other.CompareTag("Bullet_Sp")){
			jager = jager -20;

			Hit_Se_Obj = (GameObject)Instantiate (Hit_Se_1,new Vector3(this.transform.position.x + 0.1f,this.transform.position.y,this.transform.position.z), Quaternion.identity);
			Hit_Se_Obj.transform.parent = Stage.transform;


		}

		if(other.CompareTag("Bullet_Sp2")){
			jager = jager -15;

			Hit_Se_Obj = (GameObject)Instantiate (Hit_Se_1,new Vector3(this.transform.position.x + 0.1f,this.transform.position.y,this.transform.position.z), Quaternion.identity);
			Hit_Se_Obj.transform.parent = Stage.transform;


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
