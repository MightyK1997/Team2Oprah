using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlRight : MonoBehaviour {

	// Use this for initialization

    public void MovePlayer()
    {
        GameObject player = GameObject.Find("PlayerCube");
        player.transform.position += new Vector3(0.5f, 0, 0);
    }
}
