using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class Left_War_Button : MonoBehaviour, IVirtualButtonEventHandler
{

    public GameObject ButtonObject;
    public GameObject Model;
    // Use this for initialization
    bool pressed = false;
    string PreviousCard;
    void Start()
    {
        //ButtonObject = GameObject.Find("LeftWarButton");
       // ButtonObject.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);

    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        if (pressed == false)
        {
            pressed = true;
            
                switch (EventManager.ReadCard.Substring(0, 2))
                {
                case "JO":
                    Model = GameObject.Find(EventManager.ReadCard + "/Jopek");
                   
                    // Debug.Log("Model to jopek");
                    break;
                case "DA":
                    Model = GameObject.Find(EventManager.ReadCard + "/Queen");
                    
                    break;
                case "KR":
                    Model = GameObject.Find(EventManager.ReadCard + "/knight");
                    
                    break;
                default:
                    Model = GameObject.Find(EventManager.ReadCard + "/NUMBER");
                   
                    break;
                }

    


             if (EventManager.modelside > -104)
             {
                 Debug.Log("LeftWarButton PRESSED");
                 Model.transform.Translate(0.02f, 0, 0);
                 EventManager.modelside--;
             }
           

        }
        
    }
    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        if (pressed)
        {
           // Debug.Log("LeftWarButton Released");
            pressed = false;
        }
     
        // Postac.transform.Translate(0, -5, 0);

        //Debug.Log("LeftWarButton Released");
    }
    // Update is called once per frame
    void Update()
    {
        if (EventManager.ReadCard != PreviousCard && EventManager.ReadCard != "")
        {
            ButtonObject = GameObject.Find(EventManager.ReadCard + "/LeftWarButton");
            ButtonObject.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
          

        }
        PreviousCard = EventManager.ReadCard;
    }


}
