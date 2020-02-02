using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter))]
public class ShapeRoundedSquare : MonoBehaviour
{
	  MeshFilter mf;
    Mesh mesh;

    public float BaseWidth;
    public float PeakWidth;
    public float Height;
    public float SquarenessRatio;
    public int NumSegments;

    float _bw, _pw, _h, _sr;
    int _ns;

    void Start ()
    {
		    mf = GetComponent<MeshFilter> ();
    }

    void Update ()
    {
        if (BaseWidth != _bw || PeakWidth != _pw || Height != _h || NumSegments != _ns || SquarenessRatio != _sr) 
        {
          Build ();
        }
    }

    void Build ()
    {
        mesh = new Mesh ();
        var vertices = new Vector3[NumSegments + 1];
        var triangles = new int[NumSegments * 3];

        for (int i = 0; i < NumSegments; i++) {

            float a = (Mathf.PI * 2f / NumSegments) * i;
            vertices[i] = CalculateFinalPos (a);

            triangles[i*3+0] = NumSegments;
            triangles[i*3+1] = i;
            triangles[i*3+2] = (i+1)%NumSegments;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mf.mesh = mesh;
        _bw = BaseWidth;
        _pw = PeakWidth;
        _h = Height;
        _ns = NumSegments;
        _sr = SquarenessRatio;
    }
    
    Vector3 CalculateRadialPos (float a)
    {
        float w = (BaseWidth + PeakWidth) / 4;
        float h = Height / 2;

        return new Vector3 (Mathf.Cos (a) * w, -Mathf.Sin (a) * h);
    }

    Vector3 CalculateSquaredPos (float a)
    {
        Vector3 rpos = CalculateRadialPos (a);

        float w = (BaseWidth + PeakWidth) / 4;
        float h = Height / 2;
        float deg = a * Mathf.Rad2Deg;

        if (deg >= 45 && deg < 135) return new Vector3 (rpos.x, -h, 0);
        else if (deg >= 135 && deg < 225) return new Vector3 (-w, rpos.y, 0);
        else if (deg >= 225 && deg < 315) return new Vector3 (rpos.x, h, 0);
        else return new Vector3 (w, rpos.y, 0);
    }

    Vector3 CalculateFinalPos (float a)
    {
        return Vector3.Lerp (CalculateRadialPos (a), CalculateSquaredPos (a), SquarenessRatio);
    }
}
