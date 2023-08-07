using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainScene : MonoBehaviour
{
    [SerializeField]
    Firebasemanager firebaseManager;
    [SerializeField]
    TMP_InputField inputEmail;
    [SerializeField]
    TMP_InputField inputPassword;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Register(){
        firebaseManager.Register(inputEmail.text, inputPassword.text);
    }
}
