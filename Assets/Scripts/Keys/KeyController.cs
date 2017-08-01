using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : Singleton<KeyController> {
	private List<Transform> keys;

	public void Init () {
		keys = new List<Transform> ();

		for (int i = 0; i < transform.childCount; i++) {
			Transform child = transform.GetChild (i);

			for (int j = 0; j < child.childCount; j++) {
				keys.Add (child.GetChild (i));
			}
		}
	}

	public void KeyPressed(KeyCode key){
		
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		for (int i = 0; i < transform.childCount; i++) {
			//Gizmos.DrawSphere(transform.GetChild(i).position, 0.1f);
		}
	}
}
