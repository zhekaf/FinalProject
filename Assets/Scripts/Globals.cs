using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{

    public GameObject Player;
    public Move MoveP;
    public GameObject First_Door;
    private bool FirstLevelOver = false;
    public bool firstDoor = false;
    public bool locker = false;
    public bool tookNote = false;

    void Update()
    {
        if (locker && tookNote)
        {
            firstDoor = true;
        }

        if (FirstLevelOver && Player.transform.position.x < -40f)
        {
            Debug.Log("First Level Over!");
            Application.LoadLevel("EndGame");
        }
    }

    public void ExitFirstDoor()
    {
        if (firstDoor)
        {
            MoveP.isMovingToDoor = true;
            FirstLevelOver = true;
        }
        else 
        {
            Debug.Log("You cant get out of the room before taking the clothes from the locker and finding your notebook! ");
        }
    }

    public void OpenLocker()
    {
        locker = true;
        MoveP.isMovingToLocker = true;
    }

    public void TakeNoteBook()
    {
        tookNote = true;
        MoveP.isMovingToNoteBook = true;
    }
}
