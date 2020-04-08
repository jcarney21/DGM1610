using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName="New SO",menuName="Scriptable Object")]

public class SO : ScriptableObject
{
    public string fullname;

    public string description;

    public GameObject model;

    public Color color;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
