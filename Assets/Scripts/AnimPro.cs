using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPro : MonoBehaviour
{
    internal Animator anim;

    public PlayAnim playAnim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    
    public void ChangeAnimGamerGirl(string newState)
    {
        if (!playAnim)
        {
            if (playAnim.currentState == newState) return;

            anim.Play(newState);

            playAnim.currentState = newState;
        }
        else
        {
            if (playAnim.currentState == newState) return;

            anim.Play(newState);

            playAnim.currentState = newState;
        }
       
    }
}
