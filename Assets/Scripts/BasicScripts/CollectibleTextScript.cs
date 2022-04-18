using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CollectibleTextScript : MonoBehaviour
{
    public TextMeshPro textMesH;
    public PlayerScript collectibleTracker;
    public string collectibleNum;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        collectibleNum = collectibleTracker.collectibles.ToString();
        textMesH.text = ("Collectibles: " + collectibleNum);
    }
}
