using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Checker : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public int[] answer = {1,2,3,1,4,4,3};
    public int Pointer = 0;
    public int error = 0;

    public void play(int i){
        if(answer[Pointer] == i ){
            Pointer ++;
            if(Pointer > 6){
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                SceneManager.LoadScene("win",LoadSceneMode.Single);
            }
        }else{
           Pointer = 0;
           error ++ ;
           if(error > 10){
                Player.GetComponent<MoveContorl>().healthy.GetHit(10);
           }
        }

    }
    void Update(){
        Debug.Log(Pointer);
    }
}
