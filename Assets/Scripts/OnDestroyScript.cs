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
        battery -= 20;

        foreach (var item in allCubes)
        {
            if (cube.name == "Cube")
            {
                if(item.layer == 11)
                {
                    item.layer = 8;
                    //item.GetComponent<Collider>().enabled = true;
                }
            }
            if (cube.name == "Cube (3)")
            {
                if (item.layer == 12)
                {
                    item.layer = 8;
                }
            }
            if (cube.name == "Cube (8)")
            {
                if (item.layer == 13)
                {
                    item.layer = 8;
                }
            }
            if (cube.name == "Cube (15)")
            {
                if (item.layer == 14)
                {
                    item.layer = 8;
                }
            }
            if (cube.name == "Cube (24)")
            {
                if (item.layer == 15)
                {
                    item.layer = 8;
                }
            }
            if (cube.name == "Cube (35)")
            {
                if (item.layer == 16)
                {
                    item.layer = 8;
                }
            }
            if (cube.name == "Cube (48)")
            {
                if (item.layer == 17)
                {
                    item.layer = 8;
                }
            }
            if (cube.name == "Cube (63)")
            {
                if (item.layer == 18)
                {
                    item.layer = 8;
                }
            }
            if (cube.name == "Cube (80)")
            {
                if (item.layer == 19)
                {
                    item.layer = 8;
                }
            }
            if (cube.name == "Cube (99)")
            {
                if (item.layer == 20)
                {
                    item.layer = 8;
                }
            }
            if (cube.name == "Cube (120)")
            {
                if (item.layer == 21)
                {
                    item.layer = 8;
                }
            }
            if (cube.name == "Cube (143)")
            {
                if (item.layer == 22)
                {
                    item.layer = 8;
                }
            }
            if (cube.name == "Cube (168)")
            {
                if (item.layer == 23)
                {
                    item.layer = 8;
                }
            }
            if (cube.name == "Cube (195)")
            {
                if (item.layer == 24)
                {
                    item.layer = 8;
                }
            }
        }
        
    }
}
