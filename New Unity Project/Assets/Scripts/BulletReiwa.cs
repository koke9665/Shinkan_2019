using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletReiwa : MonoBehaviour {

    public GameObject Tama;
    public float Dansoku = 10f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        Tama.transform.Translate(Dansoku,0,0);
        Invoke("Destroy_Object",5f);
	}

    void Destroy_Object(){
        Destroy(Tama);
    }

    void OnTriggerEnter(Collider other)
      {


      }

}
