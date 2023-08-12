using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameInputMain : MonoBehaviour
{
    public InputField nameInputField;
    public Text displayText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateDisplayName()
    {
        string enteredName = nameInputField.text;
        displayText.text = "Åwªï¡A" + enteredName + "¡I";
    }
}
