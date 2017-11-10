using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlRight : MonoBehaviour {

    // Use this for initialization
    private Animator animController;
    public void MovePlayer()
    {
        GameObject player = GameObject.Find("Player");
        animController = player.GetComponent<Animator>();
        animController.SetTrigger("PlayerWalking");
        if (player.transform.position.x < 7)
        {
            player.transform.position += new Vector3(1f, 1f, 0);
        }
    }
}
