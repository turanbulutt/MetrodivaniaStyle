using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class selectLevel : MonoBehaviour
{
    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void SelectLevel1()
    {
        SceneManager.LoadScene(2);
    }
    public void SelectLevel2()
    {
        SceneManager.LoadScene(3);
    }
    public void SelectLevel3()
    {
        SceneManager.LoadScene(4);
    }
    public void SelectLevel4()
    {
        SceneManager.LoadScene(5);
    }

}
