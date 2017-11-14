using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MicroTransactionsScript : MonoBehaviour {

    Canvas[] canvasList;
    Canvas UICanvas;
    public Canvas microCanvas;

	// Use this for initialization
	void Start () {
        microCanvas.enabled = false;
	}
	
	// Update is called once per frame
	public void OnClickMethod () {
        canvasList = Canvas.FindObjectsOfType<Canvas>();
        foreach (var item in canvasList)
        {
            if (item.GetComponent<Canvas>().name == "UI Canvas")
            {
                UICanvas = item.GetComponent<Canvas>();
            }
            if (item.GetComponent<Canvas>().name == "MicroCanvas")
            {
                microCanvas = item.GetComponent<Canvas>();
            }
        }

        UICanvas.enabled = false;
        microCanvas.enabled = true;
        microCanvas.GetComponent<CanvasRenderer>().SetAlpha(500000);
        microCanvas.GetComponent<CanvasRenderer>().SetColor(Color.black);
    }
}
