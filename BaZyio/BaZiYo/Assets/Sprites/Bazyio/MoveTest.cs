using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetAxis ("Horizontal") < 0) {
			SetarParametro ("stay", true);
			SetarParametro ("walk", false);
			SetarParametro ("dead", false);
			SetarParametro ("teleport", false);

		}if (Input.GetAxis ("Horizontal") > 0) {
			SetarParametro ("stay", false);
			SetarParametro ("walk", true);
			SetarParametro ("dead", false);
			SetarParametro ("teleport", false);

		}if (Input.GetAxis ("Vertical") > 0) {
			SetarParametro ("stay", false);
			SetarParametro ("walk", false);
			SetarParametro ("dead", true);
			SetarParametro ("teleport", false);

		}if (Input.GetAxis ("Vertical") < 0) {
			SetarParametro ("stay", false);
			SetarParametro ("walk", false);
			SetarParametro ("dead", false);
			SetarParametro ("teleport", true);
		}

	}

	void SetarParametro(string param, bool value){
	
		player.GetComponent<Animator> ().SetBool (param, value);

	}
}
