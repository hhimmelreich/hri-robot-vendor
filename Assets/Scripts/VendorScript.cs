using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class VendorScript : MonoBehaviour
{
    public enum Location
    {
        Beverages,
        Baked,
        Fruit,
        Veggies
    };

    private Location vendorLocation = Location.Beverages;

    private bool readyForAction = true;

    public Transform beverageLoc;
    public Transform bakedLoc;
    public Transform FruitLoc;
    public Transform VeggiesLoc;

    private NavMeshAgent agent;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //agent.destination = BakedLoc.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Speak(string sentence)
    {
        FindObjectOfType<AudioManager>().Play(sentence);
        Debug.Log("Vendor Speaks");
    }

    public void AreaEntered(Location locationEntered)
    {
        // check if ready for action
        if (!readyForAction)
        {
            return;
        }

        switch (locationEntered)
        {
            case Location.Beverages:
                agent.destination = beverageLoc.position;
                break;
            case Location.Baked:
                agent.destination = bakedLoc.position;
                break;
            case Location.Fruit:
                agent.destination = FruitLoc.position;
                break;
            case Location.Veggies:
                agent.destination = VeggiesLoc.position;
                break;
        }
    }
}
