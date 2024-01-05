using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piano : GeneralObj
{
    // Start is called before the first frame update
    public AudioClip clip;
    public GameObject Checker;
    public int Node;
    public string n_int_msg = "Press E to play";
    public override void Intera(Inter main)
    {
        base.Intera(main);
        Play();
    }
    void Start()
    {
        this.int_msg = n_int_msg;
    }
    void Play(){
        this.GetComponentInParent<AudioSource>().PlayOneShot(clip);
        Checker.GetComponent<Level2Checker>().play(Node);
    }

        

}
