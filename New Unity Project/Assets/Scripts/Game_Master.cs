using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Master : MonoBehaviour {

	public GameObject Player;
	public GameObject Main_Camera;
	public GameObject GameOver;
	public GameObject Awakening_Event;
	public GameObject Awakening_Text;
	public Image PowerGage;
	public Image Awakening_Gage_Image;
	public static int Score = 0;

	public static float PlayerLife_Gage=1000;
	public float PlayerLife_Gage2=1000;
	public static float Awakening_Gage;
	public float Awakening_Gage2;
	public static bool Awakening_Flag;

	public static bool Player_hit =false;
	public Text Score_Text;
	public Text Energy_Text;
	public Text PlayTime_Text;
	public Text Player_X;
	public Text Player_Y;
	public Text Map;
	public Text Heart_kei;
	public float Heart;
	public Animator Nav;
	public Animator Font;
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
	public GameObject Rikabaty_Se;

	public float Rikabaty_Se_Count;

	// Use this for initialization
	void Start () {
		reikyaku_Mode = false;
		Score = 0;
		PlayerLife_Gage=450;
		Time_Count=0;
		Time2=0;
		Awakening_Gage = 0;
		Awakening_Gage2 = 0;
		Awakening_Flag = false;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Escape))UnityEngine.Application.Quit();
		if(Player_hit){
		Heart=Random.Range(100,120);
		Instantiate(Damage_Se, this.transform.position, Quaternion.identity);
		Nav.SetBool("Damage", true);
		Circle.SetBool("Damage", true);
		Font.SetBool("Damage", true);
		Camera.SetBool("Damage",true);
		Player_hit=false;
	}


 if(PlayerLife_Gage>750){
	 Nav.SetBool("Reiwa_active", true);
 }else{
	 Nav.SetBool("Reiwa_active", false);
 }

 if(PlayerLife_Gage<200){
	 Heart=Random.Range(40,49);
	 Nav.SetBool("Coution_active", true);
 }else{
	 Nav.SetBool("Coution_active", false);
 }


if(Bullet_Generater.Sp_Use==true){
	Heart=Random.Range(90,99);
	Circle.SetBool("Sp_Use", true);
	Font.SetBool("Sp_Use", true);
}

if(reikyaku_Mode && reikyaku_Event){
		Heart=Random.Range(190,220);
	Kinkyu_reikyaku();
	reikyaku_Event = false;
}


if(PlayerLife_Gage2>PlayerLife_Gage && reikyaku_Mode == false){
	PlayerLife_Gage2 = PlayerLife_Gage2 -20;
		PowerGage.fillAmount = (0.00075f*PlayerLife_Gage2)+0.25f;
	}else if(PlayerLife_Gage<=1000){
		Nav.SetBool("Damage", false);
		Circle.SetBool("Damage", false);
		Font.SetBool("Damage", false);
		Camera.SetBool("Damage",false);

		if(reikyaku_Mode){

			Heart=Random.Range(110,120);
				PlayerLife_Gage2 += 2;
				Nav.SetBool("Damage", true);
				Circle.SetBool("Reikyaku", true);
				Circle.SetBool("Rikabary", false);
				Font.SetBool("Reikyaku", true);
				Font.SetBool("Rikabary", false);
				Camera.SetBool("Damage",true);
				Circle.SetBool("Sp_Use", false);
				Font.SetBool("Sp_Use", false);
				if(PlayerLife_Gage2>=1000){
					reikyaku_Mode = false;
					reikyaku_Event = true;
					PlayerLife_Gage = 999;
					Rikabaty_Se_Count = 0;
					Nav.SetBool("Damage", false);
					Circle.SetBool("Damage", false);
					Circle.SetBool("Reikyaku", false);
					Font.SetBool("Damage", false);
					Font.SetBool("Reikyaku", false);
					Camera.SetBool("Damage",false);
				}
				PowerGage.fillAmount = (0.00075f*PlayerLife_Gage2)+0.25f;
			}else if(Bullet_Generater.Sp_Use==false){
			Heart=Random.Range(60,70);
		Nav.SetBool("Rikabary", true);
		Circle.SetBool("Rikabary", true);
		Font.SetBool("Rikabary", true);
		if(Player_Move.Rikabary_Get == false){
		PlayerLife_Gage = PlayerLife_Gage + 1;
		PlayerLife_Gage2 = PlayerLife_Gage;
		PowerGage.fillAmount = (0.00075f*PlayerLife_Gage2)+0.25f;

	}else if(PlayerLife_Gage2<PlayerLife_Gage && Player_Move.Rikabary_Get){
			Heart=Random.Range(70,80);
		PlayerLife_Gage2 = PlayerLife_Gage2 +30;
			PowerGage.fillAmount = (0.00075f*PlayerLife_Gage2)+0.25f;
			if(PlayerLife_Gage2>=PlayerLife_Gage){
				Player_Move.Rikabary_Get = false;
			}
		}

		Circle.SetBool("Sp_Use", false);
		Font.SetBool("Sp_Use", false);


	}else if(Bullet_Generater.Sp_Use==true && PlayerLife_Gage2<PlayerLife_Gage && Player_Move.Rikabary_Get){
			Heart=Random.Range(70,80);
		PlayerLife_Gage2 = PlayerLife_Gage2 +30;
			PowerGage.fillAmount =(0.00075f*PlayerLife_Gage2)+0.25f;
			if(PlayerLife_Gage2>=PlayerLife_Gage){
				Player_Move.Rikabary_Get = false;
			}
		}



	}else{
		Heart=Random.Range(60,70);
		Nav.SetBool("Damage", false);
		Nav.SetBool("Rikabary", false);
		Circle.SetBool("Rikabary", false);
		Circle.SetBool("Damage", false);
		Font.SetBool("Rikabary", false);
		Font.SetBool("Damage", false);
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
			Heart=0;
			Invoke("SceneLoader",2f);
		}


		}else if(Player.active ==true){

			//覚醒ゲージの同期


			if(Awakening_Gage>1000){
				float Awakening_zyokyo;
				Awakening_zyokyo = 1000-Awakening_Gage;
				Awakening_Gage = Awakening_Gage + Awakening_zyokyo;
			}

			 Awakening_Gage2 = Awakening_Gage;
			 Awakening_Gage_Image.fillAmount = Awakening_Gage2/1000;


		 if(Awakening_Gage2>=1000&&Input.GetKey(KeyCode.Z)&&Input.GetKey(KeyCode.X)&&Input.GetKey(KeyCode.C)){
			 Awakening_Event.active = true;
			 Instantiate(Awakening_Text, this.transform.position, Quaternion.identity);
			 Player_Move.Player_Move_On = false;
			 Awakening_Gage2 = 0;
			 Invoke("Delay_Player_Move",3.5f);
		 }

			float hoge = PlayerLife_Gage2/10;
			Energy_Text.text=""+hoge.ToString("f1");
		Score_Text.text =""+Score;
		PlayTime_Text.text= ""+Time2;
		Player_X.text="X:"+Player.transform.localPosition.x;
		Player_Y.text="Y:"+Player.transform.localPosition.y;
		Map.text="Map:"+Main_Camera.transform.position.x;
		Heart_kei.text="Helth:" + Heart;


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

	void Delay_Player_Move(){
		Awakening_Flag = true;
		Awakening_Event.active = false;
		Player_Move.Player_Move_On = true;
	}


}
