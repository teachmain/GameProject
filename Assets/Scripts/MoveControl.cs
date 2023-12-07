using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MoveContorl : MonoBehaviour
{
    public Camera main_camera;
    public GameSetting settings;
    public GameState states;

    public CharacterController bodyController;
    public Transform bodyTransform;
    float move_speed = 5f;
    float jump_height = 1.0f;
    float slope = 0.1f;
    float g = -9.8f;
    float view_x = 0;
    float view_y = 0;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Walk(){
        Vector2 move_direct;
        move_direct.x = Input.GetAxisRaw("Horizontal");
        move_direct.y = Input.GetAxisRaw("Vertical");
        move_direct = move_direct.normalized;
        move_direct *= move_speed;
        move_direct * bodyTransform.Transform;
        Vector3 current_speed = bodyController.velocity;
        float jump_speed;
        if(Input.GetAxisRaw("Jump")>0){
            jump_speed = -g * Mathf.Sqrt(2 * jump_height / -g);
        }else{
            jump_speed = 0;
        }
        if(bodyController.isGrounded){
            current_speed.y = jump_speed;
            current_speed.x = move_direct.x;
            current_speed.z = move_direct.y;
        }else{
            current_speed.y -= 9.8f * Time.deltaTime;
        }
        bodyController.Move(current_speed * Time.deltaTime);
    }
    void View(){
        float MouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * settings.view_sensitivity;
        float MouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * settings.view_sensitivity;
        view_x -= MouseY;
        view_y += MouseX;
        if(view_y>360){
            view_y -= 360;
        }
        if(view_y<0){
            view_x += 360;
        }

        view_x = Mathf.Clamp(view_x,-10,90);
        bodyTransform.rotation=Quaternion.Euler(0,view_y,0);
    }
    void Update()
    {
        if(states.pause){
            return;
        }
        Walk();
        View();
    }
}
