using UnityEngine;

public class WriteComplete : MonoBehaviour
{
    public bool outlineDetector=false;
    Transform dotsParent,lines;
    GameObject letterComplete;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dotsParent = GameObject.Find("Dots").transform;
        lines = GameObject.Find("Lines").transform;
        letterComplete = transform.Find("Huruf").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        bool complete = true;
       for(int i=0; i < dotsParent.childCount; i++)
       {
           if (dotsParent.GetChild(i).GetComponent<CircleCollider2D>().enabled)
           {
               complete = false;
               Debug.Log(complete);
           }
       }

       if (complete&& !outlineDetector)
       {
           letterComplete.SetActive(true);
           for(int i=0;i<lines.childCount; i++)
           {
               Destroy(lines.GetChild(i).gameObject);
           }
       }
    }
}
