using UnityEngine;
using System.Collections;

public class ContactoDetectaPaso : MonoBehaviour {

	private Generador generador;

	void Awake()
	{
		generador = GameObject.FindWithTag ("GameController").GetComponent<Generador> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Bloques")) {
			generador.AddPuntuacion (1);
		}



	}
}
