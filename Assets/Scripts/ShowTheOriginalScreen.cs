using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowTheOriginalScreen : MonoBehaviour {

    Canvas[] canvasList;
    public Canvas UICanvas;
    public Canvas microCanvas;
    public GameObject energyPanel;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    public void OnClick()
    {
        canvasList = Canvas.FindObjectsOfType<Canvas>();
        foreach (var item in canvasList)
        {
            Debug.Log(item);
            Debug.Log(item.GetComponent<Canvas>().name);
            if (item.GetComponent<Canvas>().name == "UI Canvas")
            {
                UICanvas = item.GetComponent<Canvas>();
            }
            if (item.GetComponent<Canvas>().name == "MicroCanvas")
            {
                microCanvas = item.GetComponent<Canvas>();
            }
        }
        if (energyPanel.activeSelf)
        {
            SceneManager.LoadScene("StartScene");
        }
        microCanvas.enabled = false;
        UICanvas.enabled = true;
    }
}

