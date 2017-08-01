using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		for (int i = 0; i < transform.childCount; i++) {
			//Gizmos.DrawSphere(transform.GetChild(i).position, 0.1f);
		}
	}
}
