using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControladorUI : MonoBehaviour {


	public GameObject gameObjectEmpezar;
	public GameObject gameObjectGameOver;
	public GameObject gameObjectPuntuacion;
	public GameObject gameObjectControles;
	public Text puntuacionTexto;

	// Use this for initialization
	void Start () {
		gameObjectGameOver.SetActive (false);
		gameObjectPuntuacion.SetActive (false);
		//gameObjectControles.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PrintIniciado() {
		gameObjectPuntuacion.SetActive (true);
		gameObjectEmpezar.SetActive (false);
		gameObjectControles.SetActive (true);
	}

	public void PrintGameOver() {
		gameObjectGameOver.SetActive(true);
		gameObjectControles.SetActive (false);
	}

	public void PrintPuntuacion(int p)	{
		puntuacionTexto.text = p.ToString();
	}
}
