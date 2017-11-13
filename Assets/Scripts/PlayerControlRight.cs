using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlRight : MonoBehaviour {

    // Use this for initialization
    private Animator animController;
    public void MovePlayer()
    {
        GameObject player = GameObject.Find("Player");
        Ray ray = new Ray(player.transform.position, Vector3.left);
        RaycastHit hit;
        bool isHit = Physics.Raycast(ray, out hit);
        if (isHit)
        {
            if (hit.distance < 1)
            {
            }
            else if (hit.distance > 1)
            {
                animController = player.GetComponent<Animator>();
                animController.SetTrigger("PlayerWalking");
                if (player.transform.position.x < 6.9995f)
                {
                    player.transform.position += new Vector3(1f, 0f, 0);
                }
            }
        }
        else
        {
            animController = player.GetComponent<Animator>();
            animController.SetTrigger("PlayerWalking");
            if (player.transform.position.x < 6.9995f)
            {
                player.transform.position += new Vector3(1f, 0f, 0);
            }
        }
    }
}