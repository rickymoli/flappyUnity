using UnityEngine;
using System.Collections;

public class Camara : MonoBehaviour {

	public float TARGET_WIDTH = 1280f;
	public float TARGET_HEIGHT = 800f;
	public float PIXELS_TO_UNITS = 50f;

	// Use this for initialization
	void Start () {
		
		float desiredRatio = TARGET_WIDTH / TARGET_HEIGHT;
		float currentRatio = (float)Screen.width / (float)Screen.height;

		if (currentRatio >= desiredRatio) {
			Camera.main.orthographicSize = TARGET_HEIGHT / 2 / PIXELS_TO_UNITS;
		} else {
			float differenceInSize = desiredRatio / currentRatio;
			Camera.main.orthographicSize = TARGET_HEIGHT / 2 / PIXELS_TO_UNITS * differenceInSize;
		}
	
	}

	public float getLimiteVerticalPantalla()
	{
		//return Screen.height / PIXELS_TO_UNITS / 2f;
		return (float)Camera.main.orthographicSize;
	}

	public float getLimiteHorizontalPantalla()
	{
		return Screen.width / PIXELS_TO_UNITS / 2f;
	}

	

}
