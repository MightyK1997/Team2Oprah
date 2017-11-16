using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHealthBar : MonoBehaviour {

    GameObject healthSlider;

    public GameObject EnergyPanel;
    public GameObject SkinsPanel;
    public GameObject MoneyPanel;
    public GameObject microCanvas;
    Canvas mCanvas;

    Image healthSliderImage;

    // Use this for initialization
    void Start()
    {
        EnergyPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider = GameObject.Find("HealthBarImage");
        healthSliderImage = healthSlider.GetComponent<Image>();
        if (OnDestroyScript.battery >= 0)
        {
            if ((OnDestroyScript.battery % 10 == 0))
            {
                string spriteName = "MainBar" + (OnDestroyScript.battery / 10).ToString();
                healthSliderImage.sprite = Resources.Load<Sprite>("HealthBarImages/" + spriteName);
            }
        }
        else
        {
            mCanvas = microCanvas.GetComponent<Canvas>();
            mCanvas.enabled = true;
            SkinsPanel.SetActive(false);
            MoneyPanel.SetActive(false);
            EnergyPanel.SetActive(true);
        }
    }
}
