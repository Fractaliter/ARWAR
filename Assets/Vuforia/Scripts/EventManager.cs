using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class EventManager : MonoBehaviour {

    // Use this for initialization
    public GameObject Swords;
    public GameObject Card;
    public Sprite[] Sprites;
    public static bool Tracked;
    public static float targetTrackedTime = 5.0f;
    public float targetARWARTime = 5.0f;
    public float targetTime2 = 5.0f;
    public float targetWinnerTime = 3.0f;
    public float targetDrawTime = 2.0f;
    public Text m_MessageText;
    public Text m_CardsText;
    public static string ReadCard = "";
    public static int Value1 = 0;
    public static int Value2 = 0;
    public int Score1 = 0;
    public int Score2 = 0;
    string PreviousCard;
    List<string> Talia = new List<string>();
    int number;
    bool Score;
    public static bool IncorrectCard;
    public static bool War;
    public static bool ARWarwait;
    int side =1;
    public static int modelside = 0;
    int OPmodi = 0;
    GameObject WarModel;

    void Start ()
    {
        Tracked = false;
        Card.SetActive(false);
        CreateList(Sprites);
        War = false;
        m_MessageText.text = "AR WAR";
        Swords.SetActive(false);
    }
    void Update()
    {

        if(IncorrectCard)
        {
            targetTrackedTime = 5.0f;
        }
        if(ARWarwait)
        {
            
                targetARWARTime -= Time.deltaTime;

                m_MessageText.text = "ARWAR Wybierz strone modelu";

            if (targetARWARTime <= 0)
            {
                side = Random.Range(1, 3);
                switch (side)
                {
                    case 1:
                        
                        if (modelside == 0)
                        {
                            m_MessageText.text = "PRZEGRANO WOJNE";
                            Score2++;
                        }
                        else
                        {
                            m_MessageText.text = "WYGRANO WOJNE";
                            Score1++;
                        }
                        break;
                    case 2:
                        WarModel.transform.Rotate(0, 45, 0);
                        if (modelside>0)
                        {
                            m_MessageText.text = "PRZEGRANO WOJNE";
                            Score2++;
                        }
                        else
                        {
                            m_MessageText.text = "WYGRANO WOJNE";
                            Score1++;
                        }
                        break;
                    case 3:
                        WarModel.transform.Rotate(0, -45, 0);
                        if (modelside<0)
                        {
                            m_MessageText.text = "PRZEGRANO WOJNE";
                            Score2++;
                        }
                        else
                        {
                            m_MessageText.text = "WYGRANO WOJNE";
                            Score1++;
                        }
                        break;
                }
                Score = true;
                ARWarwait = false;
            }
        }
        OPmodi = modelside;
        if (!War)
        {

            GameObject OpModelJ = GameObject.Find("OPModelJ");
            if (OpModelJ != null)
            {
                OpModelJ.SetActive(false);
             
            }
            GameObject OpModelD = GameObject.Find("OPModelD");
            if (OpModelD != null)
            {
                OpModelD.SetActive(false);

            }
            GameObject OpModelK = GameObject.Find("OPModelK");
            if (OpModelK != null)
            {
                OpModelK.SetActive(false);

            }
            GameObject OpModelN = GameObject.Find("OPModelN");
            if (OpModelN != null)
            {
                OpModelN.SetActive(false);

            }

        }
        if (Talia.Count == 0)
        {
            m_MessageText.text = "KONIEC GRY";
        }
        if (Tracked && PreviousCard != ReadCard && !IncorrectCard)
        {
            targetTrackedTime -= Time.deltaTime;
           
        }
        if (targetTrackedTime <= 0.0f)
        {
            Swords.SetActive(true);
            PreviousCard = ReadCard;
            switch (ReadCard.Substring(0, 2))
            {
                case "2_":
                    m_MessageText.text = "Wykryto 2";
                    Value1 = 2;
                    break;
                case "3_":
                    m_MessageText.text = "Wykryto 3";
                    Value1 = 3;
                    break;
                case "4_":
                    m_MessageText.text = "Wykryto 4";
                    Value1 = 4;
                    break;
                case "5_":
                    m_MessageText.text = "Wykryto 5";
                    Value1 = 5;
                    break;
                case "6_":
                    m_MessageText.text = "Wykryto 6";
                    Value1 = 6;
                    break;
                case "7_":
                    m_MessageText.text = "Wykryto 7";
                    Value1 =7;
                    break;
                case "8_":
                    m_MessageText.text = "Wykryto 8";
                    Value1 = 8;
                    break;
                case "9_":
                    m_MessageText.text = "Wykryto 9";
                    Value1 = 9;
                    break;
                case "10":
                    m_MessageText.text = "Wykryto 10";
                    Value1 = 10;
                    break;
                case "AS":
                    m_MessageText.text = "Wykryto ASA";
                    Value1 = 14;
                    break;

                case "JO":
                    m_MessageText.text = "Wykryto jopka";
                    Value1 = 11;
                    break;
                case "DA":
                    m_MessageText.text = "Wykryto dame";
                    Value1 = 12;
                    break;
                case "KR":
                    m_MessageText.text = "Wykryto krola";
                    Value1 = 13;
                    break;
            }
            targetTime2 -= Time.deltaTime;
            if (targetTime2 <= 0.0f)
            {
                
                Card.SetActive(true);
                number = Random.Range(0, Talia.Count);
                switch (Talia[number].ToString().Substring(0, 2))
                {
                    case "2_":
                        m_MessageText.text = "Komputer wylosował  2";
                        Value2 = 2;
                        break;
                    case "3_":
                        m_MessageText.text = "Komputer wylosował  3";
                        Value2 = 3;
                        break;
                    case "4_":
                        m_MessageText.text = "Komputer wylosował  4";
                        Value2 = 4;
                        break;
                    case "5_":
                        m_MessageText.text = "Komputer wylosował  5";
                        Value2 = 5;
                        break;
                    case "6_":
                        m_MessageText.text = "Komputer wylosował  6";
                        Value2 = 6;
                        break;
                    case "7_":
                        m_MessageText.text = "Komputer wylosował  7";
                        Value2 = 7;
                        break;
                    case "8_":
                        m_MessageText.text = "Komputer wylosował  8";
                        Value2 = 8;
                        break;
                    case "9_":
                        m_MessageText.text = "Komputer wylosował  9";
                        Value2 = 9;
                        break;
                    case "10":
                        m_MessageText.text = "Komputer wylosował  10";
                        Value2 = 10;
                        break;
                    case "AS":
                        m_MessageText.text = "Komputer wylosował  ASA";
                        Value2 = 14;
                        break;
                    case "JO":
                        m_MessageText.text = "Komputer wylosował jopka";
                        Value2 = 11;
                        break;
                    case "DA":
                        m_MessageText.text = "Komputer wylosował dame";
                        Value2 = 12;
                        break;
                    case "KR":
                        m_MessageText.text = "Komputer wylosował krola";
                        Value2 = 13;
                        break;
                }
                Card = GameObject.Find("CardTexture");
                foreach(Sprite ObrazKarty in Sprites)
                {
                    if(ObrazKarty.ToString() == Talia[number].ToString())
                    {
                        Card.GetComponent<SpriteRenderer>().sprite = ObrazKarty;
                        DeleteCard(ObrazKarty);
                        break;
                    }
                }

               
                
                Swords.SetActive(false);
                targetTrackedTime = 2.0f;
                targetTime2 = 5.0f;
                TheWinnerIs();
                targetWinnerTime = 3.0f;
              
                
            }
        }
        if (Score)
        {
          
            targetWinnerTime -= Time.deltaTime;
            if (targetWinnerTime <= 0.0f)
            {
                m_MessageText.text = "Twoje pkt: " + Score1.ToString() + " Komputer: " + Score2.ToString();
                m_CardsText.text = Talia.Count.ToString();
                Score = false;
                Card.SetActive(false);
            }
            Value1 = 0;
            Value2 = 0;
            
        }


    }
    public void TheWinnerIs()
    {
        if (Value1 > Value2)
        {
            if (War)
            {
                War = false;
            }
            Score1++;
            m_MessageText.text = "Wygrałes!";
            Score = true;
        }
        if (Value1 < Value2)
        {
            if (War)
            {
                War = false;
            }
            Score2++;
            m_MessageText.text = "Przegrales!";
            Score = true;

        }
        if (Value1 == Value2)
        {
            War = true;
            m_MessageText.text = "WOJNA!";
            ARWAR();
            if (Talia.Count == 0)
            {
                m_MessageText.text = "KONIEC GRY";
            }
        } 
    }
    public void CreateList(Sprite[] Sprites )
    {
       
        foreach (Sprite karta in Sprites)
        {
            Talia.Add(karta.ToString());
        }
    }
    public void DeleteCard(Sprite Karta)
    {
        Talia.Remove(Karta.ToString());
    }
    public void ARWAR()
    {
        GameObject Parent = GameObject.Find(ReadCard);
        switch (Value2)
        {
            case 11:
                WarModel = Parent.FindObject("OPModelJ");
                WarModel.SetActive(true);
                break;
            case 12:
                WarModel = Parent.FindObject("OPModelD");
                WarModel.SetActive(true);
                break;
            case 13:
                 WarModel = Parent.FindObject("OPModelK");
                WarModel.SetActive(true);
                break;
            default:
                WarModel = Parent.FindObject("OPModelN");
                WarModel.SetActive(true);
                break;
        }
        ARWarwait = true;
    }

}
