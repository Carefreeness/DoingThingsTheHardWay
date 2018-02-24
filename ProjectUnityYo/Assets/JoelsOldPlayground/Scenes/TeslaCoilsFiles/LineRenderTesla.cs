using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRenderTesla : MonoBehaviour {

    public Transform startPoint;
    public Transform endPoint;

    public int numberOfLines = 10;
    public int publicSeed;
    public bool useSeed;
    private int privateSeed;

    public Color startColor, endColor;
    public float startWidth, widthMultiplier;

    private LineRenderer lineRenderer;
    private float dt;

    // Use this for initialization
    void Start ()
    {
        if(useSeed)
            Random.InitState(publicSeed);
        else
        {
            privateSeed = Random.Range(int.MinValue, int.MaxValue) / 1001;
            Random.InitState(System.DateTime.Now.Second + privateSeed);
        }

        
        lineRenderer = gameObject.AddComponent<LineRenderer>();

        lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        lineRenderer.widthMultiplier = widthMultiplier;
        lineRenderer.positionCount = numberOfLines;

        lineRenderer.startColor = startColor;
        lineRenderer.startWidth = startWidth;
        lineRenderer.endColor = endColor;
    }
	
	// Update is called once per frame
	void Update ()
    {
        dt += Time.deltaTime;   
        if(dt > 0.1f)
        {
            Vector3[] positionsYes = new Vector3[numberOfLines];
            CalculateLinePositions(positionsYes);
            SetLines(positionsYes);
            dt = 0;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Vector3[] positionsYes = new Vector3[numberOfLines];
           // CalculateLinePositions(positionsYes);
           // SetLines(positionsYes);
        }
	}

    void SetLines(Vector3[] linePositions)
    {
        lineRenderer.SetPositions(linePositions);
    }

    void CalculateLinePositions(Vector3[] positionsYes)
    {
        

        for (int i = 0; i < numberOfLines; i++)
        {
            float j = i;
            float t = j / numberOfLines;

            Vector3 Pos = Vector3.Lerp(startPoint.position, endPoint.position, t);

            float stuff = Random.Range(-1f, 1f);

            //if (i % 2 == 0)
              //  stuff *= -1f;

            if (i == 0)
                positionsYes[0] = startPoint.position;
            else if (i == numberOfLines - 1)
                positionsYes[numberOfLines - 1] = endPoint.position;
            else
                positionsYes[i] = new Vector3(Pos.x, Pos.y + stuff, Pos.z+stuff);

        }
    }

}
