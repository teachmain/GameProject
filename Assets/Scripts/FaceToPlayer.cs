using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FaceToPlayer : MonoBehaviour
{
    public Transform player;
    public Camera main_camera;
    public Transform self;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diff = self.position - player.position;
        diff = diff.normalized;
        float tmp = Vector3.Dot(Vector3.forward,diff);
        float angle = Mathf.Acos(tmp);
        angle = angle / Mathf.PI * 180;
        float aa = Vector3.Dot(Vector3.up,Vector3.Cross(Vector3.forward,diff).normalized);
        angle = angle * aa;
        
        self.rotation = Quaternion.Euler(0,angle,0);
    }
}
