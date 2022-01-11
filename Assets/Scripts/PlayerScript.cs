using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    GameObject vendor;
    VendorScript vscript;
    
    // Start is called before the first frame update
    void Start()
    {
         //Calls Vendor Script to get access to Speak Function
        vendor = GameObject.Find("Vendor");
        vscript = (VendorScript)vendor.GetComponent(typeof(VendorScript));
    }

    // Update is called once per frame
    void Update()
    {
 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Vegetables")
        {
            //if vendor is human
            
            vscript.Speak("hum_VeggieSection");
            Debug.Log("sentence triggered");
        }
    }
}

