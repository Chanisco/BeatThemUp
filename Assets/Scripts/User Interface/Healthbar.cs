using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Healthbar : MonoBehaviour {
	
	public List<float> playerHealth;
	[SerializeField] Texture healthBarFrontLeft;
	[SerializeField] Texture healthBarFrontRight;
	[SerializeField] Texture healthBarBack;
	[SerializeField] Texture roundWon;
	[SerializeField] List<float> showHealth;
	[SerializeField] float dropSpeed;
	[SerializeField] int time = 100;
	[SerializeField] GUIStyle style;
	[SerializeField] Font font;
	[SerializePrivateVariables] string add0string = "";
	[SerializeField] bool pl1won = true;
	[SerializeField] bool pl2won = true;

	void Awake(){
		style = new GUIStyle ();
		style.font = font;
		style.normal.textColor = Color.red;
		style.fontSize = (20 * 1920)/Screen.width;
	}

	public void Init(int playerAmount){
		for (float i=0; i<playerAmount; i++) {
			playerHealth.Add(100);
			showHealth.Add(100);
		}
	}

	public void ChangeHealth(int playerNumber, float change){
		playerHealth [playerNumber] = change;
		if (playerHealth [playerNumber] <= 0) {
			Debug.Log("Dead");
		}
	}

	void OnGUI(){
		GUI.DrawTexture (new Rect (Screen.width * 0.042f, -Screen.height * 0.026f, Screen.width * (0.0047f*showHealth[0]), Screen.height * 0.22f), healthBarBack, ScaleMode.StretchToFill);
		GUI.DrawTexture (new Rect (Screen.width * 0.96f, -Screen.height * 0.026f, Screen.width * (-0.0047f*showHealth[1]), Screen.height * 0.22f), healthBarBack, ScaleMode.StretchToFill);
		GUI.DrawTexture (new Rect (0,Screen.width*-0.075f, Screen.width * 0.47f,Screen.height * 0.47f), healthBarFrontLeft, ScaleMode.ScaleToFit);
		GUI.DrawTexture (new Rect (Screen.width*0.53f, Screen.width*-0.075f, Screen.width * 0.47f, Screen.height * 0.47f), healthBarFrontRight, ScaleMode.ScaleToFit);
		GUI.TextField (new Rect (Screen.width * 0.47f, Screen.height * 0.05f, Screen.width * 0.06f, Screen.height * 0.05f), ""+add0string+time, style);
		if (pl1won) {
			GUI.DrawTexture (new Rect (Screen.width*0.05f,Screen.width*-0.078f, Screen.width * 0.47f,Screen.height * 0.47f), roundWon, ScaleMode.ScaleToFit);
		}
		if (pl2won) {
			GUI.DrawTexture (new Rect (Screen.width*0.165f, Screen.width*-0.078f, Screen.width * 0.47f, Screen.height * 0.47f), roundWon, ScaleMode.ScaleToFit);
		}
	}

	void Update(){
		if (time > 0) {
			time = 99 - (int)Time.time;
		}
		if (time < 10) {
			add0string = "0";
		}
		showHealth [0] = Mathf.SmoothStep (showHealth [0], playerHealth [0], dropSpeed);
		showHealth [1] = Mathf.SmoothStep (showHealth [1], playerHealth [1], dropSpeed);
		/**if(Input.GetKeyDown(KeyCode.A)){
		//	ChangeHealth(0,Random.Range(-1,-5));
		}*/
	}
}
