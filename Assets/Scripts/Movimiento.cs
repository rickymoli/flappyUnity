using UnityEngine;
using System.Collections;

public class Movimiento : MonoBehaviour {

	public float speed = 1f;


	private Generador generador;

	void Awake()
	{
		generador = GameObject.FindWithTag ("GameController").GetComponent<Generador> ();
	}
	void Update () {
		if (!generador.IsGameOver())
			transform.Translate (-(speed * Time.deltaTime), 0, 0);

	}

}
