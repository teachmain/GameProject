using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLevel1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider otherOBJ){
        if(otherOBJ.GetComponentInParent<MoveContorl>()!=null){
            SceneManager.LoadScene("level2",LoadSceneMode.Single);
        }
    }
}
