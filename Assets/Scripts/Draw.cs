using System;
using UnityEngine;

public class Draw : MonoBehaviour
{
    [SerializeField] GameObject linePrefab;
    [SerializeField] private float linePositionZ;
    GameObject currentLineObject;
    LineRenderer currentLineRenderer;
    EdgeCollider2D edgeCollider;
    
    Vector3 mousePosition;
    Vector3 mousePositionXY;
    bool write=true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        CreateLine();
    }
    private void OnMouseDrag()
    {
        UpdateLine();
    }

    private void OnMouseExit()
    {
        write= false;
        EndLine();
    }

    private void OnMouseUp()
    {
        EndLine();
    }

    private void CreateLine()
    {
        write = true;
        currentLineObject = Instantiate(linePrefab);
        currentLineRenderer = currentLineObject.GetComponent<LineRenderer>();
        edgeCollider = currentLineObject.GetComponent<EdgeCollider2D>();
        currentLineRenderer.SetPosition(0, GetMousePosition());
        currentLineRenderer.SetPosition(1, GetMousePosition());
        edgeCollider.points = edgePoints();
    }


    private void UpdateLine()
    {
        if (currentLineRenderer.GetPosition(currentLineRenderer.positionCount - 1) != GetMousePosition()&& write)
        {
            currentLineRenderer.positionCount++;
            currentLineRenderer.SetPosition(currentLineRenderer.positionCount - 1, GetMousePosition());
        }
        edgeCollider.points = edgePoints();
    }

    private void EndLine()
    {
        if (currentLineObject != null)
        {
            currentLineObject.transform.parent = GameObject.Find("Lines").transform;
            currentLineObject = null;
            currentLineRenderer = null;
            edgeCollider = null;
        }
    }

    Vector3 GetMousePosition()
    {
        mousePosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePositionXY = new Vector3(mousePosition.x, mousePosition.y, linePositionZ);
        return mousePositionXY;
    }

    Vector2[] edgePoints()
    {
        Vector2[] points = new Vector2[currentLineRenderer.positionCount];
        for (int i = 0; i < currentLineRenderer.positionCount; i++)
        {
            points[i] = currentLineRenderer.GetPosition(i);
        }
        return points;
    }
}
