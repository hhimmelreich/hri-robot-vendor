using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendorScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
}
