using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrickBreaker : MonoBehaviour {

    private Animator animController;
    public AudioClip brickBreakingClip;
    public AudioClip drillingClip;
    private Image rockImage;

    // Use this for initialization
    void Start() {

    }

    public GameObject particle;
    private GameObject player;

    int brickHealth = 30;
    int subtractHealth = 10;


    // Update is called once per frame
    void Update() {
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

                        RaycastHit hitInformation;

                        if (Physics.Raycast(ray, out hitInformation, 10))
                        {
                            if (hitInformation.collider.name == particle.name)
                            {
                                PlayerMovement(hitInformation);
                                animController.SetTrigger("DrillingTrigger");
                                SoundManager.instance.playMusic(drillingClip);
                                brickHealth -= subtractHealth;
                                string materialName = "Stone_texture_" + (brickHealth / 10).ToString();
                                particle.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Stone/Materials/" + materialName);
                                if (brickHealth == 0)
                                {
                                    if (Mathf.Round((Random.value) * 100) % 5 == 0)
                                    {
                                        ArtifactPopper(particle.transform.position);
                                    }
                                    else if (Mathf.Round((Random.value) * 100) % 3 == 0)
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
        GameObject go = GameObject.Find("ArtifactCube");
        Instantiate(go, i_ParticlePosition, new Quaternion(0, 0, 0, 0));
        //go.transform.position = i_ParticlePosition;
    }

    void EnemySpawn(Vector3 i_ParticlePosition)
    {
        GameObject go = GameObject.Find("EnemyCube");
        Instantiate(go, i_ParticlePosition, new Quaternion(0, 0, 0, 0));
        //go.transform.position = i_ParticlePosition;
    }

    void PlayerMovement(RaycastHit particleHitInformation)
    {
        Ray ray = new Ray(player.transform.position, Vector3.down);
        RaycastHit hitInfo;
        bool isHit = Physics.Raycast(ray, out hitInfo, 10);
        Debug.Log(isHit);
        if (isHit)
        {
            Debug.Log("Check for collision success");
            Debug.Log(hitInfo.distance);
            if (hitInfo.distance < 1)
            {
                Debug.Log("Checking Horizontal");
                Ray checkLeftRay = new Ray(player.transform.position, Vector3.left);
                Ray checkRightRay = new Ray(player.transform.position, Vector3.right);
                RaycastHit leftHIt;
                RaycastHit rightHit;
                bool isleftHit = Physics.Raycast(checkLeftRay, out leftHIt);
                bool isRightHit = Physics.Raycast(checkRightRay, out rightHit);

                if (isleftHit || isRightHit)
                {
                    Debug.Log("Check if horizontal");
                    if (leftHIt.distance < 1 || rightHit.distance < 1)
                    {
                        Debug.Log("InTestHorizontal");
                        Vector3 testHorizontalPosition = player.transform.position + new Vector3(0, 1, 0);
                        Ray moveVerticalRightRay = new Ray(testHorizontalPosition, Vector3.right);
                        Ray moveVerticalLeftRay = new Ray(testHorizontalPosition, Vector3.left);
                        RaycastHit testVerticalHit;
                        bool cannotMoveToTopRight = Physics.Raycast(moveVerticalRightRay, out testVerticalHit);
                        bool cannotMoveToTopLeft = Physics.Raycast(moveVerticalLeftRay, out testVerticalHit);
                        if (cannotMoveToTopLeft)
                        {
                            Debug.Log("Cannot Move to top");
                            if (testVerticalHit.distance > 2)
                            {
                                player.transform.position = player.transform.position + new Vector3(-1, 0, 0);

                            }
                        }
                        else if(cannotMoveToTopRight)
                        {
                            Debug.Log("Cannot Move to top");
                            if (testVerticalHit.distance > 2)
                            {
                                player.transform.position = player.transform.position + new Vector3(+1, 0, 0);

                            }
                        }
                        else
                        {
                            Debug.Log("Can Move to the top");
                            if (isleftHit && isRightHit)
                            {
                                if (leftHIt.collider.name == particleHitInformation.collider.name)
                                {
                                    Debug.Log("IsLeftHit");
                                    player.transform.position = testHorizontalPosition + new Vector3(-1, 0, 0);
                                }
                                else
                                {
                                    Debug.Log("IsRightHit");
                                    player.transform.position = testHorizontalPosition + new Vector3(+1, 0, 0);
                                }
                            }
                            else if (isleftHit)
                            {
                                Debug.Log("IsLeftHit");
                                player.transform.position = testHorizontalPosition + new Vector3(-1, 0, 0);
                            }
                            else if (isRightHit)
                            {
                                Debug.Log("IsRightHit");
                                player.transform.position = testHorizontalPosition + new Vector3(+1, 0, 0);
                            }
                        }
                    }
                }
                else
                {
                    player.transform.position = particle.transform.position + Vector3.up;
                }
            }
            else
            {
                
            }
        }
    }
}
