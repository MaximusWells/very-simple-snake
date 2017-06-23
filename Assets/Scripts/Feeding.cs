using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Feeding : MonoBehaviour {

	public static bool eated;
	public static GameObject tailPrefab;

	void OnTriggerEnter2D(Collider2D collided) {
		if (collided.tag == "Food") {
			eated = true;
			Destroy(collided.gameObject);
		}
		else {
			SceneManager.LoadScene(0);
		}
	}
}
