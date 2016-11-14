using UnityEngine;
using System.Collections;

public class ContactoEstanque : MonoBehaviour {

	//private Generador generador;
	private GameObject personaje;
	private ControladorPersonaje cPersonaje;

	void Awake()
	{
		//generador = GameObject.FindWithTag ("GameController").GetComponent<Generador> ();
		personaje = GameObject.FindWithTag ("Player");
		cPersonaje = personaje.GetComponent<ControladorPersonaje> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			cPersonaje.entraAgua (transform.position.y + 0.5f);
		}
	}

	/*void OnTriggerStay2D(Collider2D other) {
		if (other.CompareTag ("Player")) {
			Debug.Log ("esta en el agua");
		}
	}*/

	void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag ("Player")) {
			cPersonaje.saleAgua ();
		}
	}
}
