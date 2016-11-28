using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIMenu : MonoBehaviour {
    public GameObject[] Graphs;
    public GameObject[] Buttons;
    public GameObject[] FunctionButtons;
    public Toggle AbsoluteToggle;
    public Slider ResolutionSlider;
    public Slider ThresholdSlider;
    public Text ThresholdValue;
    public Text ResolutionValue;
    private int currentActiveGraphID = 1;
    //private int currentFunctionInt;
    private Color pink = new Color(255f / 255f, 154f / 255f, 154f / 255f, 1f);
    void Awake()
    {
        for (int i = 0; i < 3; i++)
        {
            Graphs[i].GetComponent<Grapher>().absolute = false;
        }
        SetResolution();
        SetThreshold();
        SetGraphObject(2);
        SetFunction(5);
        
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void SetGraphObject(int graphInt)
    { 
        for (int i = 0; i < Graphs.Length; i++)
        {
            //Debug.Log("Graph " + graphInt.ToString());
            //set object active if is selected object otherwise set it inactive
            Graphs[i].SetActive(i + 1 == graphInt);
            Buttons[i].GetComponent<Image>().color = Color.gray;
        }
        Buttons[graphInt - 1].GetComponent<Image>().color = Color.green;
        currentActiveGraphID = graphInt - 1;
        FunctionButtons[4].SetActive(graphInt > 1);
        //SetResolution();
        //SetThreshold();
        //Debug.Log("entering graph switch: " + graphInt.ToString());
        switch (graphInt)
        {
            case 1:
                //TurnOffAbsolute();
                SetFunction(4);
                SetResolution(76);
                break;
            case 2:
                TurnOffAbsolute();
                SetFunction(5);
                SetResolution(100);
                break;
            case 3:
                TurnOnAbsolute();
                SetFunction(4);
                SetResolution(64);
                SetThreshold(0.17f);
                //Debug.Log("case 3");
                break;
            default:
                Debug.Log("case default");
                break;
        }
    }
    public void SetFunction(int functionInt)
    {
        //currentFunctionInt = functionInt;

        Graphs[currentActiveGraphID].GetComponent<Grapher>().SetFunction(functionInt);
        for (int i = 0; i < FunctionButtons.Length; i++)
        {
            FunctionButtons[i].GetComponent<Image>().color = Color.white;
        }
        FunctionButtons[functionInt - 1].GetComponent<Image>().color = pink;
        if (currentActiveGraphID == 2)
        {
            switch (functionInt)
            {
                case 1:
                    TurnOnAbsolute();
                    SetResolution(15);
                    SetThreshold(0.43f);
                    break;
                case 4:
                    TurnOnAbsolute();
                    SetResolution(64);
                    SetThreshold(0.17f);
                    break;
                case 5:
                    TurnOffAbsolute();
                    SetResolution(30);
                    break;
                default:
                    TurnOffAbsolute();
                    SetResolution(30);
                    break;
            }
        } else if (currentActiveGraphID == 1)
            {
                switch (functionInt)
                {
                    
                    default:
                        TurnOffAbsolute();
                        SetResolution(100);
                        break;
                }
        }
        else if (currentActiveGraphID == 0)
        {
            switch (functionInt)
            {
                
                default:
                    TurnOffAbsolute();
                    SetResolution(76);
                    break;
            }
        }
        else
        {
            SetResolution();
        }
    }
    public void SetResolution()
    {
        Graphs[currentActiveGraphID].GetComponent<Grapher>().resolution = (int)ResolutionSlider.value;
        ResolutionValue.text = ResolutionSlider.value.ToString();
    }
    public void SetResolution(int newResolution)
    {
        ResolutionSlider.value = newResolution;
        Graphs[currentActiveGraphID].GetComponent<Grapher>().resolution = (int)ResolutionSlider.value;
        ResolutionValue.text = ResolutionSlider.value.ToString();
    }

    public void SetThreshold()
    {
        Graphs[currentActiveGraphID].GetComponent<Grapher>().threshold = ThresholdSlider.value;
        ThresholdValue.text = ThresholdSlider.value.ToString();
    }
    public void SetThreshold(float newThreshold)
    {
        ThresholdSlider.value = newThreshold;
        Graphs[currentActiveGraphID].GetComponent<Grapher>().threshold = ThresholdSlider.value;
        ThresholdValue.text = ThresholdSlider.value.ToString();
    }
    public void ToggleAbsolute()
    {
        //Debug.Log("Absolute in = " + absoluteBool);
        for(int i=0;i<3; i++)
        {
            Graphs[i].GetComponent<Grapher>().absolute = !Graphs[i].GetComponent<Grapher>().absolute;
        }
        
       
    }

    public void TurnOnAbsolute()
    {

        if (AbsoluteToggle.isOn == false)
        {     
            //ToggleAbsolute();
            AbsoluteToggle.isOn = true;
           
        }
        
    }
    public void TurnOffAbsolute()
    {

        if (AbsoluteToggle.isOn == true)
        {
            //ToggleAbsolute();
            AbsoluteToggle.isOn = false;

        }

    }
}
