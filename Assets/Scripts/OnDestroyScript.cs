using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnDestroyScript : MonoBehaviour {


    public static int battery = 100;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        allCubes = GameObject.FindGameObjectsWithTag("Cubes");
	}

    public GameObject cube;
    GameObject[] allCubes;

    private void OnDestroy()
    {
        battery -= 10;
        foreach (var item in allCubes)
        {
            if (cube.name == "Cube")
            {
                if(item.name == "Cube (1)" || item.name == "Cube (2)" || item.name == "Cube (3)")
                {
                    item.layer = 8;
                    //item.GetComponent<Collider>().enabled = true;
                }
            }
            if (cube.name == "Cube (3)")
            {
                if (item.name == "Cube (4)" || item.name == "Cube (5)" || item.name == "Cube (6)" || item.name == "Cube (7)")
                {
                    item.layer = 8;
                    //item.GetComponent<Collider>().enabled = true;
                }
            }
        }
        
    }
}
