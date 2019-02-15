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
        if (!pressed)
        {
            Model.transform.Translate(-0.2f, 0, 0);
            pressed = true;
            
        }
        Debug.Log("Right_War_Button PRESSED");
     
    }
    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        if (pressed)
        {
            Model.transform.Translate(0.2f, 0, 0);
            pressed = false;
            }

        // Postac.transform.Translate(0, -5, 0);
        Debug.Log("Right_War_Button Released");
    }
    // Update is called once per frame
    void Update()
    {
        if (EventManager.ReadCard != PreviousCard && EventManager.ReadCard != "")
        {
            ButtonObject = GameObject.Find(EventManager.ReadCard + "/RightWarButton");
            ButtonObject.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
            switch (EventManager.ReadCard.Substring(0, 2))
            {
                case "du":
                    Model = GameObject.Find(EventManager.ReadCard + "/Jopek");
                    Debug.Log("Model to jopek");
                    break;
                case "da":
                    Model = GameObject.Find(EventManager.ReadCard + "/Queen");
                    break;
                case "kn":
                    Model = GameObject.Find(EventManager.ReadCard + "/knight");
                    break;
            }
           
        }
        PreviousCard = EventManager.ReadCard;
    }


}
