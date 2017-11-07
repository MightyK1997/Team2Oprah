using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBreaker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public GameObject particle;

    int brickHealth = 50;
    int subtractHealth = 10;


	// Update is called once per frame
	void Update () { 
        if (particle.GetComponent<Collider>().enabled)
        {
            if (Input.touchCount > 0)
            {
                for (int i = 0; i < Input.touchCount; i++)
                {
                    if (Input.GetTouch(i).phase == TouchPhase.Began)
                    {
                        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);

                        Vector3 touchPos = new Vector3(ray.origin.x, ray.origin.y, ray.origin.z);

                        RaycastHit hitInformation;

                        Debug.Log(ray);

                        if (Physics.Raycast(ray, out hitInformation, 10))
                        {
                            Debug.Log(hitInformation.collider.name);
                            Debug.Log(particle.transform.position);
                            if (hitInformation.collider.name == particle.name)
                            {
                                brickHealth -= subtractHealth;
                                if (brickHealth == 0)
                                {
                                    Destroy(particle);
                                    brickHealth = 50;
                                }
                            }
                        }
                    }
                }
            }
        }
	}
}
