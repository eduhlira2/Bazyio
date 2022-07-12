using UnityEngine;
using System.Collections;

public class PlayerDoubleTap : MonoBehaviour {
	public float TapTime = 1f;
	float firstTapTime;
	bool firstTap;

	float maxX = 1f;
	float maxY = 1f;

	//float minX = 0.05f;
	//float minY = 0.05f;

	Rigidbody2D rb2d;

	Animator ani;




	// Use this for initialization
	void Start () 
	{
		ani = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () 
	{
		Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		if (Input.GetMouseButtonDown(0))
		{
			if (firstTap)
			{
				firstTapTime = Time.time;
				firstTap = false;
			}else
			{
				float distX = position.x - transform.position.x;

				if (distX > maxX) distX = maxX;

				float distY = position.y - transform.position.y;

				if (distY > maxY) distY = maxY;

				//rb2d.position += new Vector2 (distX, distY);

				ani.SetTrigger("PlayerJump");

				transform.Translate (distX, distY, 0);
			}
		}

		if ((Time.time > firstTapTime + TapTime) && !firstTap)
		{
			firstTap = true;
		}
	}
}
