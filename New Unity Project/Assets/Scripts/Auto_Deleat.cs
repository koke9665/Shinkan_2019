using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto_Deleat : MonoBehaviour {

	public float Count;
	public GameObject Sound;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Count += Time.deltaTime;
		if(Count>3){

			Debug.Log("Se消去");
			Destroy(Sound);
		}
	}
}
