using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coincollector : MonoBehaviour
{
    // Start is called before the first frame update
    public int point = 0;
    public Text points;
    public GameObject text1;
    public GameObject text2;
    public GameObject bord;
   public int nocoins = 0;
    int decideno = 0;
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coins")
        {
            Destroy(collision.gameObject);
           decideno= bord.GetComponent<gameman>().count;

            if (decideno % 2 == 0)
            {
                text1.GetComponent<coincollpoint>().counter = text1.GetComponent<coincollpoint>().counter + 10;
            }
            else
            {
                text2.GetComponent<coincollpoint>().counter = text2.GetComponent<coincollpoint>().counter + 10;
            }



        }
       

    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
