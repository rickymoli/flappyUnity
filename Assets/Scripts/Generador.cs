using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Generador : MonoBehaviour {

	public GameObject[] obj;
	public float tiempoEsperarBloques = 3f;
	public float tiempoEmpezar = 1f;
	public GameObject personaje;
	public GameObject gameObjectEmpezar;
	public GameObject gameObjectGameOver;
	public GameObject gameObjectPuntuacion;
	public Text puntuacionTexto;

	private Rigidbody2D rbPersonaje;
	private bool gameOver;
	private bool inicio;
	private int puntuacion = 0;


	// Use this for initialization
	void Start () {
		gameOver = false;
		inicio = true;
		gameObjectGameOver.SetActive (false);
		gameObjectPuntuacion.SetActive (false);
		rbPersonaje = personaje.GetComponent<Rigidbody2D> ();
		rbPersonaje.isKinematic = true;
		//rbPersonaje.velocity = Vector2.zero;
		Debug.Log ("Inicia");
		//StartCoroutine(Generar ());
	}

	void FixedUpdate () {
		/*if (Input.GetMouseButtonDown (0) && inicio == true) {
			inicio = false;
			gameObjectEmpezar.SetActive (false);
			rbPersonaje.isKinematic = false;
			StartCoroutine(Generar ());
		}*/
	}

	// Update is called once per frame
	void Update () {
		
		if (rbPersonaje.position.y < -5) {
			GameOver ();

		} else {
			if (Input.GetMouseButtonDown (0) && inicio == true) {
				gameObjectPuntuacion.SetActive (true);
				inicio = false;
				gameObjectEmpezar.SetActive (false);
				rbPersonaje.isKinematic = false;
				StartCoroutine(Generar ());
			}
		}
	}

	IEnumerator Generar() {
		yield return new WaitForSeconds (tiempoEmpezar);
		while (true) {
			int posArriba = Random.Range (0, obj.Length - 1);
			float y = (5 - obj [posArriba].transform.localScale.y) + (obj [posArriba].transform.localScale.y / 2);
			Instantiate (obj [posArriba], new Vector2 (transform.position.x, y), Quaternion.identity);
			int posAbajo = 5 - posArriba; 
			Debug.Log ("pos obj  Abajo = "+posAbajo);
			y = -(5 - obj [posAbajo].transform.localScale.y) + (-(obj [posAbajo].transform.localScale.y / 2));
			Instantiate (obj [posAbajo], new Vector2 (transform.position.x, y), Quaternion.identity);
			yield return new WaitForSeconds (tiempoEsperarBloques);
			if (gameOver) {
				break;
			}
		}
	}

	public void GameOver() {
		rbPersonaje.isKinematic = true;
		gameOver = true;
		gameObjectGameOver.SetActive(true);
	}

	public void Restart() {
		SceneManager.LoadScene (0);
	}

	public void AddPuntuacion(int p)
	{
		puntuacion += p;
		puntuacionTexto.text = puntuacion.ToString();
		Debug.Log ("puntuacion: "+puntuacion);

	}

	public bool IsGameOver()
	{
		return gameOver;
	}


}
