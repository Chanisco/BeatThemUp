using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	[SerializeField] Texture[] menuItems;
	[SerializeField] Texture[] optionsItems;
	[SerializeField] Texture backButton;
	[SerializeField] GameObject blankObject;
	[SerializePrivateVariables] int index = 0;
	[SerializeField] Vector3 spawnLoc;
	[SerializePrivateVariables] bool menu = true;
	[SerializePrivateVariables] GUIStyle style;
	[SerializeField] float musicVolume=1;
	[SerializeField]float effectVolume=1;
	[SerializeField] int difficulty;

	void Start(){
		style = new GUIStyle ();
		AddMenuItems ();
	}


	void OnGUI(){
		index = 0;
		if (menu) {
			foreach (Texture item in menuItems) {
				if (GUI.Button (new Rect (Screen.width * 0.3f, Screen.height * (0.15f + (0.2f * index)), Screen.width * 0.4f, Screen.height * 0.15f), "", style)) {
					if (index == 0) {
						if (menu) {
							Debug.Log ("pl1vspl2");
						}
						// open new scene
					} else if (index == 1) {
						if (menu) {
							Debug.Log ("pl1vscpu");
						}
						// open new scene
					} else if (index == 2) {
						if (menu) {
							DeleteUI ();
							AddOptionItems ();
						}
					} else if (index == 3) {
						Application.Quit ();
					}
				}
				index++;
			}
		} else {
			musicVolume = GUI.HorizontalSlider (new Rect (Screen.width * 0.45f, Screen.height * 0.2f, Screen.width * 0.45f, Screen.height * 0.05f), musicVolume, 0, 100);
			effectVolume = GUI.HorizontalSlider (new Rect (Screen.width * 0.45f, Screen.height * 0.39f, Screen.width * 0.45f, Screen.height * 0.05f), effectVolume, 0, 100);
		}
		if (GUI.Button (new Rect (Screen.width * 0.7f, Screen.height * 0.8f, Screen.width * 0.165f, Screen.height * 0.15f), "", style)) {
			if (menu) {

			} else {
				DeleteUI ();
				AddMenuItems ();
				menu = true;
			}
		}
	}

	public void AddMenuItems(){
		index = 0;
		foreach (Texture item in menuItems) {
			blankObject.GetComponent<MenuItem> ().index = index;
			blankObject.GetComponent<MenuItem> ().options = false;
			blankObject.GetComponent<MenuItem> ().backButton = false;
			blankObject.GetComponent<MenuItem> ().image = menuItems [index];
			blankObject.GetComponent<MenuItem> ().checkPlacement ();
			Instantiate (blankObject,spawnLoc,blankObject.transform.rotation);
			index++;
		}
		index = 0;
	}
	
	public void AddOptionItems(){
		index = 0;
		foreach (Texture optionItem in optionsItems) {
			blankObject.GetComponent<MenuItem> ().index = index;
			blankObject.GetComponent<MenuItem> ().options = true;
			blankObject.GetComponent<MenuItem> ().backButton = false;
			blankObject.GetComponent<MenuItem> ().image = optionsItems [index];
			Instantiate (blankObject, spawnLoc, blankObject.transform.rotation);
			index++;
		}
		blankObject.GetComponent<MenuItem> ().image = backButton;
		blankObject.GetComponent<MenuItem> ().backButton = true;
		Instantiate (blankObject, spawnLoc, blankObject.transform.rotation);
		menu = false;
		index = 0;
	}
	
	public void DeleteUI(){
		foreach (GameObject menuItem in GameObject.FindGameObjectsWithTag("MenuItem")) {
			Destroy (menuItem);
		}
	}
}
