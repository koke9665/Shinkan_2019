using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Test : MonoBehaviour {

	public GameObject Stage;
	public GameObject Enemy_1;

	public float Game_Time;
	public float upper_Time;
	public float upper_Timing;
	public float upper_point_y=0;
	public float upper_point_x=0;
	GameObject Obj;


	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {



		upper_Time += Time.deltaTime;
		Game_Time += Time.deltaTime;


	if(Game_Time<90f){

			if(upper_Time > 4f){
				upper_Time = 0;
				Stage_Chip_1();

			}
		}
			}


	void Stage_Chip_1(){
		Obj = (GameObject)Instantiate (Enemy_1, new Vector3(this.transform.position.x + upper_point_x,upper_point_y,this.transform.position.z), Quaternion.identity);
		Obj.transform.parent = Stage.transform;
	}


}
