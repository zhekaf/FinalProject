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
    public bool isMovingToLocker = false;
    public bool isMovingToDoor = false;
    public bool isMovingToNoteBook = false;
    public SpriteRenderer mySpriteRenderer;
    private float MovingSide = 0f;
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

         if (Input.GetMouseButtonDown(0) && !isMovingToLocker && !isMovingToDoor && !isMovingToNoteBook)
          {
           
            setTargetPosition();
          }
       

        

         if (isMoving)
          {
            if (target.x > transform.position.x)
            {
                MovingSide = 1f;
            }
            else
            {
                MovingSide = -1f;
            }
            animator.SetFloat("PlayerSpeed", 1f);
            moveTo();
          }

        if (isMovingToLocker && !isMovingToDoor && !isMovingToNoteBook)
        {
            target = new Vector3(-2.8f, transform.position.y, transform.position.z);
            if (target.x > transform.position.x)
            {
                MovingSide = 1f;
            }
            else
            {
                MovingSide = -1f;
            }
            animator.SetBool("locker", true);
            moveToLocker();
        }

        if (isMovingToDoor && !isMovingToLocker && !isMovingToNoteBook)
        {
            target = new Vector3(-41f, transform.position.y, transform.position.z);
            if (target.x > transform.position.x)
            {
                MovingSide = 1f;
            }
            else
            {
                MovingSide = -1f;
            }
            animator.SetBool("door", true);
            moveToDoor();
        }

        if (isMovingToNoteBook && !isMovingToLocker && !isMovingToDoor)
        {
            target = new Vector3(18f, transform.position.y, transform.position.z);
            if (target.x > transform.position.x)
            {
                MovingSide = 1f;
            }
            else
            {
                MovingSide = -1f;
            }
            animator.SetBool("notebook", true);
            moveToNoteBook();
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
        if(MovingSide == 1) 
        { 
            mySpriteRenderer.flipX = true;
        }
        else 
        {
            mySpriteRenderer.flipX = false;
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    void moveToLocker()
    {
        if (transform.position.x < target.x + 0.1 && transform.position.x > target.x - 0.1)
        {
            isMovingToLocker = false;
            animator.SetBool("locker", false);

        }
        if (MovingSide == 1)
        {
            mySpriteRenderer.flipX = true;
        }
        else
        {
            mySpriteRenderer.flipX = false;
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    void moveToDoor()
    {
        if (transform.position.x < target.x + 0.1 && transform.position.x > target.x - 0.1)
        {
            isMovingToDoor = false;
            animator.SetBool("door", false);

        }
        if (MovingSide == 1)
        {
            mySpriteRenderer.flipX = true;
        }
        else
        {
            mySpriteRenderer.flipX = false;
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    void moveToNoteBook()
    {
        if (transform.position.x < target.x + 0.1 && transform.position.x > target.x - 0.1)
        {
            isMovingToNoteBook = false;
            animator.SetBool("notebook", false);

        }
        if (MovingSide == 1)
        {
            mySpriteRenderer.flipX = true;
        }
        else
        {
            mySpriteRenderer.flipX = false;
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}