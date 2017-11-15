using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionChange : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject player = GameObject.Find("Player");
        player.transform.position = new Vector3(Mathf.Round(player.transform.position.x), player.transform.position.y, player.transform.position.z);
        player.transform.Rotate(0, 0, 0);
	}
}
