using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBreaker : MonoBehaviour {

    private Animator animController;
    public AudioClip brickBreakingClip;
    public AudioClip drillingClip;

	// Use this for initialization
	void Start () {
		
	}

    public GameObject particle;
    private GameObject player;

    int brickHealth = 30;
    int subtractHealth = 10;


	// Update is called once per frame
	void Update () {
        player = GameObject.Find("Player");
        animController = player.GetComponent<Animator>();
        if (particle.layer == 8)
        {
            if (Input.touchCount > 0)
            {
                for (int i = 0; i < Input.touchCount; i++)
                {
                    if (Input.GetTouch(i).phase == TouchPhase.Began)
                    {
                        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);

                        Vector3 touchPos = new Vector3(ray.origin.x, ray.origin.y, ray.origin.z);

                        RaycastHit hitInformation;

                        if (Physics.Raycast(ray, out hitInformation, 10))
                        {
                            if (hitInformation.collider.name == particle.name)
                            {
                                animController.SetTrigger("DrillingTrigger");
                                SoundManager.instance.playMusic(drillingClip);
                                brickHealth -= subtractHealth;
                                if (brickHealth == 0)
                                {
                                    Debug.Log(Random.value);
                                    if (Mathf.Round((Random.value)*100) % 5 == 0)
                                    {
                                        ArtifactPopper(particle.transform.position);
                                    }
                                    else if (Mathf.Round((Random.value)*100) % 3 == 0)
                                    {
                                        EnemySpawn(particle.transform.position);
                                    }
                                    Destroy(particle);
                                    SoundManager.instance.playMusic(brickBreakingClip);



                                    brickHealth = 50;
                                }
                            }
                        }
                    }
                }
            }
        }
	}

    void ArtifactPopper(Vector3 i_ParticlePosition)
    {
        GameObject go = GameObject.Find("Artifact");
        Instantiate(go, i_ParticlePosition, new Quaternion(0,0,0,0));
        //go.transform.position = i_ParticlePosition;
    }

    void EnemySpawn(Vector3 i_ParticlePosition)
    {
        GameObject go = GameObject.Find("Enemy");
        Instantiate(go, i_ParticlePosition, new Quaternion(0, 0, 0, 0));
    }
}
