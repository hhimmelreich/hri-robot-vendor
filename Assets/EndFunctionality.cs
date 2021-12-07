using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndFunctionality : MonoBehaviour
{
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
    
    private void OnTriggerEnter(Collider other)
    {
        GameObject trigger = other.gameObject;
        
        // if item is bicycle
        if (trigger.tag == "Basket")
        {
            managerScript.SaveData();
        }
    }
}
