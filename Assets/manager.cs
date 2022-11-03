using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TerrainUtils;
using UnityEngine.UI;



public class manager : MonoBehaviour
{
    [SerializeField] GameObject line;
    GameObject current_line;
    LineRenderer lineRenderer;
    Vector2 mousepos;
    Color color = Color.black;
    Color pencilcolor = Color.black;
    float m;
    float n;
    float width=0.1f;


    void Start()
    {
        m=UnityEngine.Random.Range(0,999f);
        n = UnityEngine.Random.Range(0, 999f);
    }

    // Update is called once per frame
    void Update()
    {





        if (Input.GetMouseButtonDown(0))
            createline();
        if (Input.GetMouseButton(0))
        {
            Vector2 new_mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(new_mousepos, mousepos) > 0.07f)
            {
                updateline(new_mousepos);
                mousepos = new_mousepos;
            }
            Debug.Log(width);
        }
    }

    void createline()

    {
        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        current_line = Instantiate(line, Vector3.zero, Quaternion.identity);
        lineRenderer = current_line.GetComponent<LineRenderer>();
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;
        lineRenderer.SetWidth(width, width);
        lineRenderer.SetPosition(0, mousepos);
        lineRenderer.SetPosition(1, mousepos);

    }
    void updateline(Vector2 new_mousepos)
    {
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, new_mousepos);
    }

    public void pencil()
    {
        color = pencilcolor;
    }

    public void eraser()
    {
        color = Color.white;
    }

    public void red()
    {
        color = Color.red;
        pencilcolor = color;

    }

    public void blue()
    {
        color = Color.blue;
        pencilcolor = color;

    }

    public void yellow()
    {
        color = Color.yellow;
        pencilcolor = color;

    }

    public void green()
    {
        color = Color.green;
        pencilcolor = color;

    }

    public void black()
    {
        color = Color.black;
        pencilcolor = color;


    }
    public void save()
    {
        StartCoroutine(capture());
    }

    public void thicc()
    {
       
        if(width<0.5)
            width += 0.1f;
        
            
    }
    public void thin()
    {
       if (width>=0.2)
        width -= 0.1f;

        

    }
    IEnumerator capture()
    {   
        
        GameObject.Find("Canvas").GetComponent<Canvas>().enabled = false;
        yield return new WaitForEndOfFrame();

        ScreenCapture.CaptureScreenshot($"draw_app{m}{n}.jpg", 1);

        m++;
        Debug.Log(m);
        GameObject.Find("Canvas").GetComponent<Canvas>().enabled = true;
        

    }

   
}

