using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {

	public float velocidad = 0f;
	private Renderer ren;
	// Use this for initialization
	void Start () {
		ren = GetComponent<Renderer> ();
		float height = (float)Camera.main.orthographicSize * 2;
		float width = height * Screen.width / Screen.height;
		transform.localScale = new Vector3 (width, height, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		ren.material.mainTextureOffset = new Vector2 (Time.time * velocidad, 0);
	}
}
