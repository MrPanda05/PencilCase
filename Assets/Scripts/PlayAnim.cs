using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnim : MonoBehaviour
{
    //The tag that will activate the animation
    public string nameTag;

    //The currentState
    internal string currentState;

    //anim Pro script, used to change animation
    public AnimPro animPro;

    private BoxCollider box;

    //Check if has been played
    public bool hasPlayed;

    public AudioSource clip;

    //list of animation string names
    public List<string> animStats;

    //Choose whitch one to play
    public int first, second, last;

    public float waitFor;

    private void Awake()
    {
        box = GetComponent<BoxCollider>();
    }

    private void Start()
    {
        //play first animation
        animPro.ChangeAnimGamerGirl(animStats[first]);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!hasPlayed)
        {//play the second animation with also a sound clip
            if (other.gameObject.CompareTag(nameTag))
            {
                clip.Play();
                hasPlayed = true;
                animPro.ChangeAnimGamerGirl(animStats[second]);
                
            }
        }
        
    }

    //Wait for some then play animation
    IEnumerator ResetAnim()
    {
        yield return new WaitForSecondsRealtime(waitFor);
        animPro.ChangeAnimGamerGirl(animStats[last]);
        yield return null;

    }

    private void OnTriggerStay(Collider other)
    {
        if (hasPlayed)
        {
            if (other.gameObject.CompareTag(nameTag))
            {
                StartCoroutine(ResetAnim());

            }
        }
    }
}
