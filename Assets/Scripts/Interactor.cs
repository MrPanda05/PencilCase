using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Interactor : MonoBehaviour
{
    public LayerMask mask;

    Interactable interactable;

    public Image interactImage;

    public Sprite defaultIcon;
    public Sprite defaultInteractIcon;

    public Vector2 defaultIconSize;
    public Vector2 defaultInteractIconSize;
    RaycastHit hit;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //RaycastHit hit;

        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 5, mask))
        {
            if(hit.collider.GetComponent<Interactable>() != false)
            {
                if(interactable == null || interactable.ID != hit.collider.GetComponent<Interactable>().ID)
                {
                    interactable = hit.collider.GetComponent<Interactable>();
                }
                if(interactable.interactIcon != null)
                {
                    interactImage.sprite = interactable.interactIcon;
                    if(interactable.iconSize == Vector2.zero)
                    {
                        interactImage.rectTransform.sizeDelta = defaultIconSize;
                    }else
                    {
                        interactImage.rectTransform.sizeDelta = interactable.iconSize;
                    }
                }
                else
                {
                    interactImage.sprite = defaultInteractIcon;
                    interactImage.rectTransform.sizeDelta = defaultInteractIconSize;
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.onInteract.Invoke();
                }
            }
        }
        else
        {
            if(interactImage.sprite != defaultIcon)
            {
                interactImage.sprite = defaultIcon;
                interactImage.rectTransform.sizeDelta = defaultIconSize;
            }
        }//
    }
}
