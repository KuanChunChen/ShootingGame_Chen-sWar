using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InVaild : MonoBehaviour {
	public GameObject explo;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position += new Vector3(0,-0.01f,0);
		
	}
	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Ship" || col.tag == "Bullet" ){
			Destroy(col.gameObject); //消滅碰撞的物件
			Destroy(gameObject); //消滅物件本身
			if (col.tag == "Ship"){
				Instantiate(explo,col.gameObject.transform.position,col.gameObject.transform.rotation);
	            
				backgrounfunction.Instance.GameOver(); 
			}
			backgrounfunction.Instance.AddScore(); 
		}


	}


}
