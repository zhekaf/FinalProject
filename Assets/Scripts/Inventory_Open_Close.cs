using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Open_Close : MonoBehaviour
{
    public Animator InvButtonAnim;
    private bool slideIn = false;
    public UnityEngine.UI.Image image;
    //private float trans = 0f;


    public void InvButtonMethod()
    {
        if(slideIn == false)
        {
            var tempColor = image.color;
            tempColor.a = 0f;
            image.color = tempColor;
            slideIn = true;
            InvButtonAnim.SetBool("OpenInv", slideIn);
        }
        else if (slideIn == true)
        {
            var tempColor = image.color;
            tempColor.a = 1f;
            image.color = tempColor;
            slideIn = false;
            InvButtonAnim.SetBool("OpenInv", slideIn);
        }
    }
}
