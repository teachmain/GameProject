using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
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
        Vector3 move_direct;
        move_direct.x = Input.GetAxisRaw("Horizontal");
        move_direct.y = 0;
        move_direct.z = Input.GetAxisRaw("Vertical");
        move_direct = move_direct.normalized;
        move_direct *= move_speed;
        move_direct = bodyTransform.rotation * move_direct;
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
            current_speed.z = move_direct.z;
        }else{
            current_speed.y -= 9.8f * Time.deltaTime;
        }
        bodyController.Move(current_speed * Time.deltaTime);
    }
    void View(){
        float MouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * settings.view_sensitivity;
        float MouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * settings.view_sensitivity;
        view_x -= MouseY * settings.x_asix_invert;
        view_y += MouseX * settings.y_asix_invert;
        if(view_y>360){
            view_y -= 360;
        }
        if(view_y<0){
            view_y += 360;
        }

        view_x = Mathf.Clamp(view_x,-90,45);
        bodyTransform.rotation=Quaternion.Euler(0,view_y,0);
        main_camera.transform.rotation=Quaternion.Euler(view_x,view_y,0);
        main_camera.transform.position = bodyTransform.position + 0.5f * Vector3.up;
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
