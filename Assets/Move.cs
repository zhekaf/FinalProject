using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 1.5f;
    public Vector3 target;
    private float MouseX;
    public bool isMoving = false;
    private float playerDistSizeX;
    private float playerDistSizeY;
    private float playerDistSizeZ;
    private Vector3 playerZise;
    public Animator animator;
   

    void Start()
    {
        playerZise = transform.localScale;
        
        //target = transform.position;
        // MouseX = transform.position.x;
    }

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

         if (Input.GetMouseButtonDown(0))
          {
            // MouseX = Input.GetAxis("Mouse X");
            //target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            setTargetPosition();
          }
        //transform.position.x = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        /* target = new Vector2(MouseX, transform.position.y);

        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);*/

        

         if (isMoving)
          {
             moveTo();
            animator.SetFloat("PlayerSpeed", 1);
          }
          target.y = transform.position.y;
          target.z = transform.position.z;
          playerDistSizeX = playerZise.x + transform.position.x / 50;
          playerDistSizeY = playerZise.y + transform.position.x / 50;
          playerDistSizeZ = playerZise.z + transform.position.x / 50;

          //transform.localScale.x = playerDistSizeX;

          transform.localScale = new Vector3(playerDistSizeX, playerDistSizeY, playerDistSizeZ);
    }

    void setTargetPosition()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        isMoving = true;
    }

    void moveTo()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if(transform.position.x < target.x + 0.1 && transform.position.x > target.x - 0.1)
        {
            isMoving = false;
            animator.SetFloat("PlayerSpeed", 0f);

        }

    }
}