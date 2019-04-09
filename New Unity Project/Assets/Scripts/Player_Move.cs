using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Move : MonoBehaviour {

    public GameObject Player;
    public GameObject Cameta_Follow;
    public Vector3 Player_Position;
    public float kaihukuryou;
    public Image PowerGage;
    public static bool Rikabary_Get;
    public float Player_X;
    public float Player_Y;
    public float Player_X_Move;
    public static float Game_Time;
    public float Game_Time2;
    public float Game_Speed;
    public static bool Player_Move_On;

    // Use this for initialization
    void Start () {
     Invoke("Player_Start",3.5F);
     Player_Move_On = false;
     Rikabary_Get = false;
	}

	// Update is called once per frame
    void Update () {

        Player_Position = Player.transform.position;
        Player_Y = Player_Position.y;
        Player_X = Player_Position.x;

        Game_Time += Time.deltaTime;
        Game_Speed =0.07f;
        Game_Time2 += Game_Speed;

        Player_X_Move = Player_X - Game_Time2;

        float dx = Input.GetAxis("Horizontal");
        float dy = Input.GetAxis("Vertical");

        Cameta_Follow.transform.Translate(Game_Speed, 0, 0.0F);

        if(Player_Move_On == true){

        if (Player_Y > 40)
        {

            if (Player_X_Move > 25)
            {
                if (dy < 0 && dx < 0)
                {
                    Player.transform.Translate(dx, dy, 0.0F);
                }
                if(dy < 0){
                    Player.transform.Translate(0, dy, 0.0F);
                }
                if (dx < 0)
                {
                    Player.transform.Translate(dx, 0, 0.0F);
                }
            }else if(Player_X_Move < -25)
            {
                if (dy < 0 && dx > 0)
                {
                    Player.transform.Translate(dx, dy, 0.0F);
                }
                if (dy < 0)
                {
                    Player.transform.Translate(0, dy, 0.0F);
                }
                if (dx > 0)
                {
                    Player.transform.Translate(dx, 0, 0.0F);
                }
            }
            else
            {
                Player.transform.Translate(dx, 0, 0.0F);

                if (dy < 0)
                {
                    Player.transform.Translate(dx, dy, 0.0F);
                }

            }

        }
        else if (Player_Y < -40)
            {

            if (Player_X_Move > 25)
            {
                if (dy > 0 && dx < 0)
                {
                    Player.transform.Translate(dx, dy, 0.0F);
                }
                if (dy > 0)
                {
                    Player.transform.Translate(0, dy, 0.0F);
                }
                if (dx < 0)
                {
                    Player.transform.Translate(dx, 0, 0.0F);
                }
            }
            else if (Player_X_Move < -25)
            {
                if (dy > 0 && dx > 0)
                {
                    Player.transform.Translate(dx, dy, 0.0F);
                }
                if (dy > 0)
                {
                    Player.transform.Translate(0, dy, 0.0F);
                }
                if (dx > 0)
                {
                    Player.transform.Translate(dx, 0, 0.0F);
                }
            }
            else
            {

                Player.transform.Translate(dx, 0, 0.0F);

                if (dy > 0)
                {
                    Player.transform.Translate(dx, dy, 0.0F);
                }
            }

            }else if(Player_X_Move > 25)
                {
            Player.transform.Translate(0, dy, 0.0F);

            if (dx < 0)
            {
                Player.transform.Translate(dx, dy, 0.0F);
            }

        }
        else if (Player_X_Move < -25)
        {
            Player.transform.Translate(0, dy, 0.0F);

            if (dx > 0)
            {
                Player.transform.Translate(dx, dy, 0.0F);
            }

        }
        else
            {
            Player.transform.Translate(dx, dy, 0.0F);
        }

      }
    }

    void Player_Start(){
      Player_Move_On = true;
    }

    void OnTriggerEnter(Collider other)
      {
        if(Player_Move_On){
      if(other.CompareTag("Enemy_Bullet")){
     Game_Master.PlayerLife_Gage -=  150;
     Game_Master.Player_hit = true;
      }

       if(other.CompareTag("Enemy")){
           Game_Master.PlayerLife_Gage -=  100;
              Game_Master.Player_hit = true;
            }

          }

            if(other.CompareTag("Rikabary")){
              Rikabary_Get = true;
              if(Game_Master.reikyaku_Mode==false){
            if(Game_Master.PlayerLife_Gage<=300){
            Game_Master.PlayerLife_Gage = Game_Master.PlayerLife_Gage+ 700;
            PowerGage.fillAmount = Game_Master.PlayerLife_Gage/1000;
          }else if(Game_Master.PlayerLife_Gage<1000){
            Rikabary_Get = true;
            kaihukuryou = 1000 - Game_Master.PlayerLife_Gage;
            Game_Master.PlayerLife_Gage = Game_Master.PlayerLife_Gage + kaihukuryou;
            PowerGage.fillAmount = Game_Master.PlayerLife_Gage/1000;
          }
        }else if(Game_Master.reikyaku_Mode==true){}
      }

      }

}
