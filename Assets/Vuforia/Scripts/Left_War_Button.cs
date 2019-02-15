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
        ButtonObject = GameObject.Find("LeftWarButton");
        ButtonObject.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);

    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        if (!pressed)
        {
            Model.transform.Translate(0.2f, 0, 0);
        }
        Debug.Log("LeftWarButton PRESSED");
        pressed = true;
    }
    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        if (pressed)
        {
            Model.transform.Translate(-0.2f, 0, 0);
        }
        pressed = false;
        // Postac.transform.Translate(0, -5, 0);
        Debug.Log("LeftWarButton Released");
    }
    // Update is called once per frame
    void Update()
    {
        if (EventManager.ReadCard != PreviousCard && EventManager.ReadCard != "")
        {
            ButtonObject = GameObject.Find(EventManager.ReadCard + "/LeftWarButton");
            ButtonObject.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
            switch (EventManager.ReadCard.Substring(0, 2))
            {
                case "du":
                    Model = GameObject.Find(EventManager.ReadCard + "/Jopek");
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
