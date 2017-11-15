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
        player = GameObject.Find("Player");
        animController = player.GetComponent<Animator>();
    }

    public GameObject particle;
    private GameObject player;

    int brickHealth = 30;
    int subtractHealth = 10;


    // Update is called once per frame
    void Update() {
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
        go.transform.position = new Vector3(Random.Range(-7, 7), Random.Range(-6, -9), -5);
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
            if (hitInfo.distance < 1 && (hitInfo.collider.name != particleHitInformation.collider.name))
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
                    Debug.Log(isRightHit);
                    Debug.Log("Check if horizontal");
                    Debug.Log(leftHIt.distance + "       " + rightHit.distance);
                    if ((leftHIt.distance > 0 && leftHIt.distance < 1) || (rightHit.distance > 0 && rightHit.distance < 1))
                    { 
                        Debug.Log("InTestHorizontal");
                        Vector3 testHorizontalPosition = player.transform.position + new Vector3(0, 1, 0);
                        Ray moveVerticalRightRay = new Ray(testHorizontalPosition, Vector3.right);
                        Ray moveVerticalLeftRay = new Ray(testHorizontalPosition, Vector3.left);
                        RaycastHit testVerticalRightHit;
                        RaycastHit testVerticalLeftHit;
                        bool cannotMoveToTopRight = Physics.Raycast(moveVerticalRightRay, out testVerticalRightHit);
                        bool cannotMoveToTopLeft = Physics.Raycast(moveVerticalLeftRay, out testVerticalLeftHit);
                        Debug.Log(cannotMoveToTopLeft + "      " + cannotMoveToTopRight);
                        //Debug.Log(testVerticalRightHit.distance + "       " + testVerticalRightHit.distance);
                        //Debug.Log(testVerticalLeftHit.distance + "       " + testVerticalLeftHit.distance);
                        if (cannotMoveToTopLeft || cannotMoveToTopRight)
                        {
                            if (!cannotMoveToTopLeft && (player.transform.position.x > particleHitInformation.transform.position.x))
                            {
                                player.transform.position = testHorizontalPosition + new Vector3(-1, 0, 0);
                                BrickBreakerMethod();
                            }
                            else if (!cannotMoveToTopRight &&  (player.transform.position.x < particleHitInformation.transform.position.x))
                            {
                                player.transform.position = testHorizontalPosition + new Vector3(+1, 0, 0);
                                BrickBreakerMethod();
                            }
                            else if (player.transform.position.x > particleHitInformation.transform.position.x)
                            {
                                if (testVerticalLeftHit.distance > 1)
                                {
                                    player.transform.position = testHorizontalPosition + new Vector3(-1, 0, 0);
                                    BrickBreakerMethod();
                                }
                                else
                                {
                                    BrickBreakerMethod();
                                }
                            }
                            else if(player.transform.position.x < particleHitInformation.transform.position.x)
                            {
                                if (testVerticalRightHit.distance > 1)
                                {
                                    player.transform.position = testHorizontalPosition + new Vector3(+1, 0, 0);
                                    BrickBreakerMethod();
                                }
                                else
                                {
                                    BrickBreakerMethod();
                                }
                            }
                        }
                        {
                            Debug.Log("Can Move to the top");
                            if (isleftHit && isRightHit)
                            {
                                if (leftHIt.collider.name == particleHitInformation.collider.name)
                                {
                                    Debug.Log("IsLeftHit");
                                    player.transform.position = testHorizontalPosition + new Vector3(-1, 0, 0);
                                    BrickBreakerMethod();
                                }
                                else
                                {
                                    Debug.Log("IsRightHit");
                                    player.transform.position = testHorizontalPosition + new Vector3(+1, 0, 0);
                                    BrickBreakerMethod();
                                }
                            }
                            else if (isleftHit)
                            {
                                Debug.Log("IsLeftHit");
                                player.transform.position = testHorizontalPosition + new Vector3(-1, 0, 0);
                                BrickBreakerMethod();
                            }
                            else if (isRightHit)
                            {
                                Debug.Log("IsRightHit");
                                player.transform.position = testHorizontalPosition + new Vector3(+1, 0, 0);
                                BrickBreakerMethod();
                            }
                        }
                    }
                    else
                    {
                        if (leftHIt.distance > 1 && (leftHIt.collider.name == particleHitInformation.collider.name))
                        {
                            player.transform.position = player.transform.position + new Vector3(-1, 0, 0);
                        }
                        else if (rightHit.distance > 1 && (rightHit.collider.name == particleHitInformation.collider.name))
                        {
                            player.transform.position = player.transform.position + new Vector3(1, 0, 0);
                        }
                    }
                }
                else
                {
                    player.transform.position = particle.transform.position + Vector3.up;
                    BrickBreakerMethod();
                }
            }
            else
            {
                BrickBreakerMethod();
            }
        }
    }

    void BrickBreakerMethod()
    {
        animController.SetTrigger("DrillingTrigger");
        SoundManager.instance.playMusic(drillingClip);
        brickHealth -= subtractHealth;
        string materialName = "Stone_texture_" + (brickHealth / 10).ToString();
        particle.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Stone/Materials/" + materialName);
        if (brickHealth == 0)
        {
            if (Mathf.Round((Random.value) * 100) % 3 == 0)
            {
                EnemySpawn(particle.transform.position);
            }
            Destroy(particle);
            SoundManager.instance.playMusic(brickBreakingClip);
            brickHealth = 30;
        }
    }
}