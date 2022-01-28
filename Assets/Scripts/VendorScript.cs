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
    public bool readyToSpeak = true;

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

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = bakedLoc.position;
        //Speak("robo_Intro");

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
                readyToSpeak = false;
                StartCoroutine(StartDialog(bufferAudio));
                Debug.Log("Should speak now");
                bufferAudio = "";
            }
        }
        
        
        
        
    }
    public void Speak(string sentence)
    {
        audioManager.Play(sentence);
        Debug.Log("Vendor Speaks");
    }


    IEnumerator StartDialog(string audioName)
    {
        switch (audioName)
        {
            case "robo_Wine":
                drinksdialogue = true;
                break;
            case "robo_BakedGoods":
                bakedgoodsdialogue = true;
                while (!readyToSpeak)
                {
                    yield return null;
                }
                bakedgoodscanvas.SetActive(true);
                break;
            case "robo_FruitsQuestion":
                fruitsdialogue = true;
                while (!readyToSpeak)
                {
                    yield return null;
                }
                fruitscanvas.SetActive(true);
                break;
            case "robo_VeggieSection":
                veggiedialogue = true; 
                break;
            default:
                break;
        }
    }

    public void SpecialVoiceLine(string name)
    {
        StartCoroutine(PlayVoiceLine(name));
    }

    IEnumerator PlayVoiceLine(string name)
    {
        while(!readyToSpeak | !readyToMove)
        {
            yield return null;
        }
        audioManager.Play(name);
        readyToSpeak = false;
        Debug.Log("coroutine garlic");
        yield break;
    }
    
    public void AreaEntered(Location locationEntered)
    {
        // switch case depending on which location is entered
        switch (locationEntered)
        {
            case Location.Beverages:
                bufferLocation = beverageLoc.position;
                if (!drinksdialogue)
                {
                    bufferAudio = "robo_Wine";
                }
                break;
            case Location.Baked:
                bufferLocation = bakedLoc.position;
                if (!bakedgoodsdialogue)
                {
                    bufferAudio = "robo_BakedGoods";
                    //pointer.enabled = true;
                }
                break;
            case Location.Fruit:
                bufferLocation = FruitLoc.position;
                if (!fruitsdialogue)
                {
                    bufferAudio = "robo_FruitsQuestion";
                    //pointer.enabled = true;
                }
                break;
            case Location.Veggies:
                bufferLocation = VeggiesLoc.position;
                if (!veggiedialogue)
                {
                    bufferAudio = "robo_VeggieSection";
                }
                break;
        }
    }
    //Functions for Dialogue progression called in PointerHandler Script
    public void FruitsSour()
    {
        Speak("robo_FruitsSour");
        fruitscanvas.SetActive(false);
        //pointer.enabled = false;
    }
    public void FruitsSweet()
    {
        Speak("robo_FruitsSweet");
        fruitscanvas.SetActive(false);
        //pointer.enabled = false;
    }

    public void BakedGoodsSavoury()
    {
        Speak("robo_SavouryGoods");
        bakedgoodscanvas.SetActive(false);
        //pointer.enabled = false;
    }

    public void BakedGoodsSweet()
    {
        Speak("robo_SweetGoods");
        bakedgoodscanvas.SetActive(false);
        //pointer.enabled = false;
    }
}
