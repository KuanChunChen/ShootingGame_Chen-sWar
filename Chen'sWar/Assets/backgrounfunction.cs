using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class backgrounfunction : MonoBehaviour {

	// Use this for initialization

	public GameObject Emeny;
	public float time;
	public Text ScoreText; //宣告一個ScoreText的text
	public int Score = 0; // 宣告一整數 Score
	public static backgrounfunction Instance; // 設定Instance，讓其他程式能讀取GameFunction
	public GameObject GameTitle; //宣告GameTitle物件
	public GameObject GameOverTitle; //宣告GameOverTitle物件
	public GameObject PlayButton; //宣告PlayButton物件
	public bool IsPlaying = false; // 宣告IsPlaying 的布林資料，並設定初始值false
	public GameObject RestartButton; //宣告RestartButto的物件
	public GameObject QuitButton; //宣告QuitButton的物件

	public float BulletTime; //子彈的時間
	public GameObject Ship;

	public GameObject Bullet;


	void Start () {
		Instance = this; 
		GameOverTitle.SetActive(false);
		RestartButton.SetActive(false);
		QuitButton.SetActive (false); //QuitButton設定成不顯示
	}
	
	// Update is called once per frame
	void Update () {
		BulletTime += Time.deltaTime;
		if (BulletTime > 0.15f && IsPlaying == true){
			Vector3 Bullet_pos = Ship.transform.position + new Vector3(0, 0.6f, 0);
			Instantiate(Bullet, Bullet_pos, Ship.transform.rotation);
			BulletTime = 0f;
			}





		time += Time.deltaTime; //時間增加
		if(time>0.5f && IsPlaying == true){
			Vector3 pos = new Vector3(Random.Range(-2.5f,2.5f),4.5f,0); 
			Instantiate(Emeny,pos,transform.rotation); //產生敵人
			time = 0f; //時間歸零
		}
	}

	public void AddScore(){

		Score += 10; //分數+10

		ScoreText.text = "Score: " + Score; // 更改ScoreText的內容

	}

	public void GameStart() {
		IsPlaying = true; //設定IsPlaying為true，代表遊戲正在進行中
		GameTitle.SetActive (false); //不顯示GameTitle
		PlayButton.SetActive (false); //不顯示PlayButton

	}
	public void GameOver() {

		IsPlaying = false; //IsPlaying設定成false，停止產生外星人
		GameOverTitle.SetActive(true); //GameOverTitle設定為ture
		RestartButton.SetActive(true); //RestartButton設定成不顯示
		QuitButton.SetActive(true); //QuitButton設定成不顯示
	}

	public void ResetGame() {

		Application.LoadLevel (Application.loadedLevel); //讀取關卡

	}
		
	public void QuitGame() {

		Application.Quit(); //離開應用程式

	}


}
