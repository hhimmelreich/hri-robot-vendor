using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR.InteractionSystem;

public class Basket : MonoBehaviour
{
    //public float totalAmountSpent = 0f;
    public GameObject experimentManager;
    private ExperimentManager managerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        managerScript = experimentManager.GetComponent<ExperimentManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ExecuteAfterTime(float time, GameObject good)
    {
        // short delay to let item settle
        yield return new WaitForSeconds(time);
        
        // no more interaction possible
        Destroy(good.GetComponent<Throwable>());
        Destroy(good.GetComponent<Interactable>());
        Destroy(good.GetComponent<Rigidbody>());

        // make child of basket
        good.transform.parent = transform;
    }
    
    private void OnCollisionEnter(Collision other)
    {
        // reference to gameobject of collision
        GameObject good = other.gameObject;
        
        // if item is a good
        if (good.tag == "Goods")
        {
            // put item in basket
            StartCoroutine(ExecuteAfterTime(0.5f, good));

            //totalAmountSpent += good.GetComponent<Goods>().price;
            managerScript.moneySpent += good.GetComponent<Goods>().price;
            good.GetComponent<Goods>().price = 0f;

        }
    }
}
