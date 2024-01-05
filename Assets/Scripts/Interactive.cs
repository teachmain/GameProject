using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Inter : MonoBehaviour
{
    public Camera main_camera;
    public TextMeshProUGUI msg_board;
    public TextMeshProUGUI info_board;
    public GameObject currentObj;
    List<GameObject>  ObjList = new List<GameObject>();
    Ray inter_ray;
    void Update_msg(TextMeshProUGUI msg_board,string msg){
        msg_board.text = msg;

    }
    public void Pick(GameObject pick_obj){
        ObjList.Add(pick_obj);
        pick_obj.transform.position = new Vector3(0,-100,0);
        pick_obj.layer = 3;
    }
    void Inter_search(){
        inter_ray.origin = main_camera.transform.position + 0.8f * main_camera.transform.forward;
        inter_ray.direction = main_camera.transform.forward;
        RaycastHit hit_info;
        if(!Physics.Raycast(inter_ray,out hit_info,1.5f,1)){
            Update_msg(msg_board,"");
            return;
        }else{
            GeneralObj obj = hit_info.collider.GetComponentInParent<GeneralObj>();
            if(obj != null){
                Update_msg(msg_board,obj.int_msg);
                if(Input.GetKeyDown(KeyCode.E)){
                    obj.Intera(this);
                }
            }else{
                Update_msg(msg_board,"");
            }
        }

    }
    void Update_item(){

        if(currentObj != null){
            currentObj.layer=2;
            if(currentObj.GetComponent<Collider>()!=null){
                currentObj.GetComponent<Collider>().enabled=false;
            }
            currentObj.transform.position = main_camera.transform.position + 1.5f * main_camera.transform.forward + 1.2f * main_camera.transform.right - 0.5f * main_camera.transform.up;
            if(currentObj.GetComponent<GeneralObj>()!=null){
                Update_msg(info_board,currentObj.GetComponent<GeneralObj>().info_msg);
            }
        }
        if(ObjList.Count == 0){
            return;
        }
        if(ObjList.Count==1){
            currentObj = ObjList[0];
        }else{
            float wheel = Input.GetAxisRaw("Mouse ScrollWheel");
            if(wheel == 0){
                return;
            }
            wheel /= 0.05f;
            int index = ObjList.IndexOf(currentObj);
            print(index);
            index += (int)wheel;
            index = index % ObjList.Count;
            if(index<0){
                index += ObjList.Count;
            }
            currentObj.layer = 3;
            currentObj.transform.position = new Vector3(0,-100,0);
            currentObj = ObjList[index];
        }
    }
    void Update()
    {
        if(GameState.pause){
            return;
        }
        Inter_search();
        Update_item();
        
        
    }

}
