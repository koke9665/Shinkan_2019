using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deth_Object : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other)
    {

 		if(other.CompareTag("Deth")){
			Destroy(this.gameObject);
			Debug.Log("的破壊");
 		}
		}
}
