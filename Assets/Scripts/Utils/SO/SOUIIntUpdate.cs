using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SOUIIntUpdate : MonoBehaviour
{
    
    public SOInt soInt;
    public TextMeshProUGUI uiTextValue;
    public GameObject objectInfo;

    private string _tagToCompare;

    // Start is called before the first frame update
    void Start()
    {
        _tagToCompare = objectInfo.transform.tag;

        if (_tagToCompare == "Level Info")
        {
            uiTextValue.text = "Level: " + soInt.value.ToString();
        } else
        {
            uiTextValue.text = "Coins: " + soInt.value.ToString();
        }            
    }

    // Update is called once per frame
    void Update()
    {
        _tagToCompare = objectInfo.transform.tag;

        if (_tagToCompare == "Level Info")
        {
            uiTextValue.text = "Level: " + soInt.value.ToString();
        }
        else
        {
            uiTextValue.text = "Coins: " + soInt.value.ToString();
        }
    }
    
}
