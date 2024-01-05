using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI hp;
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string tmp = player.GetComponent<MoveContorl>().healthy.hp.ToString();
        hp.text = "hp: "+ tmp;
    }
}
