using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour {

	public void Load(string scene)
	{
		SceneManager.LoadScene(scene);
	}
}
