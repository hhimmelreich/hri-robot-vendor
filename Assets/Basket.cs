using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Basket : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ExecuteAfterTime(float time, GameObject good)
    {
        yield return new WaitForSeconds(time);
        
        Destroy(good.GetComponent<Throwable>());
        Destroy(good.GetComponent<Interactable>());
        Destroy(good.GetComponent<Rigidbody>());

        good.transform.parent = transform;
    }
    
    private void OnCollisionEnter(Collision other)
    {
        GameObject good = other.gameObject;
        
        if (good.tag == "Goods")
        {
            StartCoroutine(ExecuteAfterTime(0.5f, good));
            
            
        }
    }
}
