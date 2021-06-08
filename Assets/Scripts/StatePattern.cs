using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePattern : MonoBehaviour
{
    public Animator anim;
    public Rigidbody rb;
    public StatePattern _state;
    public State current;
    public IdleState idlestate;
    public DancingState dancingstate;
    public string stringState;

    // Start is called before the first frame update
    void Start()
    {
        anim= GetComponent<Animator>();
        current = new IdleState();
        idlestate = new IdleState();
        dancingstate = new DancingState();
    }

   
    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.L))
        {
            current.changeState(this);
            current.Handle(this);
        }
        
    }

    public interface  State
    {

        void changeState(StatePattern npc);
        public void Handle(StatePattern npc);
    }

    public class DancingState : State
    {
        public void changeState(StatePattern npc)
        {
            
            npc.current = npc.idlestate;
           
        }
        public void Handle(StatePattern npc)
        {
            npc.anim.SetBool("dancing", true);
            Debug.Log("Bailando");
            
        }

    }
    public class IdleState : State
    {
        public void changeState(StatePattern npc)
        {
            
            npc.current=npc.dancingstate;
        }
        public void Handle(StatePattern npc)
        {
            npc.anim.SetBool("dancing", false);
            Debug.Log("Idle state");
        }

    }

}
