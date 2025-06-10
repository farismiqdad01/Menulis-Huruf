using System;
using UnityEngine;

public class OutlineDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Line")
        {
            transform.parent.GetComponent<WriteComplete>().outlineDetector = true;
        }
    }
}
