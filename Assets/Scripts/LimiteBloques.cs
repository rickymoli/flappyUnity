using UnityEngine;
using System.Collections;

public class LimiteBloques : MonoBehaviour {

	private Camara camara;

	void Awake()
	{
		camara = GameObject.FindWithTag ("MainCamera").GetComponent<Camara> ();
	}

	void Start()
	{
		float limiteHorizontalPantalla = camara.getLimiteHorizontalPantalla();
		transform.position = new Vector3 (-limiteHorizontalPantalla, 0f, 0f);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Bloques")) {
			Destroy (other.gameObject);
		}



	}
}
