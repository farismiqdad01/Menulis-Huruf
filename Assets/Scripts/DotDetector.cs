using System;
using UnityEngine;

public class DotDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Dot")
        {
            other.GetComponent<CircleCollider2D>().enabled = false;
        }
    }
}
