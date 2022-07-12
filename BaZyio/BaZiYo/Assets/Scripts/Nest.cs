using UnityEngine;
using System.Collections;

public class Nest : MonoBehaviour {

	int eggs = 0;

	public GameObject egg1, egg2, egg3, baziyoVictory, baziyoPlayer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log(eggs + "");
		if (collision.gameObject.CompareTag ("Egg")) 
		{
			Destroy (collision.gameObject);
			eggs++;

			if (eggs == 1)
				egg1.SetActive (true);

			if (eggs == 2)
				egg2.SetActive (true);

			if (eggs == 3) {
				egg3.SetActive (true);
				baziyoVictory.SetActive (true);
				baziyoPlayer.SetActive (false);
			}
		}
	}
}
