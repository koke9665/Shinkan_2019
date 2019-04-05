using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_X : MonoBehaviour {

    public GameObject Tama;
    public float Dansoku = 10f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        Tama.transform.Translate(Dansoku,1,0);
        Invoke("Destroy_Object",1f);
	}

    void Destroy_Object(){
        Destroy(Tama);
    }

    void OnTriggerEnter(Collider other)
      {

        if(other.CompareTag("Deth_Flont")){
        Destroy (Tama);
        }

      if(other.CompareTag("Enemy")){
     Destroy (Tama);
      }

      }

}
