using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {
	public KeyCode key;

	void Update(){
		if(Input.GetKeyDown(key)){
			KeyController.Instance.KeyPressed (key);
		}
	}
}
