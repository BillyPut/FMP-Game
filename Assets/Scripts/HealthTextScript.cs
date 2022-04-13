using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthTextScript : MonoBehaviour
{

    public TextMeshPro textMesH;
    public PlayerScript healthTracker;
    public string healthNum;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthNum = healthTracker.health.ToString();
        textMesH.text = ("Health: " + healthNum);
    }
}
