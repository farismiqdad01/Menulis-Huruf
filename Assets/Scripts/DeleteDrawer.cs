using UnityEngine;

public class DeleteDrawer : MonoBehaviour
{
    [SerializeField] Transform bankHuruf;
    WriteComplete writeComplete;
    GameObject letterComplete;
    private Transform dots,lines;

    Transform objectActive()
    {
        Transform obj=null;
        for (int i = 0; i < bankHuruf.childCount; i++)
        {
            if (bankHuruf.GetChild(i).gameObject.activeSelf)
            {
                obj = bankHuruf.GetChild(i).transform;
            }
        }
        return obj;
    }

    public void Delete()
    {
        objectActive().Find("Huruf").gameObject.SetActive(false);
        for(int i=0; i<objectActive().Find("Dots").childCount; i++)
        {
            objectActive().Find("Dots").GetChild(i).GetComponent<CircleCollider2D>().enabled = true;
        }
        for(int i=0; i<objectActive().Find("Lines").childCount; i++)
        {
            Destroy(objectActive().Find("Lines").GetChild(i).gameObject);
        }
        writeComplete = objectActive().GetComponent<WriteComplete>();
        writeComplete.outlineDetector = false;
        letterComplete = objectActive().Find("Huruf").gameObject;
        letterComplete.SetActive(false);
        dots = objectActive().Find("Dots");
        lines = objectActive().Find("Lines");
        for (int i = 0; i < dots.childCount; i++)
        {
            dots.GetChild(i).GetComponent<CircleCollider2D>().enabled = true;
        }
        for (int i = 0; i < lines.childCount; i++)
        {
            Destroy(lines.GetChild(i).gameObject);
        }
        Debug.Log("Delete");
    }
}
