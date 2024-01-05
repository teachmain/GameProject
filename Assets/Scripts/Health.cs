using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthy : MonoBehaviour
{
    public int hp = 100;
    // Start is called before the first frame update
    public void GetHit(int demage){
        hp -= demage;
    }
}
