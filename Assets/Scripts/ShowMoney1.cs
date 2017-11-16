using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMoney1 : MonoBehaviour {

    public GameObject EnergyPanel;
    public GameObject SkinsPanel;
    public GameObject MoneyPanel;

    // Use this for initialization
    void Start()
    {
        //skinsPanel = GameObject.Find("SkinsPanel");
        MoneyPanel.SetActive(false);
    }

    // Update is called once per frame
    public void OnClick()
    {
        SkinsPanel.SetActive(false);
        EnergyPanel.SetActive(false);
        MoneyPanel.SetActive(true);
    }
}
