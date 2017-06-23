using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour {

	public GameObject foodPrefab;
	public Transform bottomWall;
	public Transform topWall;
	public Transform leftWall;
	public Transform rightWall;

	void Start ()
	{
		
	}

	void Update()
	{
		if (GameObject.FindWithTag ("Food") == null)
		{
			Spawn ();
		}
	}

	void Spawn()
	{
		int x = (int)Random.Range(rightWall.position.x, leftWall.position.x);
		int y = (int)Random.Range(bottomWall.position.y, topWall.position.y);
		Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity);
	}
}
