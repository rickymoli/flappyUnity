using UnityEngine;
using System.Collections;

public class ContactoPersonaje : MonoBehaviour {

	private Generador generador;

	void Awake()
	{
		generador = GameObject.FindWithTag ("GameController").GetComponent<Generador> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			generador.GameOver ();
		}



	}
}
