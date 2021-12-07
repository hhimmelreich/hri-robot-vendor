using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperimentManager : MonoBehaviour
{
    public string participantID;
    public string condition;
    public float moneySpent = 0f;

    //public Camera mainMenuCamera;

    private MenuState menuState = MenuState.IDSelection;
    private enum MenuState
    {
        IDSelection,
        Condition,
        Starting,
        Running
    }

    private float totalTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (menuState == MenuState.Running)
        {
            totalTime += Time.deltaTime;
        }
    }
    
    private void OnGUI()
    {
        var x = 100;
        var y = 100;
        var w = 200;
        var h = 50;

        GUI.backgroundColor = Color.cyan;
        GUI.skin.textField.fontSize = 30;

        var boxStyle = new GUIStyle(GUI.skin.box)
        {
            
            fontSize = 30,
            fontStyle = FontStyle.Bold,
            alignment = TextAnchor.MiddleCenter
        };

        var buttonStyle = new GUIStyle(GUI.skin.button)
        {
            fontSize = 28,
            alignment = TextAnchor.MiddleCenter
        };

        
        var valX = x;
        var valY = y;
        
        switch (menuState)
        {
            case MenuState.IDSelection:
                GUI.Box(new Rect(750, 490, 200, 40), "Participant ID", boxStyle);
                participantID = GUI.TextField(new Rect(750, 530, 200, 40), participantID);

                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    menuState = MenuState.Condition;
                }

                break;
            
            case MenuState.Condition:
                valX = x;
                GUI.Box(new Rect(valX, 100, w, 80), new GUIContent("ID: "+ participantID), boxStyle);
                valX += w + 2;
                GUI.backgroundColor = Color.cyan;

                if (GUI.Button(new Rect(x, Screen.height/2, w, 80), "Human Vendor", buttonStyle))
                {
                    condition = "Human Vendor";
                    menuState = MenuState.Starting;
                }
                
                if (GUI.Button(new Rect(x*3.5f, Screen.height/2, w, 80), "Robot Vendor", buttonStyle))
                {
                    condition = "Robot Vendor";
                    menuState = MenuState.Starting;
                }

                break;
            
            case MenuState.Starting:
                valX = x;
                GUI.Box(new Rect(valX, 100, w, 80), new GUIContent("ID: "+ participantID), boxStyle);
                
                GUI.backgroundColor = Color.red;
                
                valX += w;

                valX += w+2;
                GUI.Box(new Rect(valX, 100, w, 80), new GUIContent(condition), boxStyle);
                
                valX += w+2;
                
                GUI.backgroundColor = Color.cyan;
                valX = x;
                
                valX += w + 2;
                
                valX += w + 2 ;
                
                if (GUI.Button(new Rect(valX, Screen.height/2, w*1.25f, 80), "Start Experiment", buttonStyle))
                {
                    menuState = MenuState.Running;
                    StartExperiment();
                }
                
                break;

                    
            case MenuState.Running:
                    
                valX = x;
               
                int buttonwidth =(int) (w * 2);
                GUI.Box(new Rect(valX, valY, buttonwidth, 80), new GUIContent("ID: "+ participantID), boxStyle);

                valX += buttonwidth +2;
                GUI.Box(new Rect(valX , valY, buttonwidth, 80), new GUIContent("Condition: "+ condition), boxStyle);


                valX += buttonwidth+ 2;
                GUI.Box(new Rect(valX , valY, buttonwidth, 80), new GUIContent("Money Spent: "+ moneySpent), boxStyle);



                break;
                
        }
    }

    public void StartExperiment()
    {
        //mainMenuCamera.gameObject.SetActive(false);
        //instantiate vendor
        
    }
    
    // Save data to some directory, this should be called when basket is placed on bike
    public void SaveData(float moneySpent)
    {
        
    }
}
