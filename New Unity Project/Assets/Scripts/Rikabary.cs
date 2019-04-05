using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rikabary : MonoBehaviour {

  public GameObject Tama;
	public float dansoku;
	public float kaihukuryou;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        Tama.transform.Translate(dansoku,0,0);
        Invoke("Destroy_Object",10f);
	}

    void Destroy_Object(){
        Destroy(Tama);
    }

    void OnTriggerEnter(Collider other)
      {

        if(other.CompareTag("Player")){

        Destroy (Tama);
        }

      }

}
