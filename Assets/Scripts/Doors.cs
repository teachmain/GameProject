using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : GeneralObj
{
    // Start is called before the first frame update
    public string d_int = "a door";
    public string password = "door";
    public bool open = false;
    void Start()
    {
        this.int_msg = d_int;
        
    }
    public override void Intera(Inter main)
    {
        base.Intera(main);
        if(main.currentObj==null){
            return;
        }
        Keys key = main.currentObj.GetComponent<Keys>();
        if(key!=null){
            if(key.password == this.password){
                open = true;
            }else{
                main.GetComponentInParent<MoveContorl>().healthy.GetHit(20);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(open){
            transform.position = transform.position + new Vector3(0,1,0);
        }
        
    }
}
