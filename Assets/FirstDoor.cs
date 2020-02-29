using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstDoor : MonoBehaviour
{
    public GameObject First_Door;
    //ReferencedScript refScript = GetComponent<Globals>();

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Globals>().firstDoor)
        {
            First_Door.SetActive(true);
        }
    }
}
