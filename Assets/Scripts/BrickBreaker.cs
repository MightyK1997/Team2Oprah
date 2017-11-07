using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBreaker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public GameObject particle;

	// Update is called once per frame
	void Update () {
        if (Input.touchCount >0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Began)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                    if (Physics.Raycast(ray))
                    {
                        Destroy(particle);
                    }
                }
            }
        }
	}
}
