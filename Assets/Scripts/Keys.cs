using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : Pickable
{
    // Start is called before the first frame update

    public string k_info = "A key";
    public string k_int = "A key";
    public string password = "aaa";
    void Start()
    {
        this.info_msg = k_info;
        this.int_msg = k_int;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
