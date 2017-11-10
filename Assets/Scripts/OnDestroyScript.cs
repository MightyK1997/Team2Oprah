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
        battery -= 10;
        string spriteName = "MainBar" + (battery / 10).ToString();
        Debug.Log(spriteName);
        //Debug.Log("HealthBarImages/" + spriteName);
        healthSliderImage.sprite = Resources.Load<Sprite>("HealthBarImages/" + spriteName);
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
                if (item.name == "Cube (4)" || item.name == "Cube (5)" || item.name == "Cube (6)" || item.name == "Cube (7)" || item.name == "Cube (8)")
                {
                    item.layer = 8;
                    //item.GetComponent<Collider>().enabled = true;
                }
            }
            if (cube.name == "Cube (8)")
            {
                if (item.name == "Cube (9)" || item.name == "Cube (10)" || item.name == "Cube (11)" || item.name == "Cube (12)" || item.name == "Cube (13)" || item.name == "Cube (14)" || item.name == "Cube (15)")
                {
                    item.layer = 8;
                    //item.GetComponent<Collider>().enabled = true;
                }
            }
            if (cube.name == "Cube (15)")
            {
                if (item.name == "Cube (16)" || item.name == "Cube (17)" || item.name == "Cube (18)" || item.name == "Cube (19)" || item.name == "Cube (20)" || item.name == "Cube (21)" || item.name == "Cube (22)" || item.name == "Cube (23)" || item.name == "Cube (24)")
                {
                    item.layer = 8;
                    //item.GetComponent<Collider>().enabled = true;
                }
            }
            if (cube.name == "Cube (24)")
            {
                if (item.name == "Cube (25)" || item.name == "Cube (26)" || item.name == "Cube (27)" || item.name == "Cube (28)" || item.name == "Cube (29)" || item.name == "Cube (30)" || item.name == "Cube (31)" || item.name == "Cube (32)" || item.name == "Cube (33)" || item.name == "Cube (34)" || item.name == "Cube (35)") 
                {
                    item.layer = 8;
                    //item.GetComponent<Collider>().enabled = true;
                }
            }
            if (cube.name == "Cube (35)")
            {
                if (item.name == "Cube (36)" || item.name == "Cube (37)" || item.name == "Cube (38)" || item.name == "Cube (39)" || item.name == "Cube (40)" || item.name == "Cube (41)" || item.name == "Cube (42)" || item.name == "Cube (43)" || item.name == "Cube (44)" || item.name == "Cube (45)" || item.name == "Cube (46)" || item.name == "Cube (47)" || item.name == "Cube (48)")
                {
                    item.layer = 8;
                    //item.GetComponent<Collider>().enabled = true;
                }
            }
            if (cube.name == "Cube (48)")
            {
                if (item.name == "Cube (49)" || item.name == "Cube (50)" || item.name == "Cube (51)" || item.name == "Cube (52)" || item.name == "Cube (53)" || item.name == "Cube (54)" || item.name == "Cube (55)" || item.name == "Cube (56)" || item.name == "Cube (57)" || item.name == "Cube (58)")
                {
                    item.layer = 8;
                    //item.GetComponent<Collider>().enabled = true;
                }
            }
            if (cube.name == "Cube (58)")
            {
                if (item.name == "Cube (59)" || item.name == "Cube (60)" || item.name == "Cube (61)" || item.name == "Cube (62)" || item.name == "Cube (63)" || item.name == "Cube (64)" || item.name == "Cube (65)" || item.name == "Cube (66)" || item.name == "Cube (67)" || item.name == "Cube (68)")
                {
                    item.layer = 8;
                    //item.GetComponent<Collider>().enabled = true;
                }
            }
            if (cube.name == "Cube (68)")
            {
                if (item.name == "Cube (69)" || item.name == "Cube (70)" || item.name == "Cube (71)" || item.name == "Cube (72)" || item.name == "Cube (73)" || item.name == "Cube (74)" || item.name == "Cube (75)" || item.name == "Cube (76)" || item.name == "Cube (77)" || item.name == "Cube (78)")
                {
                    item.layer = 8;
                    //item.GetComponent<Collider>().enabled = true;
                }
            }
        }
        
    }
}
