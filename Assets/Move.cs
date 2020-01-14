using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
    
    public Transform[] transArr = new Transform[10];

    void Start()
    {
        playerZise = transform.localScale;
        
    }

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

         if (Input.GetMouseButtonDown(0))
          {
           
            setTargetPosition();
          }
       

        

         if (isMoving)
          {
            animator.SetFloat("PlayerSpeed", 1);
            moveTo();
          }
        
    }

    void setTargetPosition()
    {
        Vector3 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target = new Vector3(transArr[0].position.x, transform.position.y, transform.position.z);
        for (int i=1; i<11; i++)
        {
            if (Math.Abs(target.x - temp.x) > Math.Abs(transArr[i].position.x - temp.x))
                target = new Vector3(transArr[i].position.x, transform.position.y, transform.position.z);
        }
        
        isMoving = true;
    }

    void moveTo()
    {
        if(transform.position.x < target.x + 0.1 && transform.position.x > target.x - 0.1)
        {
            isMoving = false;
            animator.SetFloat("PlayerSpeed", 0f);

        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

    }
}