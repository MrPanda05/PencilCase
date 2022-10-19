using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeTxt : MonoBehaviour
{
    public Text text;
    public GameObject UI;
    public float waitS = 1.5f;

    public List<string> texts;

    public AnimPro animPro;

    private bool isRunning = false;

    public List<Animator> anims;//0 for acutal component - 1 for txt

    public string currentState;

    public void ChangeAnimGamerGirl(string newState, int n)
    {
            if (currentState == newState) return;

            anims[n].Play(newState);

            currentState = newState;
    }

    public TextMeshProUGUI UItxt;
    IEnumerator ChangeUI()
    {
        //0 -2 textcomopnet
        //3-5 acutal text
        if (isRunning)
        {
            yield break;
        }
        isRunning = true;
        UItxt.text = text.txt;
        UI.SetActive(true);
        ChangeAnimGamerGirl("Textcomponentfadein",0);
        ChangeAnimGamerGirl("Textfadein",1);
        yield return new WaitForSecondsRealtime(0.8f);
        ChangeAnimGamerGirl("Textcomponentstatic",0);
        ChangeAnimGamerGirl("TextStatic",1);
        yield return new WaitForSecondsRealtime(waitS);
        ChangeAnimGamerGirl("Textcomponentfadeaway",0);
        ChangeAnimGamerGirl("Textfadeaway",1);
        yield return new WaitForSecondsRealtime(0.8f);
        UI.SetActive(false);
        isRunning = false;
        yield return null;
    }
    public void ChangeTxts()
    {
        if (isRunning)
        {
            Debug.Log("iSrUN");
            return;
        }
        else
        {
            StartCoroutine(ChangeUI());
           //Debug.Log("Nerda");
        }
        
    }
}
