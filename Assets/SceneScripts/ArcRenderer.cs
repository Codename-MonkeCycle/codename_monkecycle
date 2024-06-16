using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArcRenderer : MonoBehaviour
{
    public GameObject arrowPrefab;
    public GameObject dotPrefab;
    public int poolSize = 50;
    private List<GameObject> dotPool = new List<GameObject>();
    private GameObject arrowInstace;

    public float spacing = 50;
    public float arrowAngleAdjust = 0;
    public int dotsToSkip = 1;
    private Vector3 arrowDirection;

    void Start()
    {
        arrowInstace = Instantiate(arrowPrefab,transform);
        arrowInstace.transform.localPosition = Vector3.zero;
        InitializeDotPool(poolSize);
    }



    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;

        Vector3 startPos = transform.position;
        Vector3 midpoint = CalculateMidPoint(startPos, mousePos);

        UpdateArc(startPos, midpoint,mousePos);
        PositionAndRotateArrow(mousePos);
    }

    private void PositionAndRotateArrow(Vector3 position)
    {
        arrowInstace.transform.position = position;
        Vector3 direction = arrowDirection - position;
        float angle = Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg;
        angle += arrowAngleAdjust;
        arrowInstace.transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);
    }

    private void UpdateArc(Vector3 start, Vector3 mid, Vector3 end)
    {
        int numDots = Mathf.CeilToInt(Vector3.Distance(start, end) / spacing);
        for (int i = 0; i < numDots && i < dotPool.Count; i++)
        {
            float t = i / (float)numDots;
            t = Mathf.Clamp(t, 0f, 1f);

            Vector3 position = QuadraticBezierPoint(start, mid, end, t);
            if (i != numDots - dotsToSkip )
            {
                dotPool[i].transform.position = position;
                dotPool[i].SetActive(true);
            }
            if (i== numDots - (dotsToSkip + 1) && i - dotsToSkip + 1 >= 0)
            {
                arrowDirection = dotPool[i].transform.position;
            }
        }
        for (int i = numDots - dotsToSkip; i < dotPool.Count; i++)
        {
            if (i > 0)
            {
                dotPool[i].SetActive(false);
            }
        }

    }

    private Vector3 QuadraticBezierPoint(Vector3 start, Vector3 control, Vector3 end, float t)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;

        Vector3 point = uu * start;
        point += 2 * u * t * control;
        point += tt * end;
        return point;
    }

    private Vector3 CalculateMidPoint(Vector3 start, Vector3 end)
    {
        Vector3 midpoint = (start + end) /2;
        float arcHeight = Vector3.Distance(start, end) / 3f;
        midpoint.y += arcHeight;
        return midpoint;
    }

    private void InitializeDotPool(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject dot = Instantiate(dotPrefab, Vector3.zero, Quaternion.identity, transform);
            dot.SetActive(false);
            dotPool.Add(dot);
        }
    }
}
