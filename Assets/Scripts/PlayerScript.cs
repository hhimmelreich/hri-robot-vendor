using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject vendor;
    private VendorScript vscript;
    
    // Start is called before the first frame update
    void Start()
    {
        //Calls Vendor Script to get access to Speak Function
        vscript = vendor.GetComponent<VendorScript>();
        //vscript = (VendorScript)vendor.GetComponent(typeof(VendorScript));
    }

    // Update is called once per frame
    void Update()
    {
 
    }
    private void OnTriggerEnter(Collider other)
    {
        switch(other.tag)
        {
            case "Drinks":
                vscript.AreaEntered(VendorScript.Location.Beverages);
                //vscript.Speak("hum_VeggieSection");
                Debug.Log("Beverages entered");
                break;
            case "Baked Goods":
                vscript.AreaEntered(VendorScript.Location.Baked);
                //vscript.Speak("hum_VeggieSection");
                break;
            case "Fruits":
                vscript.AreaEntered(VendorScript.Location.Fruit);
                //vscript.Speak("hum_VeggieSection");
                break;
            case "Vegetables":
                vscript.AreaEntered(VendorScript.Location.Veggies);
                //vscript.Speak("hum_VeggieSection");
                Debug.Log("Veggies entered");
                break;
            
        }

    }
}

