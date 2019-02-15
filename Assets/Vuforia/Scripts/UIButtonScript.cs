using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;
public class UIButtonScript : MonoBehaviour{
    public Text m_MessageText;
    public Button button;

    float x, y, z;
    // Use this for initialization
    void Start () {
        button.onClick.AddListener(TaskOnClick);
         x = button.transform.position.x;
 y = button.transform.position.y;
         z = button.transform.position.z;
       
    }
	void TaskOnClick()
    {
        
        if (EventManager.ReadCard!= "")
        {
            EventManager.IncorrectCard = true;
            Debug.Log("INCORRECT CARD");
            m_MessageText.text = "Pokaz nowa karte";
        }
        else
        {
            Debug.Log("UI BTN clicked"); 
        }
    }
	// Update is called once per frame
	void Update () {
		
	}

}
