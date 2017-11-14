using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHealthBar : MonoBehaviour {

    GameObject healthSlider;

    Image healthSliderImage;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(OnDestroyScript.battery);
        healthSlider = GameObject.Find("HealthBarImage");
        healthSliderImage = healthSlider.GetComponent<Image>();
        if (OnDestroyScript.battery % 10 == 0)
        {
            string spriteName = "MainBar" + (OnDestroyScript.battery / 10).ToString();
            healthSliderImage.sprite = Resources.Load<Sprite>("HealthBarImages/" + spriteName);
        }
    }
}
