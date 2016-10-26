using UnityEngine;
using System.Collections;

public class ControladorPersonaje : MonoBehaviour {

	public float fuerzaElevar;
	public float minimoTiempo;
	private Rigidbody2D rb;
	private float ultima = 0f;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update() {
		if (Input.GetMouseButtonDown (0) && rb.velocity.y != 0) {
			Debug.Log ("SALTA");
			float ahora = Time.fixedTime;
			if (ahora > ultima + minimoTiempo) {
				Debug.Log ("aplica fuerza " + fuerzaElevar);
				ultima = Time.fixedTime;

				rb.velocity = new Vector2 (0, fuerzaElevar);
				//rb.rotation = (rb.velocity.y) + rb.rotation;
				rb.rotation = Mathf.Clamp((rb.velocity.y) + rb.rotation,-120f,-60f);
				//rb.AddForce (new Vector2 (0, fuerzaElevar),ForceMode2D.Impulse);

			}

		} /*else {
			rb.rotation = (rb.velocity.y/2) + rb.rotation;	
		}*/
		if (rb.position.y > 5f) {
			//Debug.Log ("limiteeee");
			//rb.AddForce (new Vector2 (0,-fuerzaElevar/2));
			rb.velocity = new Vector2 (0, -fuerzaElevar/2);
		}
		rb.position = new Vector2 (0f,Mathf.Clamp(rb.position.y,-10f,5f));
		rb.rotation = Mathf.Clamp ((rb.velocity.y) + rb.rotation, -180f, -60f);
		// pq no pugi tan rapid
		/*if (rb.velocity.y < 0) {
			rb.rotation = Mathf.Clamp ((rb.velocity.y / 2) + rb.rotation, -180f, -60f);
		} else {
			rb.rotation = Mathf.Clamp ((rb.velocity.y / 4) + rb.rotation, -180f, -60f);
		}*/
		//

		Debug.Log("rotation: " + rb.rotation);
		/*Vector2 direccion = rb.position;
		if (direccion != Vector2.zero) {
			float angle = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
			rb.rotation = -angle;
		}*/
		//rb.rotation = Quaternion.Euler (0f,0f,-60f);
		/*Debug.Log("velocidad: " + rb.velocity.y);
		if (rb.velocity.y > 0) {
			//rb.rotation = rb.velocity.y * -fuerzaElevar * Time.deltaTime;
			rb.rotation = -60f * Time.deltaTime;
		}
		else if (rb.velocity.y < 0) {
			//rb.rotation = rb.velocity.y * -fuerzaElevar * Time.deltaTime;
			rb.rotation = -120f * Time.deltaTime;
		}*/

	}

	// Update is called once per frame
	void FixedUpdate () {
		
	}
}
