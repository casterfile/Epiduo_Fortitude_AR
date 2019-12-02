using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public SpriteRenderer Girl_1,Girl_2,Girl_3;
	public Sprite PGirl_1,PGirl_2,PGirl_3;
	public Text Timer, Score;
	private GameObject G1,G2,G3;
	private GameObject G1_Smile,G2_Smile,G3_Smile;
	private GameObject G1_Blash,G2_Blash,G3_Blash;
	float Delay = 1.0f;
	public Camera m_MainCamera;

	public static bool isTreatment = false, CheckGirl_1 = false, CheckGirl_2 = false, CheckGirl_3 = false;
	int intScore = 0;
	float timeLeft = 60.0f;
	// Use this for initialization
	void Start () {
		isTreatment = false; CheckGirl_1 = false; CheckGirl_2 = false; CheckGirl_3 = false;
		intScore = 0;
		timeLeft = 60.0f;

		G1 = GameObject.Find ("Scene_02_Character_1");G2 = GameObject.Find ("Scene_02_Character_2");G3 = GameObject.Find ("Scene_02_Character_3");
		G1_Smile = GameObject.Find ("Scene_02_Character_1_Smile");G2_Smile = GameObject.Find ("Scene_02_Character_2_Smile");G3_Smile = GameObject.Find ("Scene_02_Character_3_Smile");
		G1_Blash = GameObject.Find ("Scene_02_Character_1_Blash");G2_Blash = GameObject.Find ("Scene_02_Character_2_Blash");G3_Blash = GameObject.Find ("Scene_02_Character_3_Blash");

		G1_Smile.SetActive (false);G2_Smile.SetActive (false);G3_Smile.SetActive (false);
		G1_Blash.SetActive (false);G2_Blash.SetActive (false);G3_Blash.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
//		var fwd = transform.TransformDirection (Vector3.forward);
//		if (Physics.Raycast (transform.position, fwd, 10)) {
//			print ("There is something in front of the object!");
//		}

		RaycastHit hit;
		Ray landingRay = new Ray (m_MainCamera.transform.position, m_MainCamera.transform.forward);// Vector3.forward
		if (Physics.Raycast (landingRay, out hit, 10)) {
			print (hit.collider.name);
			if (isTreatment == true) {
				if((hit.collider.name == "Character_1" || hit.collider.name == "Scene_02_Character_1" )&& CheckGirl_1 == false){
					StartCoroutine(FuncGirl_1());

				}
				if((hit.collider.name == "Character_2" || hit.collider.name == "Scene_02_Character_2")&& CheckGirl_2 == false){
					StartCoroutine(FuncGirl_2());

				}

				if((hit.collider.name == "Character_3" || hit.collider.name == "Scene_02_Character_3" )&& CheckGirl_3 == false){
					StartCoroutine(FuncGirl_3());

				}
			}


		}


//		if (isTreatment == true) {
//			if (ClickGirl.StaticGirlName == "PGirl_1" && CheckGirl_1 == false) {
//				
//				StartCoroutine(FuncGirl_1());
//
//			}if (ClickGirl.StaticGirlName == "PGirl_2" && CheckGirl_2 == false) {
//				
//				StartCoroutine(FuncGirl_2());
//
//			} else if (ClickGirl.StaticGirlName == "PGirl_3" && CheckGirl_3 == false) {
//				
//				StartCoroutine(FuncGirl_3());
//
//			}
//		} else {
//			ClickGirl.StaticGirlName = "";
//		}


		Score.text =""+ intScore;

		timeLeft -= Time.deltaTime;
		int timeTemp = Mathf.RoundToInt (timeLeft);
		if(timeTemp >= 10)
		{
			Timer.text = "0:" + timeTemp;
		}else if(timeTemp < 10){
			Timer.text = "0:0" + timeTemp;
		}

		if(timeTemp < 0 || timeTemp < 1){
			Timer.text = "0:0" + timeTemp;
			Application.LoadLevel("Scene_04");
		}

		if(intScore == 3){
			Application.LoadLevel("Scene_03");
		}
	}

	public void TreatementButton(){
		isTreatment = true;
	}

	IEnumerator FuncGirl_1()
	{
		Girl_1.sprite = PGirl_1;
		isTreatment = false;
		CheckGirl_1 = true;

		G1.SetActive (false);
		G1_Blash.SetActive (true);
		yield return new WaitForSeconds(Delay);
		G1_Blash.SetActive (false);
		G1_Smile.SetActive (true);
		yield return new WaitForSeconds(Delay);
		G1_Smile.SetActive (false);


		intScore++;
	}


	IEnumerator FuncGirl_2()
	{

		isTreatment = false;
		CheckGirl_2 = true;
		Girl_2.sprite = PGirl_2;

		G2.SetActive (false);
		G2_Blash.SetActive (true);
		yield return new WaitForSeconds(Delay);
		G2_Blash.SetActive (false);
		G2_Smile.SetActive (true);
		yield return new WaitForSeconds(Delay);
		G2_Smile.SetActive (false);


		intScore++;
	}


	IEnumerator FuncGirl_3()
	{
		Girl_3.sprite = PGirl_3;
		isTreatment = false;
		CheckGirl_3 = true;

		G3.SetActive (false);
		G3_Blash.SetActive (true);
		yield return new WaitForSeconds(Delay);
		G3_Blash.SetActive (false);
		G3_Smile.SetActive (true);
		yield return new WaitForSeconds(Delay);
		G3_Smile.SetActive (false);



		intScore++;
	}
}
