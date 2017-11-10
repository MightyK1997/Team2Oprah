﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlLeft : MonoBehaviour
{
    private Animator animController;
    public void MovePlayer()
    {
        GameObject player = GameObject.Find("Player");
        Debug.Log(player.transform.position.x);
        animController = player.GetComponent<Animator>();
        animController.SetTrigger("PlayerWalking");
        if (player.transform.position.x > -5)
        {
            player.transform.position -= new Vector3(1f, -1f, 0);
        }
    }

    //private Vector2 initialTouchPosition = -Vector2.one;
    //public float moveTime = 0.1f;           //Time it will take object to move, in seconds.
    //public LayerMask blockingLayer;         //Layer on which collision will be checked.


    //private BoxCollider boxCollider;      //The BoxCollider2D component attached to this object.
    //private Rigidbody rb2D;               //The Rigidbody2D component attached to this object.
    //private float inverseMoveTime;          //Used to make movement more efficient.

    //// Update is called once per frame
    //void Update()
    //{
    //    int horizontal = 0;
    //    int vertical = 0;
    //    GameObject player = GameObject.Find("TestCube");
    //    //if (Input.touchCount > 0)
    //    //{
    //    //    Touch myTouch = Input.touches[0];

    //    //    if (myTouch.phase == TouchPhase.Began)
    //    //    {
    //    //        initialTouchPosition = myTouch.position;
    //    //    }
    //    //    else if (myTouch.phase == TouchPhase.Ended && initialTouchPosition.x >= 0)
    //    //    {
    //    //        Vector2 touchEnd = myTouch.position;
    //    //        //Debug.Log(touchEnd);
    //    //        float x = touchEnd.x - initialTouchPosition.x;
    //    //        //Debug.Log(initialTouchPosition.x);
    //    //        //Debug.Log(x);
    //    //        float y = touchEnd.y - initialTouchPosition.y;
    //    //        //Debug.Log(y);
    //    //        initialTouchPosition.x = -1;
    //    //        if (Mathf.Abs(x) > Mathf.Abs(y))
    //    //        {
    //    //            horizontal = x > 0 ? 1 : -1;
    //    //        }
    //    //        else
    //    //            vertical = y > 0 ? 1 : -1;
    //    //    }
    //    //}
    //    //if (horizontal != 0 || vertical != 0)
    //    //{
    //    //    RaycastHit rayCastHit;

    //    //}

    //    if (true)
    //    {

    //    }
    //}


    ////Protected, virtual functions can be overridden by inheriting classes.
    ////protected virtual void Start()
    ////{
    ////    //Get a component reference to this object's BoxCollider2D
    ////    boxCollider = GetComponent<BoxCollider>();

    ////    //Get a component reference to this object's Rigidbody2D
    ////    rb2D = GetComponent<Rigidbody>();

    ////    //By storing the reciprocal of the move time we can use it by multiplying instead of dividing, this is more efficient.
    ////    inverseMoveTime = 1f / moveTime;
    ////}


    //////Move returns true if it is able to move and false if not. 
    //////Move takes parameters for x direction, y direction and a RaycastHit2D to check collision.
    ////protected bool Move(int xDir, int yDir, out RaycastHit hit)
    ////{
    ////    //Store start position to move from, based on objects current transform position.
    ////    Vector3 start = transform.position;

    ////    Debug.Log(start);

    ////    // Calculate end position based on the direction parameters passed in when calling Move.
    ////    Vector3 end = start + new Vector3(xDir, yDir, start.z);

    ////    Debug.Log(end);

    ////    //Disable the boxCollider so that linecast doesn't hit this object's own collider.
    ////    boxCollider.enabled = false;

    ////    //Cast a line from start point to end point checking collision on blockingLayer.=

    ////    //Re-enable boxCollider after linecast


    ////    //Check if anything was hit
    ////    if (Physics.Linecast(start, end, out hit, blockingLayer))
    ////    {
    ////        //If nothing was hit, start SmoothMovement co-routine passing in the Vector2 end as destination
    ////        StartCoroutine(SmoothMovement(end));

    ////        //Return true to say that Move was successful
    ////        return true;
    ////    }
    ////    boxCollider.enabled = true;

    ////    //If something was hit, return false, Move was unsuccessful.
    ////    return false;
    ////}


    //////Co-routine for moving units from one space to next, takes a parameter end to specify where to move to.
    ////protected IEnumerator SmoothMovement(Vector3 end)
    ////{
    ////    //Calculate the remaining distance to move based on the square magnitude of the difference between current position and end parameter. 
    ////    //Square magnitude is used instead of magnitude because it's computationally cheaper.
    ////    float sqrRemainingDistance = (transform.position - end).sqrMagnitude;

    ////    //While that distance is greater than a very small amount (Epsilon, almost zero):
    ////    while (sqrRemainingDistance > float.Epsilon)
    ////    {
    ////        //Find a new position proportionally closer to the end, based on the moveTime
    ////        Vector3 newPostion = Vector3.MoveTowards(rb2D.position, end, inverseMoveTime * Time.deltaTime);

    ////        //Call MovePosition on attached Rigidbody2D and move it to the calculated position.
    ////        rb2D.MovePosition(newPostion);

    ////        //Recalculate the remaining distance after moving.
    ////        sqrRemainingDistance = (transform.position - end).sqrMagnitude;

    ////        //Return and loop until sqrRemainingDistance is close enough to zero to end the function
    ////        yield return null;
    ////    }
    ////}


    //////The virtual keyword means AttemptMove can be overridden by inheriting classes using the override keyword.
    //////AttemptMove takes a generic parameter T to specify the type of component we expect our unit to interact with if blocked (Player for Enemies, Wall for Player).
    ////protected void AttemptMove<T>(int xDir, int yDir)
    ////    where T : Component
    ////{
    ////    //Hit will store whatever our linecast hits when Move is called.
    ////    RaycastHit hit;

    ////    //Set canMove to true if Move was successful, false if failed.
    ////    bool canMove = Move(xDir, yDir, out hit);

    ////    //Check if nothing was hit by linecast
    ////    if (hit.transform == null)
    ////        //If nothing was hit, return and don't execute further code.
    ////        return;

    ////    //Get a component reference to the component of type T attached to the object that was hit
    ////    T hitComponent = hit.transform.GetComponent<T>();

    ////    //If canMove is false and hitComponent is not equal to null, meaning MovingObject is blocked and has hit something it can interact with.
    ////    if (!canMove && hitComponent != null)

    ////        //Call the OnCantMove function and pass it hitComponent as a parameter.
    ////        OnCantMove(hitComponent);
    ////}


    //////The abstract modifier indicates that the thing being modified has a missing or incomplete implementation.
    //////OnCantMove will be overriden by functions in the inheriting classes.
    ////protected void OnCantMove<T>(T component)
    ////    where T : Component
    ////{ }
}