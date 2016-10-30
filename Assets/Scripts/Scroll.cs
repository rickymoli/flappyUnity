using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {

	public float velocidad = 0f;
	private Renderer ren;

	void Start () {
		ren = GetComponent<Renderer> ();
	}
	
	void Update () {
		ren.material.mainTextureOffset = new Vector2 (Time.time * velocidad, 0);
	}
}
