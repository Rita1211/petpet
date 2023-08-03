using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SwitchScene1()
    {
        SceneManager.LoadScene(1);
    }
    
    public void SwitchScene2()
    {
        SceneManager.LoadScene(2);
    }

    public void SwitchScene0()
    {
        SceneManager.LoadScene(0);
    }

    public void SwitchScene3()
    {
        SceneManager.LoadScene(3);
    }
    public void SwitchKnowledge()
    {
        SceneManager.LoadScene("knowledge");

    }
    public void SwitchMain()
    {
        SceneManager.LoadScene("main");
    }
    public void Switchdog1()
    {
        SceneManager.LoadScene("dog1");
    }
    public void Switchdog2()
    {
        SceneManager.LoadScene("dog2");
    }
    public void Switchdog3()
    {
        SceneManager.LoadScene("dog3");
    }
    public void Switchdog4()
    {
        SceneManager.LoadScene("dog4");
    }
    public void Switchcat1()
    {
        SceneManager.LoadScene("cat1");
    }
    public void Switchcat2()
    {
        SceneManager.LoadScene("cat2");
    }
    public void Switchcat3()
    {
        SceneManager.LoadScene("cat3");
    }
    public void Switchcat4()
    {
        SceneManager.LoadScene("cat4");
    }
    public void Switchcat5()
    {
        SceneManager.LoadScene("cat5");
    }
    public void Switchbag()
    {
        SceneManager.LoadScene("bag");
    }
    public void Switchcamera()
    {
        SceneManager.LoadScene("camera");
    }
    public void Switchphoto()
    {
        SceneManager.LoadScene("photo");
    }
    public void Switchsetting()
    {
        SceneManager.LoadScene("setting");
    }
}
