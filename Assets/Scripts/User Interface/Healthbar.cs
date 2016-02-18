using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Healthbar : MonoBehaviour {
	
	public List<float> playerHealth;
	[SerializeField] Texture healthBarFront;
	[SerializeField] Texture healthBarBack;
	[SerializeField] List<float> showHealth;
	[SerializeField] float dropSpeed;
	[SerializeField] int time = 100;
	[SerializeField] GUIStyle style;
	[SerializeField] Font font;
	[SerializeField] string add0string = "";

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
		GUI.DrawTexture (new Rect (Screen.width * 0.101f, Screen.height * 0.06f, Screen.width * (0.00322f*showHealth[0]), Screen.height * 0.08f), healthBarBack, ScaleMode.ScaleAndCrop);
		GUI.DrawTexture (new Rect (Screen.width * 0.573f, Screen.height * 0.06f, Screen.width * (0.00322f*showHealth[1]), Screen.height * 0.08f), healthBarBack, ScaleMode.ScaleAndCrop);
		GUI.DrawTexture (new Rect (Screen.width * 0.05f, Screen.height * 0.05f, Screen.width * 0.9f, Screen.height * 0.1f), healthBarFront, ScaleMode.ScaleToFit);
		GUI.TextField (new Rect (Screen.width * 0.47f, Screen.height * 0.05f, Screen.width * 0.06f, Screen.height * 0.05f), ""+add0string+time, style);
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
	/*	if(Input.GetKeyDown(KeyCode.A)){
			ChangeHealth(0,Random.Range(-1,-5));
		}*/
	}
}
