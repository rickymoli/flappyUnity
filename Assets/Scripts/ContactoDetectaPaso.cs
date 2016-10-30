using UnityEngine;
using System.Collections;

public class ContactoDetectaPaso : MonoBehaviour {

	private Generador generador;
	private Camara camara;



	void Awake()
	{
		generador = GameObject.FindWithTag ("GameController").GetComponent<Generador> ();
		camara = GameObject.FindWithTag ("MainCamera").GetComponent<Camara> ();

	}

	void Start() {
		float limiteVerticalPantalla = camara.getLimiteVerticalPantalla ();
		transform.position = new Vector3 (0f, -limiteVerticalPantalla+0.5f, 0f);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Bloques")) {
			generador.AddPuntuacion (1);
		}



	}
}
