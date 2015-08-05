using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ListItem : MonoBehaviour {

	public float speed = 20;
	public bool foldout = true;

	public float height;
	public float curHeight;
	
	// Use this for initialization
	public virtual void Start () {
		height = GetComponent<LayoutElement> ().preferredHeight;
		if (!foldout)
			GetComponent<LayoutElement> ().preferredHeight = 100;
	}

	// Update is called once per frame
	public virtual void Update () {

//		curHeight = GetComponent<LayoutElement> ().preferredHeight;
		if (foldout && curHeight != -1) {
			if(curHeight > height-1){
				GetComponent<LayoutElement> ().preferredHeight = -1;
			}
			else{
				GetComponent<LayoutElement> ().preferredHeight = iTween.FloatUpdate(curHeight, height, speed);
//				GetComponent<LayoutElement> ().preferredHeight = height;
				
			}
		}
		if (!foldout && curHeight != 100) {
			if(curHeight == -1){
				curHeight = height;
			}
			
			GetComponent<LayoutElement> ().preferredHeight = iTween.FloatUpdate(curHeight, 100, speed);
//			GetComponent<LayoutElement> ().preferredHeight = 100;
			

			
		}

	}
	
	public void Fold(){
		foldout = !foldout;
	}

	}
	

