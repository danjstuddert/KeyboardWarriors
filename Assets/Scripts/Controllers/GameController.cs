﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController> {
	void Start(){
		KeyController.Instance.Init ();
	}
}