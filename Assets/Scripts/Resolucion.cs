using UnityEngine;
using System.Collections;

public class Resolucion : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float height = (float)Camera.main.orthographicSize * 2;
		float width = height * Screen.width / Screen.height;
		transform.localScale = new Vector3 (width, height, 0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
