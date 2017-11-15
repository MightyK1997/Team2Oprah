using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlPosZ : MonoBehaviour {

    private Animator animController;
    public void MovePlayer()
    {
        GameObject player = GameObject.Find("Player");
        Ray ray = new Ray(player.transform.position, Vector3.back);
        RaycastHit hit;
        bool isHit = Physics.Raycast(ray, out hit);
        Debug.Log(hit.distance);
        if (isHit)
        {
            if (hit.distance < 1)
            {
                Debug.Log("Hello");
                Vector3 testVector = player.transform.position + new Vector3(0, 1, 0);
                Ray testRay = new Ray(testVector, Vector3.back);
                RaycastHit testRayCastHit;
                bool testIsHit = Physics.Raycast(testRay, out testRayCastHit);
                if (testIsHit)
                {
                    if (testRayCastHit.distance > 1)
                    {
                        animController = player.GetComponent<Animator>();
                        animController.SetTrigger("PlayerWalking");
                        player.transform.position = testVector + new Vector3(0, 0, -1);
                    }
                }
            }
            else if (hit.distance > 1)
            {
                animController = player.GetComponent<Animator>();
                animController.SetTrigger("PlayerWalking");
                if (player.transform.position.z > -11)
                {
                    player.transform.position += new Vector3(0, 0f, -1);
                }
            }
        }
        else
        {
            animController = player.GetComponent<Animator>();
            animController.SetTrigger("PlayerWalking");
            if (player.transform.position.z > -11)
            {
                player.transform.position += new Vector3(0, 0f, -1);
            }
        }
    }
}