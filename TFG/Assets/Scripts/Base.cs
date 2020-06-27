using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New text", menuName = "DText")]
public class Base : ScriptableObject
{

    public bool inText;
    public List<string[]> texts = new List<string[]>();

    //public bool otrobooleano; //Para algo

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
