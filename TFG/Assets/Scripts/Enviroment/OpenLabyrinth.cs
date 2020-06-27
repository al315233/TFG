using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLabyrinth : MonoBehaviour
{
    public static OpenLabyrinth Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //HUDLabyrinth.Instance.
    }
}
