using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollectionAndMonster : MonoBehaviour {

    public static int money = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Artifact")
        {
            MiddleFunction();
            SceneManager.LoadScene("WinScene");
        }
        else if (col.gameObject.tag == "Enemy")
        {
            MiddleFunction();
            OnDestroyScript.battery -= 5;
            Destroy(col.gameObject);
        }
    }
    void MiddleFunction()
    {
        E_Wait();
    }

    IEnumerator E_Wait()
    {
        yield return new WaitForSeconds(0.2f);
    }
}