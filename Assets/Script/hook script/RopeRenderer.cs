using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeRenderer : MonoBehaviour
{
    private LineRenderer lineRenderer;

    [SerializeField]
    private Transform startPosition;
    private float lineWidth = 0.07f;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = lineWidth;
        lineRenderer.enabled = false;
    }

    // Start is called before the first frame update

    public void RenderLine(Vector3 endposition, bool enable)
    {
        if (enable)
        {
            if (!lineRenderer.enabled) lineRenderer.enabled = true;
            lineRenderer.positionCount = 2;
        }
        else
        {
            lineRenderer.positionCount = 0;
            if (lineRenderer.enabled) lineRenderer.enabled = false;
        }

        if (lineRenderer.enabled)
        {
            Vector3 temp = startPosition.position;
            temp.z = 0f;

            startPosition.position = temp;

            temp = endposition;
            temp.z = 0f;

            lineRenderer.SetPosition(0, startPosition.position);
            lineRenderer.SetPosition(1, endposition);

        }
    }
}
