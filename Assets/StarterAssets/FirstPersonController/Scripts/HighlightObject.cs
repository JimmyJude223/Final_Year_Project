using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightObject : MonoBehaviour
{
    public GameObject highlightedobject;
    public int Red;
    public int Blue;
    public int Green;
    public bool lookingatitem= false;
    public bool highlightobject = true;
    public bool starthighlighting = false;




    // Update is called once per frame
    void Update()
    {
     if(lookingatitem== true)
        {
            highlightedobject.GetComponent<Renderer>().material.color = new Color32((byte)Red, (byte)Green, (byte)Blue, 255);
        }   
    }

    void OnMouseOver()
    {
        highlightedobject = GameObject.Find(Casttoslot.hoveredobject);
        lookingatitem = true;
        if(starthighlighting == false)
        {
            starthighlighting = true;
            StartCoroutine(ShineObject());
        }
    }

    void OnMouseExit()
    {
        starthighlighting=false;
        lookingatitem = false;
        StopCoroutine(ShineObject());
        highlightedobject.GetComponent<Renderer>().material.color = new Color32(255,255,255,255);

    }

    IEnumerator ShineObject()
    {
        while (lookingatitem == true)
        {
            yield return new WaitForSeconds(0.07f);
            if(highlightobject == true)
            {
                if(Blue <= 30)
                {
                    highlightobject = false; 
                }
                else
                {
                    Blue -= 25;
                    Green -= 25;
                    
                }
            }
            if (highlightobject == false)
            {
                if (Blue >= 250)
                {
                    highlightobject = true;
                }
                else
                {
                    Blue += 25;
                    Green = 1;
                    
                }
            }
            
        } 
    }
}

