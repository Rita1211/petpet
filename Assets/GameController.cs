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

    public void SwitchChoice()
    {
        SceneManager.LoadScene(16);
    }

    public void SwitchIntro1()
    {
        SceneManager.LoadScene(17);
    }

    public void SwitchSelect1()
    {
        SceneManager.LoadScene(18);
    }

    public void SwitchIntro2()
    {
        SceneManager.LoadScene(19);
    }

    public void SwitchSelect2()
    {
        SceneManager.LoadScene(20);
    }

    public void SwitchIntro3()
    {
        SceneManager.LoadScene(21);
    }

    public void SwitchSelect3()
    {
        SceneManager.LoadScene(22);
    }

    public void SwitchIntro4()
    {
        SceneManager.LoadScene(23);
    }

    public void SwitchSelect4()
    {
        SceneManager.LoadScene(24);
    }

    public void SwitchIntro5()
    {
        SceneManager.LoadScene(25);
    }

    public void SwitchSelect5()
    {
        SceneManager.LoadScene(26);
    }

    public void SwitchIntro6()
    {
        SceneManager.LoadScene(27);
    }

    public void SwitchSelect6()
    {
        SceneManager.LoadScene(28);
    }

    public void SwitchMain()
    {
        SceneManager.LoadScene(1);
    }
}
