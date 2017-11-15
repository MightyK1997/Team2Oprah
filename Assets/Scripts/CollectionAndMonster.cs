using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollectionAndMonster : MonoBehaviour {

    public static int money = 0;
    private Animator animController;
    static int count = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (count == 3)
        {
            SceneManager.LoadScene("WinScene");
        }
	}

    private void OnCollisionEnter(Collision col)
    {
        GameObject go;
        GameObject Image1;
        Image image;
        GameObject moneyThrower = GameObject.Find("MoneyParticles");
        ParticleSystem moneyParticles = moneyThrower.GetComponent<ParticleSystem>();
        if (col.gameObject.tag == "Artifact")
        {
            if (col.gameObject.name == "artifact_1")
            {
                go = col.gameObject;
                animController = go.GetComponent<Animator>();
                Image1 = GameObject.Find("Artifact1");
                image = Image1.GetComponent<Image>();
                image.sprite = Resources.Load<Sprite>("artifact_1");
                animController.SetTrigger("Artifact1Trigger");
                moneyParticles.Play();
                money += 100000;
                count++;
                Destroy(go);
            }
            if (col.gameObject.name == "artifact_2")
            {
                go = col.gameObject;
                animController = go.GetComponent<Animator>();
                Image1 = GameObject.Find("Artifact1");
                image = Image1.GetComponent<Image>();
                image.sprite = Resources.Load<Sprite>("artifact_1");
                animController.SetTrigger("Artifact2Trigger");
                moneyParticles.Play();
                money += 100000;
                count++;
                Destroy(go);
            }
            if (col.gameObject.name == "artifact_3")
            {
                go = col.gameObject;
                animController = go.GetComponent<Animator>();
                Image1 = GameObject.Find("Artifact1");
                image = Image1.GetComponent<Image>();
                image.sprite = Resources.Load<Sprite>("artifact_1");
                animController.SetTrigger("Artifact3Trigger");
                moneyParticles.Play();
                money += 100000;
                count++;
                Destroy(go);
            }
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