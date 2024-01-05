using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartPage : MonoBehaviour
{
    public Dropdown levelSelector;
    public GameObject SettingPage;
    // Start is called before the first frame update
    void Start()
    {
        SettingPage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame(){
        switch (levelSelector.value){
            case 0:
                SceneManager.LoadScene("level1");
                break;
            case 1:
                SceneManager.LoadScene("level2");
                break;
            default:
                SceneManager.LoadScene("level1");
                break;
        }


    }
    public void EndTheGame(){
        Application.Quit();
    }
    public void BackToMainMenu(){
        SettingPage.SetActive(false);
    }
    public void EnableSetting(){
        SettingPage.SetActive(true);
    }
    public void ChangeSen(float v){
        GameSetting.view_sensitivity = 50 + 300 *v;
    }
}
