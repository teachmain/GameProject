using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pickable : GeneralObj
{
    // Start is called before the first frame update

    public string n_int_msg = "Press E to pick";
    public string n_info_msg = "pickable obj";
    public override void Intera(Inter main)
    {
        base.Intera(main);
        GameObject obj = this.transform.root.gameObject;
        main.Pick(obj);
    }
    void Start()
    {
        this.int_msg = n_int_msg;
        this.info_msg = n_info_msg;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
