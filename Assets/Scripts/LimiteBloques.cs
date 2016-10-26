using UnityEngine;
using System.Collections;

public class LimiteBloques : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Bloques")) {
			Destroy (other.gameObject);
		}



	}
}
