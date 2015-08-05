using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class ListItemExtended : ListItem {

	public InputField inputFld;
	public Button newGoalBtn;
	public Button saveBtn;
	public Text textFld;
	GameObject panel;

	Dictionary<float, float> panelHeights; 

	string state;
	float newHeight;

	int[] panelsToShow;
	int[] panelsToHide;


	// Use this for initialization
	public override void Start () {
		SetHeights ();
		base.Start ();

		if (textFld.text == "") {
			SingleButtonMode ();
		} else {
			ReadMode();
		}
	}





	// Update is called once per frame
	public override void Update () {
		scaleAllPanels ();



		base.Update ();
	}

	public void HeadlineClicked(){
		Fold ();
		if (textFld.text == "") {
			SingleButtonMode ();
		}

	}

	public void getInputText(){
		string value = inputFld.text;
		print (value.ToString ());
		inputFld.text = "";
	}

	public void ReadMode(){
		panelsToHide = new int[]{1,3,4};
		panelsToShow = new int[]{2};

		state = "read";

		deActivateChildren (panelsToHide);
		activateChildren (panelsToShow);

	}

	public void SingleButtonMode(){
		panelsToHide = new int[]{2,3,4};
		panelsToShow = new int[]{1};

		state = "singleButton";

		deActivateChildren (panelsToHide);
		activateChildren (panelsToShow);

	}

	public void InputMode(){
		
		panelsToHide = new int[]{1,2};
		panelsToShow = new int[]{3,4};

		state = "input";

		deActivateChildren (panelsToHide);
		activateChildren (panelsToShow);

	}

	//Sets the original size of the panels and saves to a Dictionary
	void SetHeights(){
		panelHeights = new Dictionary<float, float>();

		// ------------ VIRKER KUN HVER 2. GANG -----------------
		//---------------------- START --------------------------------

		for(int i = 1; i <= 4; i++){
			panel = GetPanelObject(i);
			int id = i;
			float value = panel.GetComponent<RectTransform> ().sizeDelta.y;

			if(id == 1 || id == 4){
				value += 40;
				//Skal være læst data
			}
			if(id == 3){
				value += 80;
			}

			panelHeights.Add(id,value);
			print ("Panel saved. ");
			print ("id: " + id);
			print ("value: " + value);
			
		}

		//------------------------ SLUT -------------------------------------------
	}

	GameObject GetPanelObject(int id){
		GameObject thisObject = GameObject.Find ("ContentPanel" + id.ToString());
		return thisObject;
	}

	void activateChildren(int[] numbers){
		for (int i = 0; i <= numbers.Length - 1; i++) 
		{
			panel = GetPanelObject(numbers[i]);
			foreach (Transform child in panel.transform)     
			{  
				child.gameObject.SetActive(true);   
			}
		}
	}

	void deActivateChildren(int[] numbers){
		for (int i = 0; i <= numbers.Length - 1; i++) 
		{
			panel = GetPanelObject(numbers[i]);
			foreach (Transform child in panel.transform)     
			{  
				child.gameObject.SetActive(false);   
			}
		}
	}

	void scaleAllPanels(){
		curHeight = GetComponent<LayoutElement> ().preferredHeight;
		newHeight = 0;
		for(int i = 0; i <= panelsToShow.Length-1 ; i++)
		{
			scalePanelOriginalState(panelsToShow[i]);
		}
		
		for(int i = 0; i <= panelsToHide.Length-1 ; i++)
		{
			scalePanelHiddenState(panelsToHide[i]);
		}
		height = newHeight;
	}

	void scalePanelOriginalState(int number){
		float pHeight = panelHeights[number];

		panel = GetPanelObject (number);
		panel.GetComponent<LayoutElement> ().preferredHeight = pHeight;
		newHeight += pHeight;

	}

	void scalePanelHiddenState(int number){
		float pHeight = -1;
		panel = GetPanelObject (number);
		panel.GetComponent<LayoutElement> ().preferredHeight = pHeight;
	}

	}