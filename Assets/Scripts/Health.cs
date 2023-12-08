using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthy : MonoBehaviour
{
    public float hp = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void GetHit(float demage){
        hp -= demage;
    }
    public virtual void Death(){

    }
    void Update()
    {
        if(hp < 0){
            Death();
        }
        
    }
}
