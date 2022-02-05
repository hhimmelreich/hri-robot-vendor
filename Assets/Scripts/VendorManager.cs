using System.Data.Common;
using UnityEngine;

public class VendorManager : MonoBehaviour
{
    public enum VendorType
    {
        Robot,
        Human,
        None
    }

    public GameObject robotVendor;
    public GameObject humanVendor;

    private VendorType vendorType = VendorType.None;

    private VendorScript vendor;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void SpawnVendor(VendorType newVendorType)
    {
        vendorType = newVendorType;
        if (vendorType == VendorType.Human)
        {
            humanVendor.SetActive(true);
            vendor = robotVendor.GetComponent<VendorScript>();
        }

        if (vendorType == VendorType.Robot)
        {
            robotVendor.SetActive(true);
            vendor = humanVendor.GetComponent<VendorScript>();
        }
    }
    
    
    // Referrals for all functions in VendorScript

    public void FruitsSweet()
    {
        if (vendorType == VendorType.Robot)
        {
            vendor.Speak("robo_SweetGoods");
        }

        if (vendorType == VendorType.Human)
        {
            //vendor.Speak();
        }
    }

    public void FruitsSour()
    {
        if (vendorType == VendorType.Robot)
        {
            vendor.Speak("robo_FruitsSour");
        }

        if (vendorType == VendorType.Human)
        {
            //vendor.Speak();
        }
    }

    public void BakedGoodsSweet()
    {
        if (vendorType == VendorType.Robot)
        {
            vendor.Speak("robo_FruitsSweet");
        }

        if (vendorType == VendorType.Human)
        {
            //vendor.Speak();
        }
    }

    public void BakedGoodsSavoury()
    {
        if (vendorType == VendorType.Robot)
        {
            vendor.Speak("robo_SavouryGoods");
        }

        if (vendorType == VendorType.Human)
        {
            //vendor.Speak();
        }
    }

    public void MakeReadyToSpeak()
    {
        vendor.readyToSpeak = true;
    }

    public void SpecialVoiceLine(string sentence)
    {
        if (vendorType == VendorType.Robot)
        {
            vendor.SpecialVoiceLine("robo_" + sentence);
        }
        else
        {
            vendor.SpecialVoiceLine("hum_" + sentence);
        }
    }

    public void AreaEntered(VendorScript.Location location)
    {
        vendor.AreaEntered(location, vendorType);
    }
}