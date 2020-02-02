using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter))]
public class ShapeTrapeze : MonoBehaviour
{
	  MeshFilter mf;
    Mesh mesh;

    public float BaseWidth;
    public float PeakWidth;
    public float Height;

    float _bw, _pw, _h;

    void Start ()
    {
		    mf = GetComponent<MeshFilter> ();
    }

    void Update ()
    {
        if (BaseWidth != _bw || PeakWidth != _pw || Height != _h) 
        {
          Build ();
        }
    }

    void Build ()
    {
        mesh = new Mesh ();
        mesh.vertices = new Vector3[] {
          new Vector3 (-BaseWidth/2, -Height/2, 0f),
          new Vector3 (-PeakWidth/2, Height/2, 0f),
          new Vector3 (PeakWidth/2, Height/2, 0f),
          new Vector3 (BaseWidth/2, -Height/2, 0f),
        };

        mesh.triangles = new int[] {
          0, 1, 2,
          2, 3, 0,
        };

        mf.mesh = mesh;
        _bw = BaseWidth;
        _pw = PeakWidth;
        _h = Height;
    }
}
