using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {

	public bool eated;
	public GameObject tailPrefab;

	Vector2 direction = Vector2.right;

	List<Transform> tails = new List<Transform>();

	// Use this for initialization
	void Start () {
		InvokeRepeating("Move", 0.3f, 0.3f);
	}

	void FixedUpdate () {
		if (Input.GetKey(KeyCode.D))
			direction = Vector2.right;
		else if (Input.GetKey(KeyCode.S))
			direction = -Vector2.up;
		else if (Input.GetKey(KeyCode.A))
			direction = -Vector2.right;
		else if (Input.GetKey(KeyCode.W))
			direction = Vector2.up;
	}

	void OnTriggerEnter2D(Collider2D collided) {
		if (collided.tag == "Food") {
			eated = true;
			Destroy (collided.gameObject);
		} else {
			SceneManager.LoadScene (0);
		}
	}

	void Move() {
		gameObject.transform.Translate (direction);
		Vector2 gap = transform.position;

		if (eated) {
			GameObject addedTail = (GameObject)Instantiate(tailPrefab, gap, Quaternion.identity);
			tails.Insert(0, addedTail.transform);
			eated = false;
		}
		else if (tails.Count > 0) {
			tails.Last().position = gap;
			tails.Insert(0, tails.Last());
			tails.RemoveAt(tails.Count-1);
		}
	}
}