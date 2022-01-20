using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;

public class PointerHandler : MonoBehaviour
{
    //This script handles the actions of the pointer and the ones the pointer starts by clicking buttons
    
    public SteamVR_LaserPointer laserPointer;
    public VendorScript vendor;
    // Start is called before the first frame update

    private void Awake()
    {
        //laserPointer.PointerIn += PointerInside;
        //laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
    }

    //Checks which object the pointer is clicking on and does corresponding action
    public void PointerClick (object sender, PointerEventArgs e)
    {
        if (e.target.name == "SweetFruitsButton")
        {
            Debug.Log("Sweet Button was clicked");
            vendor.FruitsSweet();
        }else if (e.target.name == "SourButton")
        {
            Debug.Log("Sour Button was clicked");
            vendor.FruitsSour();
        }else if (e.target.name == "SweetGoodsButton")
        {
            Debug.Log("Sweet Goods Button was clicked");
            vendor.BakedGoodsSweet();
        }else if (e.target.name == "SavouryButton")
        {
            Debug.Log("Savoury Button was clicked");
            vendor.BakedGoodsSavoury();
        }
    }
  
}
