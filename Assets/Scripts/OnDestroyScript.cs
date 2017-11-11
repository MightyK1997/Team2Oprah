using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnDestroyScript : MonoBehaviour {


    public static int battery = 100;

    GameObject healthSlider;

    Image healthSliderImage;

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
        healthSlider = GameObject.Find("HealthBarImage");
        healthSliderImage = healthSlider.GetComponent<Image>();
        battery -= 2;
        if (battery % 10 == 0)
        {
            string spriteName = "MainBar" + (battery / 10).ToString();
            healthSliderImage.sprite = Resources.Load<Sprite>("HealthBarImages/" + spriteName);
        }
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
            if (cube.name == "Cube (58)")
            {
                if (item.layer == 18)
                {
                    item.layer = 8;
                }
            }
            if (cube.name == "Cube (68)")
            {
                if (item.layer == 19)
                {
                    item.layer = 8;
                }
            }
        }
        
    }
}
