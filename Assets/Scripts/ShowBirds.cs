using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowBirds : MonoBehaviour {

    public GameObject birdsPanel;
    public GameObject skinsPanel;

	// Use this for initialization
	void Start () {
        //birdsPanel = GameObject.Find("BirdsPanel");
        birdsPanel.SetActive(false);
    }

    // Update is called once per frame
    public void OnClick() {
        //birdsPanel = GameObject.Find("BirdsPanel");
        //skinsPanel = GameObject.Find("SkinsPanel");
        //Debug.Log(skinsPanel + "" + birdsPanel);
        if (!skinsPanel || (!skinsPanel.activeSelf))
        {
            birdsPanel.SetActive(true);
        }
        else
        {
            skinsPanel.SetActive(false);
            birdsPanel.SetActive(true);
        }
        
	}
}
