using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keys : MonoBehaviour
{
    [SerializeField] GameObject prefabKey;
    [SerializeField] Transform[] posKey;

    [SerializeField] int maxKey = 3;
    int currentKey;

    GameObject[] keyIcons;

    void Start()
    {
        currentKey = 0;
        keyIcons = new GameObject[maxKey];

        for (int i = 0; i < maxKey; i++)
        {
            GameObject key = Instantiate(prefabKey, posKey[i]);
            key.transform.localPosition = Vector3.zero;
            
            Image img = key.GetComponent<Image>();
            if (img != null)
            {
                img.color = new Color(0.3f, 0.3f, 0.3f, 1f);
            }

            keyIcons[i] = key;
        }
    }

    public void AddBag(int amount)
    {
        currentKey += amount;
        if (currentKey > maxKey) currentKey = maxKey;

        UpdateKeys();
    }

    void UpdateKeys()
    {
        for (int i = 0; i < keyIcons.Length; i++)
        {
            Image img = keyIcons[i].GetComponent<Image>();
            if (img != null)
            {
                if (i < currentKey)
                    img.color = Color.white;
                else
                    img.color = new Color(0.3f, 0.3f, 0.3f, 1f);
            }
        }
    }

    public int GetActivatedKeysCount()
    {
        int activatedCount = 0;

        for (int i = 0; i < keyIcons.Length; i++)
        {
            Image img = keyIcons[i].GetComponent<Image>();
            if (img != null && img.color == Color.white)
            {
                activatedCount++;
            }
        }

        return activatedCount;
    }
}
