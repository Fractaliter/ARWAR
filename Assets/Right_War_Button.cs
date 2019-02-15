using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class Right_War_Button : MonoBehaviour, IVirtualButtonEventHandler
{

    public GameObject ButtonObject;
    public GameObject Model;
    string PreviousCard;
    // Use this for initialization
    bool pressed = false;
    void Start()
    { 
    }
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        if (pressed == false )
        {
            pressed = true;
              switch (EventManager.ReadCard.Substring(0, 2))
                 {
                 case "JO":
                     Model = GameObject.Find(EventManager.ReadCard + "/Jopek");
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
            if (EventManager.modelside < 104)
            {
                Model.transform.Translate(-0.02f, 0, 0);
                Debug.Log("Right_War_Button PRESSED");
                EventManager.modelside++;
                
            }
        }    
    }
    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        if (pressed )
        {
            pressed = false;
        }
    }
    void Update()
    {
        if (EventManager.ReadCard != PreviousCard && EventManager.ReadCard != "")
        {
            ButtonObject = GameObject.Find(EventManager.ReadCard + "/RightWarButton");
            ButtonObject.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        }
        PreviousCard = EventManager.ReadCard;
    }


}
