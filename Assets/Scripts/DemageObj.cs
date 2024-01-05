using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemageObj : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 oldP = transform.position;
        transform.position = new Vector3(oldP.x,oldP.y ,oldP.z+ speed * Time.deltaTime);
        if(oldP.z > -20 && speed >0){ 
            speed = - speed;
        }
        if(oldP.z < -40 && speed <0){
            speed = - speed;
        }
    }
    private void OnTriggerEnter(Collider otherOBJ){
        if(otherOBJ.GetComponentInParent<MoveContorl>()!=null){
            otherOBJ.GetComponentInParent<MoveContorl>().healthy.GetHit(20);
        }
    }
}

