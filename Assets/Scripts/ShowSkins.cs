using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSkins : MonoBehaviour {

    GameObject skinsPanel;
    GameObject birdsPanel;

    // Use this for initialization
    void Start()
    {
        skinsPanel = GameObject.Find("SkinsPanel");
        skinsPanel.SetActive(false);
    }

    // Update is called once per frame
    public void OnClick()
    {
        skinsPanel = GameObject.Find("SkinsPanel");
        birdsPanel = GameObject.Find("BirdsPanel");
        if (!birdsPanel || (!birdsPanel.activeSelf))
        {
            skinsPanel.SetActive(true);
        }
        else
        {
            birdsPanel.SetActive(false);
            skinsPanel.SetActive(true);
        }
        
    }
}
