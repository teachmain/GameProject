using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MoveContorl : MonoBehaviour
{
    public Camera main_camera;
    public GameState state;
    public CharacterController characterController;
    public float v;
    public float a;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(state.pause){
            return;
        }

        
    }
}
