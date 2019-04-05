using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Reiwa_Sp2 : MonoBehaviour {

    public GameObject Reiwa;
    public float Dansoku = 0f;
    public float kyuu = 0;

    private float Reiwa_sokudo = -1;
	// Use this for initialization
	void Start () {
    Dansoku = Random.Range(0f,1f);
    kyuu = Reiwa_sokudo + Dansoku;
	}

	// Update is called once per frame
	void Update () {
        Reiwa.transform.Translate(Dansoku,kyuu,0);
        Invoke("Destroy_Object",4f);
	}

    void Destroy_Object(){
        Destroy(Reiwa);
    }

    void OnTriggerEnter(Collider other)
      {

        if(other.CompareTag("Deth_Flont")){
        Destroy (this.gameObject);
        }



      }

}
