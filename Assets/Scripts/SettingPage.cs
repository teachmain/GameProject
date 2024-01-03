using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using UnityEngine;
using UnityEngine.UI;

public class SettingPage : MonoBehaviour
{
    bool enableSettingPage = false;
    public GameObject settingPage;
    // Start is called before the first frame update
    void Start()
    {
        enableSettingPage = false;
        settingPage.SetActive(enableSettingPage);
        GameState.pause = enableSettingPage;
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape)){
            enableSettingPage = ! enableSettingPage;
            settingPage.SetActive(enableSettingPage);
            GameState.pause = enableSettingPage;
        if(enableSettingPage){
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }else{
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

        }
       }
       
    }
    public void updateMouseSens(float value){
        GameSetting.view_sensitivity = 30 + 500 * value;
    }
}
