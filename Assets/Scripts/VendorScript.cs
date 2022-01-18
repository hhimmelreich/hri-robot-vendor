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

    private bool readyToMove = true;
    private bool readyToSpeak = true;

    public Transform beverageLoc;
    public Transform bakedLoc;
    public Transform FruitLoc;
    public Transform VeggiesLoc;

    private NavMeshAgent agent;
    
    private Vector3 bufferLocation;
    private string bufferAudio = "";
    
    private AudioManager audioManager;
    
    public GameObject fruitscanvas;
    public GameObject bakedgoodscanvas;
    
    private bool drinksdialogue = false;
    private bool bakedgoodsdialogue = false;
    private bool fruitsdialogue = false;
    private bool veggiedialogue = false;
    
    // this needs to be replaced by real function
    private bool audioClipPlayed = true;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //agent.destination = BakedLoc.position;

        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!readyToMove)
        {
            if (Vector3.Distance(transform.position, agent.destination) < 1)
            {
                readyToMove = true;
            }
        }

        if (!readyToSpeak)
        {
            if (audioClipPlayed)
            {
                readyToSpeak = true;
            }
        }
        
        if (readyToMove && readyToSpeak)
        {
            
            if (Vector3.Distance(bufferLocation, agent.destination) > 1)
            {
                Debug.Log("New Destination");
                agent.destination = bufferLocation;
                readyToMove = false;
            } else if (!bufferAudio.Equals(""))
            {
                audioManager.Play(bufferAudio);
                Debug.Log("Should speak now");
                bufferAudio = "";
                readyToSpeak = false;
            }
        }
        
        
        
        
    }
    public void Speak(string sentence)
    {
        audioManager.Play(sentence);
        Debug.Log("Vendor Speaks");
    }

    public void AreaEntered(Location locationEntered)
    {
        switch (locationEntered)
        {
            case Location.Beverages:
                bufferLocation = beverageLoc.position;
                bufferAudio = "robo_Juice";
                readyToMove = false;
                break;
            case Location.Baked:
                bufferLocation = bakedLoc.position;
                bufferAudio = "robo_BakedGoods";
                readyToMove = false;
                break;
            case Location.Fruit:
                bufferLocation = FruitLoc.position;
                bufferAudio = "robo_FruitsQuestion";
                readyToMove = false;
                break;
            case Location.Veggies:
                bufferLocation = VeggiesLoc.position;
                bufferAudio = "robo_VeggieSection";
                readyToMove = false;
                break;
        }
    }
}
