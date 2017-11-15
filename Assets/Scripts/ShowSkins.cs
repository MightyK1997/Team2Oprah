using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSkins : MonoBehaviour {

    public GameObject skinsPanel;

    // Use this for initialization
    void Start()
    {
        //skinsPanel = GameObject.Find("SkinsPanel");
        skinsPanel.SetActive(false);
    }

    // Update is called once per frame
    public void OnClick()
    {
           skinsPanel.SetActive(true);
    }
}
