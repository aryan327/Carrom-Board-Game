using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coincollpoint : MonoBehaviour
{
    // Start is called before the first frame update
    public int counter = 0;
    public Text textpoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textpoint.text = counter.ToString();
    }
}
