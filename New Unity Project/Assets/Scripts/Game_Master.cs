using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Master : MonoBehaviour {

	public GameObject Player;
	public GameObject GameOver;
	public Image PowerGage;
	public static int Score = 0;
	public static float PlayerLife_Gage=1000;
	public float PlayerLife_Gage2=1000;
	public static bool Player_hit =false;
	public Text Score_Text;
	public Text PlayTime_Text;
	public Animator Nav;
	public Animator Circle;
	public Animator Camera;
	public float Time_Count=0;
	public static int Time2=0;
	public static bool reikyaku_Mode;
	public bool reikyaku_Event = true;
	public bool GameOverCount = true;

	public GameObject Damage_Se;
	public GameObject Explotion_Se;
	public GameObject Shot_Se;

	// Use this for initialization
	void Start () {
		reikyaku_Mode = false;
		Score = 0;
		PlayerLife_Gage=450;
		Time_Count=0;
		Time2=0;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Escape))UnityEngine.Application.Quit();
		if(Player_hit){
		Instantiate(Damage_Se, this.transform.position, Quaternion.identity);
		Nav.SetBool("Damage", true);
		Circle.SetBool("Damage", true);
		Camera.SetBool("Damage",true);
		Player_hit=false;
	}


 if(PlayerLife_Gage>750){
	 Nav.SetBool("Reiwa_active", true);
 }else{
	 Nav.SetBool("Reiwa_active", false);
 }

 if(PlayerLife_Gage<200){
	 Nav.SetBool("Coution_active", true);
 }else{
	 Nav.SetBool("Coution_active", false);
 }


if(Bullet_Generater.Sp_Use==true){
	Circle.SetBool("Sp_Use", true);
}

if(reikyaku_Mode && reikyaku_Event){
	Kinkyu_reikyaku();
	reikyaku_Event = false;
}


if(PlayerLife_Gage2>PlayerLife_Gage && reikyaku_Mode == false){
	PlayerLife_Gage2 = PlayerLife_Gage2 -20;
		PowerGage.fillAmount = PlayerLife_Gage2/1000;
	}else if(PlayerLife_Gage<=1000){
		Nav.SetBool("Damage", false);
		Circle.SetBool("Damage", false);
		Camera.SetBool("Damage",false);

		if(reikyaku_Mode){
				PlayerLife_Gage2 += 2;
				Nav.SetBool("Damage", true);
				Circle.SetBool("Damage", true);
				Camera.SetBool("Damage",true);
				if(PlayerLife_Gage2>=999){
					reikyaku_Mode = false;
					reikyaku_Event = true;
					PlayerLife_Gage = 999;
					Nav.SetBool("Damage", false);
					Circle.SetBool("Damage", false);
					Camera.SetBool("Damage",false);
				}
				PowerGage.fillAmount = PlayerLife_Gage2/1000;
			}else if(Bullet_Generater.Sp_Use==false){
		Nav.SetBool("Rikabary", true);
		Circle.SetBool("Rikabary", true);
		if(Player_Move.Rikabary_Get == false){
		PlayerLife_Gage = PlayerLife_Gage + 1;
		PlayerLife_Gage2 = PlayerLife_Gage;
		PowerGage.fillAmount = PlayerLife_Gage/1000;

	}else if(PlayerLife_Gage2<PlayerLife_Gage && Player_Move.Rikabary_Get){
		PlayerLife_Gage2 = PlayerLife_Gage2 +30;
			PowerGage.fillAmount = PlayerLife_Gage2/1000;
			if(PlayerLife_Gage2>=PlayerLife_Gage){
				Player_Move.Rikabary_Get = false;
			}
		}

		Circle.SetBool("Sp_Use", false);

	}else if(Bullet_Generater.Sp_Use==true && PlayerLife_Gage2<PlayerLife_Gage && Player_Move.Rikabary_Get){
		PlayerLife_Gage2 = PlayerLife_Gage2 +30;
			PowerGage.fillAmount = PlayerLife_Gage2/1000;
			if(PlayerLife_Gage2>=PlayerLife_Gage){
				Player_Move.Rikabary_Get = false;
			}
		}



	}else{
		Nav.SetBool("Damage", false);
		Nav.SetBool("Rikabary", false);
		Circle.SetBool("Rikabary", false);
		Circle.SetBool("Damage", false);
		Camera.SetBool("Damage",false);
	}





		//ゲームオーバー処理
		if(PlayerLife_Gage < -4){
			if(GameOverCount){
			Shot_Se.active=false;
			Instantiate(Explotion_Se, this.transform.position, Quaternion.identity);
			GameOverCount = false;

			Player.active =false;
			Debug.Log("GameOver");
			GameOver.active = true;
			Invoke("SceneLoader",2f);
		}


		}else if(Player.active ==true){
		Score_Text.text =""+Score;
		PlayTime_Text.text= ""+Time2;

		Time_Count += Time.deltaTime;
		if(Time_Count>1){
			Time2 += 1;
			Time_Count = 0;
		}
	}

	}
	void SceneLoader(){
		SceneManager.LoadScene("GameOver");
	}

	void Kinkyu_reikyaku(){
		PlayerLife_Gage2 = PlayerLife_Gage;
	}


}
