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

    public PointerHandler pointer;
    
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
                if (!drinksdialogue)
                {
                    bufferAudio = "robo_Juice";
                    drinksdialogue = true;
                }
                readyToMove = false;
                break;
            case Location.Baked:
                bufferLocation = bakedLoc.position;
                if (!bakedgoodsdialogue)
                {
                    bufferAudio = "robo_BakedGoods";
                    bakedgoodsdialogue = true;
                    bakedgoodscanvas.SetActive(true);
                    pointer.enabled = true;
                }
                readyToMove = false;
                break;
            case Location.Fruit:
                bufferLocation = FruitLoc.position;
                if (!fruitsdialogue)
                {
                    bufferAudio = "robo_FruitsQuestion";
                    fruitsdialogue = true;
                    fruitscanvas.SetActive(true);
                    pointer.enabled = true;
                }
                
                readyToMove = false;
                break;
            case Location.Veggies:
                bufferLocation = VeggiesLoc.position;
                if (!veggiedialogue)
                {
                    bufferAudio = "robo_VeggieSection";
                    veggiedialogue = true;                
                }
                readyToMove = false;
                break;
        }
    }
    //Functions for Dialogue progression called in PointerHandler Script
    public void FruitsSour()
    {
        Speak("robo_FruitsSour");
        fruitscanvas.SetActive(false);
        pointer.enabled = false;
    }
    public void FruitsSweet()
    {
        Speak("robo_FruitsSweet");
        fruitscanvas.SetActive(false);
        pointer.enabled = false;
    }

    public void BakedGoodsSavoury()
    {
        Speak("robo_SavouryGoods");
        bakedgoodscanvas.SetActive(false);
        pointer.enabled = false;
    }

    public void BakedGoodsSweet()
    {
        Speak("robe_SweetGoods");
        bakedgoodscanvas.SetActive(false);
        pointer.enabled = false;
    }
}
