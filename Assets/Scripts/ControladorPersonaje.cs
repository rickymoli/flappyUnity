using UnityEngine;
using System.Collections;

public class ControladorPersonaje : MonoBehaviour {

	//public float minimoTiempo;
	public float escalaGravedad = 1f;
	public float fuerzaElevar;
	public float maximaRotacion = 30f;
	public float minimaRotacion = -90f;


	private Rigidbody2D rb;
	//private float ultima = 0f;
	private float limiteVerticalPantalla;
	private Generador generador;
	private Camara camara;
	private bool impulsar = false;
	private bool contactoAgua = false;


	void Awake()
	{
		generador = GameObject.FindWithTag ("GameController").GetComponent<Generador> ();
		camara = GameObject.FindWithTag ("MainCamera").GetComponent<Camara> ();
		rb = GetComponent<Rigidbody2D> ();
	}

	void Start () {
		limiteVerticalPantalla = camara.getLimiteVerticalPantalla();
		rb.gravityScale = escalaGravedad;
	}

	void Update() {
		if (impulsar && (rb.velocity.y != 0 || contactoAgua == true)) {
			/*float ahora = Time.fixedTime;
			if (ahora > ultima + minimoTiempo) {
				ultima = Time.fixedTime;*/
				rb.velocity = new Vector2 (0, fuerzaElevar);
				rb.rotation = Mathf.Clamp((rb.velocity.y) + rb.rotation,minimaRotacion,maximaRotacion);
			//}
		}
		if (contactoAgua) {
			generador.AddAgua (1);
		}

		//limite superior
		if (rb.position.y > limiteVerticalPantalla) {
			//Debug.Log("y: "+rb.position.y+" limite: "+limiteVerticalPantalla);
			rb.velocity = new Vector2 (0, -fuerzaElevar/2);
		}else if (rb.position.y < -limiteVerticalPantalla) {
			generador.GameOver ();
		}

		rb.position = new Vector2 (0f,Mathf.Clamp(rb.position.y,-limiteVerticalPantalla,limiteVerticalPantalla));
		rb.rotation = Mathf.Clamp ((rb.velocity.y) + rb.rotation, minimaRotacion, maximaRotacion);

		//limite inferior

	}

	public void Impulsar() {
		//Debug.Log ("Impulsar");
		impulsar = true;
	}

	public void DetenerImpulsar() {
		//Debug.Log ("DetenerImpulsar");
		impulsar = false;
	}

	public void entraAgua(float y) {
		rb.gravityScale = 0;
		rb.rotation = 0;
		rb.velocity = new Vector2 (0, 0);
		rb.position = new Vector2 (0f,y);
		contactoAgua = true;
	}

	public void saleAgua() {
		rb.gravityScale = escalaGravedad;
		contactoAgua = false;
	}



}
