using UnityEngine;
using System.Collections;

public class Camara : MonoBehaviour {



	// Use this for initialization
	void Start () {
		float TARGET_WIDTH = 1280f;
		float TARGET_HEIGHT = 800f;
		int PIXELS_TO_UNITS = 50;
		float desiredRatio = TARGET_WIDTH / TARGET_HEIGHT;
		float currentRatio = (float)Screen.width / (float)Screen.height;

		if (currentRatio >= desiredRatio) {
			Camera.main.orthographicSize = TARGET_HEIGHT / 2 / PIXELS_TO_UNITS;
		} else {
			float differenceInSize = desiredRatio / currentRatio;
			Camera.main.orthographicSize = TARGET_HEIGHT / 2 / PIXELS_TO_UNITS * differenceInSize;
		}
	
	}
	

}
