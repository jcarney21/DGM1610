using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour
{
    public Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var player = GameObject.FindWithTag("Player");
        var health = player.GetComponent<Move>();
        healthText.text = "Health: " + health;
    }
}
