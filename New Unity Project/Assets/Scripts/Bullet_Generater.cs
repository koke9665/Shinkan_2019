using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Generater : MonoBehaviour {

    public GameObject Bullet_1;
    public GameObject Bullet_SP3;
    public GameObject Bullet_SP4;
    public GameObject Bullet_X;
    public GameObject Bullet_X2;
    public GameObject Bullet_Sp;
    public GameObject Bullet_Sp2;
    public GameObject Bullet_Reiwa;
    public GameObject Player;
    public GameObject Shot_Se;
    public GameObject Reiwa_Canon;
    public GameObject Reiwa_Canon_SP;
    public GameObject Reiwa_Canon_SP2;
    public GameObject Reiwa_Canon_SP_Timeline;
    public GameObject Reiwa_Canon_Kora;
    public float Delay;
    public static bool Sp_Use=false;
    public Animator Camera;


    // Use this for initialization
    void Start () {

	}

	// Update is called once per frame
	void Update () {
    if(Player_Move.Player_Move_On == true){
        if (Input.GetKey(KeyCode.Z))
        {
          Camera.SetBool("Sp_Use",false);
          Shot_Se.active = true;
            Sp_Use= false;
            Instantiate(Bullet_1, new Vector3(this.transform.position.x,this.transform.position.y + 1 ,this.transform.position.z), Quaternion.identity);
            Instantiate(Bullet_1, this.transform.position, Quaternion.identity);
            Instantiate(Bullet_1, new Vector3(this.transform.position.x,this.transform.position.y - 1 ,this.transform.position.z), Quaternion.identity);

        }else if (Input.GetKey(KeyCode.X))
        {
          Camera.SetBool("Sp_Use",false);
          Shot_Se.active = true;

            Sp_Use= false;
            Instantiate(Bullet_X, this.transform.position, Quaternion.identity);
            Instantiate(Bullet_1, this.transform.position, Quaternion.identity);
            Instantiate(Bullet_X2, this.transform.position, Quaternion.identity);
        }else if(Input.GetKey(KeyCode.V)&&Game_Master.PlayerLife_Gage>0){

          Camera.SetBool("Sp_Use",true);
          Shot_Se.active = true;

          Game_Master.PlayerLife_Gage = Game_Master.PlayerLife_Gage - 2.5f;
          Sp_Use = true;
          Instantiate(Bullet_Sp2, this.transform.position, Quaternion.identity);
          Instantiate(Bullet_Sp2, this.transform.position, Quaternion.identity);
          Instantiate(Bullet_Sp2, this.transform.position, Quaternion.identity);
          Instantiate(Bullet_Sp, this.transform.position, Quaternion.identity);
          Instantiate(Bullet_Sp, this.transform.position, Quaternion.identity);
          Instantiate(Bullet_Sp, this.transform.position, Quaternion.identity);

        }else if(Input.GetKey(KeyCode.C)&&Game_Master.PlayerLife_Gage>0){

          Camera.SetBool("Sp_Use",true);
          Shot_Se.active = true;

          Game_Master.PlayerLife_Gage = Game_Master.PlayerLife_Gage - 3.5f;
          Sp_Use = true;
          Instantiate(Bullet_SP3, new Vector3(this.transform.position.x+3.5f,this.transform.position.y + 1.5f ,this.transform.position.z), Quaternion.identity);
          Instantiate(Bullet_SP4, new Vector3(this.transform.position.x+3.5f,this.transform.position.y ,this.transform.position.z), Quaternion.identity);
          Instantiate(Bullet_SP3, new Vector3(this.transform.position.x+3.5f,this.transform.position.y - 1.5f ,this.transform.position.z), Quaternion.identity);
          Instantiate(Bullet_SP3, new Vector3(this.transform.position.x+4.5f,this.transform.position.y + 1.5f ,this.transform.position.z), Quaternion.identity);
          Instantiate(Bullet_SP4, new Vector3(this.transform.position.x+4.5f,this.transform.position.y ,this.transform.position.z), Quaternion.identity);
          Instantiate(Bullet_SP3, new Vector3(this.transform.position.x+4.5f,this.transform.position.y - 1.5f ,this.transform.position.z), Quaternion.identity);
          Instantiate(Bullet_SP3, new Vector3(this.transform.position.x+5.5f,this.transform.position.y + 1.5f ,this.transform.position.z), Quaternion.identity);
          Instantiate(Bullet_SP4, new Vector3(this.transform.position.x+5.5f,this.transform.position.y ,this.transform.position.z), Quaternion.identity);
          Instantiate(Bullet_SP3, new Vector3(this.transform.position.x+5.5f,this.transform.position.y - 1.5f ,this.transform.position.z), Quaternion.identity);
        }else if(Input.GetKey(KeyCode.Space)&&Game_Master.PlayerLife_Gage>750){

          Instantiate(Reiwa_Canon, new Vector3(this.transform.position.x,this.transform.position.y + 1 ,this.transform.position.z), Quaternion.identity);

          Camera.SetBool("Reiwa_Canon",true);
          Game_Master.PlayerLife_Gage = Game_Master.PlayerLife_Gage - 750;
          Sp_Use = true;
          Instantiate(Bullet_Reiwa, this.transform.position, Quaternion.identity);

        }else if(Input.GetKey(KeyCode.F)&&Game_Master.PlayerLife_Gage>1&&Reiwa_Canon_SP_Timeline.active==false){

          Player_Move.Player_Move_On = false;

          Reiwa_Canon_SP_Timeline.active = true;
          Camera.SetBool("Reiwa_Canon_Event",true);
          Invoke("Reiwa_Canon_SP_Event",1.5f);


        }else{


          Shot_Se.active = false;

          Camera.SetBool("Reiwa_Canon",false);
          Camera.SetBool("Sp_Use",false);
          Sp_Use= false;
        }
      }




    }
    void Reiwa_Shot_Sp(){
      Instantiate(Reiwa_Canon_SP, new Vector3(this.transform.position.x,this.transform.position.y + 1 ,this.transform.position.z), Quaternion.identity);
      Instantiate(Reiwa_Canon_SP2, new Vector3(this.transform.position.x,this.transform.position.y + 1 ,this.transform.position.z), Quaternion.identity);
    }

    void Reiwa_Canon_SP_Event(){
      Reiwa_Canon_SP_Timeline.active = false;
      Game_Master.reikyaku_Mode = true;
      Instantiate(Reiwa_Canon_Kora, this.transform.position, Quaternion.identity);

      for(float i = 0;Game_Master.PlayerLife_Gage>i;i +=10){

      Delay = Random.Range(0.1f,2f);
      Invoke("Reiwa_Shot_Sp",Delay);
    }

    Camera.SetBool("Reiwa_Canon_Event",false);
      Camera.SetBool("Reiwa_Canon",true);
        Player_Move.Player_Move_On = true;
      Game_Master.PlayerLife_Gage =  1;
      Sp_Use = true;
      Instantiate(Reiwa_Canon, this.transform.position, Quaternion.identity);
    }
}
