using UnityEngine;
using System.Collections;

public class Movimiento : MonoBehaviour {

	//private Transform tr;
	public float speed = 1f;
	//private Rigidbody2D rb;

	private Generador generador;

	void Awake()
	{
		generador = GameObject.FindWithTag ("GameController").GetComponent<Generador> ();
		//rb = GetComponent<Rigidbody2D> ();
	}
	// Use this for initialization
	/*void Awake () {
		tr = GetComponent<Transform> ();
	}*/
	
	void Update () {
		if (!generador.IsGameOver())
			transform.Translate (-(speed * Time.deltaTime), 0, 0);

	}
	/*void Start () {
	transform.Translate (-(speed * Time.deltaTime), 0, 0);
		//rb.velocity = -transform.forward * speed;	
	}*/
}
