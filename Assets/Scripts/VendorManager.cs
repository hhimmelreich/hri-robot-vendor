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
        if (vendorType == VendorType.Human) humanVendor.SetActive(true);
        if (vendorType == VendorType.Robot) robotVendor.SetActive(true);
    }
    
    
    // Referrals for all functions in VendorScript
    
}