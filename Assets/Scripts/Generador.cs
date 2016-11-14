using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;

public class Generador : MonoBehaviour {

	public GameObject[] obj;
	public GameObject[] estanques;
	public float tiempoEsperarBloques = 3f;
	public float tiempoEmpezar = 1f;
	public GameObject personaje;

	private Rigidbody2D rbPersonaje;
	private bool gameOver;
	private bool inicio;
	private int puntuacion = 0;
	private Camara camara;
	private ControladorUI controladorUI;
	private float limiteVerticalPantalla;
	private float limiteHorizontalPantalla;
	private int nivelAguaPersonaje = 0;

	void Awake()
	{
		camara = GameObject.FindWithTag ("MainCamera").GetComponent<Camara> ();
		controladorUI = GameObject.FindWithTag ("UI").GetComponent<ControladorUI> ();
		rbPersonaje = personaje.GetComponent<Rigidbody2D> ();
	}

	void Start () {
		limiteVerticalPantalla = camara.getLimiteVerticalPantalla ();
		limiteHorizontalPantalla = camara.getLimiteHorizontalPantalla ();
		gameOver = false;
		inicio = true;

		rbPersonaje.isKinematic = true;
		Debug.Log ("limiteVerticalPantalla: "+limiteVerticalPantalla);
		transform.position = new Vector3 (limiteHorizontalPantalla/2+5, 0f, 0f);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && inicio == true) {
			inicio = false;
			controladorUI.PrintIniciado ();
			rbPersonaje.isKinematic = false;
			StartCoroutine(Generar ());
		}
	}

	IEnumerator Generar() {
		yield return new WaitForSeconds (tiempoEmpezar);
		while (true) {
			int pos = Random.Range (0, obj.Length - 1);
			int numAleatorio = Random.Range (0, 99);

			if (numAleatorio < 50 - 1) {
				float y = -limiteVerticalPantalla + estanques [0].transform.localScale.y/2;
				Instantiate (estanques [0], new Vector2 (transform.position.x, y), Quaternion.identity);
			} else {
				float y = -limiteVerticalPantalla + obj [pos].transform.localScale.y/2;
				Instantiate (obj [pos], new Vector2 (transform.position.x, y), Quaternion.identity);
			}

			yield return new WaitForSeconds (tiempoEsperarBloques);
			if (gameOver) {
				break;
			}
		}
	}

	public void GameOver() {
		rbPersonaje.isKinematic = true;
		gameOver = true;
		controladorUI.PrintGameOver ();
	}

	public void Restart() {
		SceneManager.LoadScene (0);
	}

	public void AddPuntuacion(int p)
	{
		puntuacion += p;
		controladorUI.PrintPuntuacion(puntuacion);
		Debug.Log ("puntuacion: "+puntuacion);

	}

	public void AddAgua(int a)
	{
		nivelAguaPersonaje += a;
		controladorUI.PrintAgua(nivelAguaPersonaje);
		Debug.Log ("agua: "+nivelAguaPersonaje);
	}


	public bool IsGameOver()
	{
		return gameOver;
	}


}
