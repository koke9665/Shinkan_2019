using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Generater : MonoBehaviour {

	public GameObject Stage;
	public GameObject Enemy_1;
	public GameObject Enemy_2;
	public GameObject Enemy_3;
	public GameObject Enemy_4;
	public GameObject Enemy_5;
	public float Game_Time;
	public float upper_Time;
	public float upper_Timing;
	public float upper_point_y=0;
	public float upper_point_x=0;
	GameObject Obj;
	GameObject Obj2;
	GameObject Obj3;
	GameObject Obj4;
	GameObject Obj5;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

		upper_Time += Time.deltaTime;
		Game_Time += Time.deltaTime;


		if(Game_Time<10){


		}else if(Game_Time<40f){

			if(upper_Time > 4f){
				upper_Time = 0;
				Stage_Chip_1();

				upper_Timing = Random.Range(0f,10f);

				if(upper_Timing < 6){
					Stage_Chip_2();

				}
				if(upper_Timing < 3 ){
					Stage_Chip_3();
					Stage_Chip_5();
				}

				if(upper_Timing < 1 ){
					Stage_Chip_4();
				}

			}
		}else if(Game_Time<80f){

			if(upper_Time > 3f){
				upper_Time = 0;
				Stage_Chip_1();

				upper_Timing = Random.Range(0f,10f);

				if(upper_Timing < 5){
					Stage_Chip_2();
				}

				if(upper_Timing < 4){
						Stage_Chip_3();
							Stage_Chip_5();
					}

					if(upper_Timing < 2){
							Stage_Chip_4();
						}

				}
			}else if(Game_Time<150f){

				if(upper_Time > 2f){
					upper_Time = 0;
					Stage_Chip_1();

					upper_Timing = Random.Range(0f,10f);
					if(upper_Timing < 5){
						Stage_Chip_2();
							Stage_Chip_5();
					}
					 if(upper_Timing < 3.5){
						Stage_Chip_3();
					}
					if(upper_Timing < 2){
					 Stage_Chip_4();
				 }

				}

			}else if(Game_Time<250f){

				if(upper_Time > 1f){
					upper_Time = 0;
					Stage_Chip_1();

					upper_Timing = Random.Range(0f,10f);
					if(upper_Timing < 7){
						Stage_Chip_2();
						Stage_Chip_5();
					}
					 if(upper_Timing < 5){
						Stage_Chip_3();
					}
					if(upper_Timing < 2){
					 Stage_Chip_4();
				 }

				}
			}else if(Game_Time<5000f){

				if(upper_Time > 0.5f){
					upper_Time = 0;
					Stage_Chip_1();

					upper_Timing = Random.Range(0f,10f);
					if(upper_Timing < 6){
						Stage_Chip_2();
						Stage_Chip_5();
					}
					 if(upper_Timing < 5){
						Stage_Chip_3();
					}
					if(upper_Timing < 2){
					 Stage_Chip_4();
				 }

				}
			}
	}

	void Stage_Chip_1(){
		upper_point_y = Random.Range(-39f,39f);
		upper_point_x = Random.Range(-15f,25f);
		Obj = (GameObject)Instantiate (Enemy_1, new Vector3(this.transform.position.x + upper_point_x,upper_point_y,this.transform.position.z), Quaternion.identity);
		Obj.transform.parent = Stage.transform;
	}
	void Stage_Chip_2(){
		upper_point_y = Random.Range(-39f,39f);
		upper_point_x = Random.Range(-15f,25f);
		Obj2 = (GameObject)Instantiate (Enemy_2, new Vector3(this.transform.position.x + upper_point_x,upper_point_y,this.transform.position.z), Quaternion.identity);
		Obj2.transform.parent = Stage.transform;
	}
	void Stage_Chip_3(){
		upper_point_y = Random.Range(-39f,39f);
		upper_point_x = Random.Range(-15f,25f);
		Obj3 = (GameObject)Instantiate (Enemy_3, new Vector3(this.transform.position.x + upper_point_x,upper_point_y,this.transform.position.z), Quaternion.identity);
		Obj3.transform.parent = Stage.transform;
	}
	void Stage_Chip_4(){
		upper_point_y = Random.Range(-5f,30f);
		Obj4 = (GameObject)Instantiate (Enemy_4, new Vector3(this.transform.position.x,upper_point_y-25,this.transform.position.z), Quaternion.identity);
		Obj4.transform.parent = Stage.transform;
	}
	void Stage_Chip_5(){
		upper_point_y = Random.Range(-39f,39f);
		upper_point_x = Random.Range(-15f,25f);
		Obj4 = (GameObject)Instantiate (Enemy_5, new Vector3(this.transform.position.x + upper_point_x,upper_point_y,this.transform.position.z), Quaternion.identity);
		Obj4.transform.parent = Stage.transform;
	}

}
