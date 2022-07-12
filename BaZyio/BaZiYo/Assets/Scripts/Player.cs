using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	Rigidbody2D rb2d;
	SpriteRenderer sr;
	Animator ani;
	SceneLoad sl;

	bool withEgg = false;
	GameObject egg;

	// Use this for initialization
	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();
		ani = GetComponent<Animator> ();
		sl = GetComponent<SceneLoad> ();
	}

	// Update is called once per frame
	void LateUpdate () 
	{
		if (Input.GetMouseButton (0)) 
		{
			Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			float offset = position.x - transform.position.x;

			if (offset > 0)
			{
			
				rb2d.velocity = new Vector2(5f, rb2d.velocity.y);
				sr.flipX = false;
			}

			if (offset < 0)
			{
				rb2d.velocity = new Vector2(-5f, rb2d.velocity.y);
				sr.flipX = true;
			}
		}
		else if (Input.GetMouseButtonUp(0))
		{
			rb2d.velocity = new Vector2(0, rb2d.velocity.y);
		}
	}

	public void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("TheEnd"))
		{
			gameObject.SetActive (false);
			sl.Load ("Main");
		}

		if (collision.gameObject.CompareTag("Egg"))
		{
			if (! withEgg) {
				gameObject.GetComponent<AudioSource>().Play();
				ani.SetTrigger ("PlayerEgg");
				collision.gameObject.SetActive (false);
				withEgg = true;
				egg = collision.gameObject;
			}
		}
	}

	void OnMouseDown()
	{
		if (withEgg)
		{
			ani.SetTrigger("PlayerIdle");
			withEgg = false;
			egg.SetActive (true);
			if (sr.flipX )
				egg.transform.position = transform.position + new Vector3 (0.8f, 0.2f);
			else
				egg.transform.position = transform.position + new Vector3 (-0.8f, 0.2f);
			//egg.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (2f, 2f));
		}
	}
}
