using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlLeft : MonoBehaviour
{
    private Animator animController;
    public void MovePlayer()
    {
        GameObject player = GameObject.Find("Player");
        Ray ray = new Ray(player.transform.position, Vector3.left);
        RaycastHit hit;
        bool isHit = Physics.Raycast(ray, out hit);
        if (isHit)
        {
            if (hit.distance<1)
            {
                Vector3 testVector = player.transform.position + new Vector3(0, 1, 0);
                Ray testRay = new Ray(testVector, Vector3.left);
                RaycastHit testRayCastHit;
                bool testIsHit = Physics.Raycast(testRay, out testRayCastHit);
                if (testIsHit)
                {
                    if (testRayCastHit.distance > 1)
                    {
                        animController = player.GetComponent<Animator>();
                        animController.SetTrigger("PlayerWalking");
                        player.transform.position = testVector + new Vector3(-1, 0, 0);
                    }
                }
            }
            else if (hit.distance > 1)
            {
                animController = player.GetComponent<Animator>();
                animController.SetTrigger("PlayerWalking");
                if (player.transform.position.x > -13)
                {
                    player.transform.position -= new Vector3(1f, 0, 0);

                }
            }
        }
        else
        {
            animController = player.GetComponent<Animator>();
            animController.SetTrigger("PlayerWalking");
            if (player.transform.position.x > -13)
            {
                player.transform.position -= new Vector3(1f, 0, 0);

            }

        }
    }
}
