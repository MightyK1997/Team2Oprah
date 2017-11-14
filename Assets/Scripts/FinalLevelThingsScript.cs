using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalLevelThingsScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnCollisionEnter(Collision col)
    {
        Debug.Log("EnterHere");
        GameObject player = GameObject.Find("Player");
        if (col.collider.name == "Cube (225)")
        {
            if ((player.transform.position.x > -3 && player.transform.position.x < 3))
            {
                SceneManager.LoadScene("WinScene");
            }
        }
    }
}
