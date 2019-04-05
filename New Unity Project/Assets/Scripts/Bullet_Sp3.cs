using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Sp3 : MonoBehaviour {

    public GameObject Tama;
    public float Dansoku = 0f;
    public float kyuu = 0;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        Tama.transform.Translate(Dansoku,kyuu,0);
        Invoke("Destroy_Object",1.5f);
	}

    void Destroy_Object(){
        Destroy(Tama);
    }

    void OnTriggerEnter(Collider other)
      {

        if(other.CompareTag("Deth_Flont")){
        Destroy (this.gameObject);
        }



      }

}
