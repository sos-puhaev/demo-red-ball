using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour, IContact, IContactExit
{
    [SerializeField] GameObject tooltip;
    [SerializeField] FinishGame finishGame;

    void Start()
    {
        tooltip.SetActive(false);
    }

    public void ApplyContact(GameObject player)
    {
        Keys playerKeys = player.GetComponent<Keys>();
        if (playerKeys != null && playerKeys.GetActivatedKeysCount() == 3)
        {
            finishGame?.ShowGameFinishPanel();
        }
        else 
        {
            if (tooltip != null)
                tooltip.SetActive(true);
        }
    }

    public void ApplyExitContact(GameObject player)
    {
        if (tooltip != null)
            tooltip.SetActive(false);
    }

}
