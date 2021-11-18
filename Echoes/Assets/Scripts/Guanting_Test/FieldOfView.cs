using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{

    public float viewRadius;
    [Range(0,360)]
    public float viewAngles;

    public LayerMask targetMask;
    public LayerMask obstacleMask;



    public Vector3 DirFromAngle(float angleInDegrees,bool angleIsGlobel)
    {
        if (!angleIsGlobel) { angleInDegrees += transform.eulerAngles.y; }
        return new Vector3(Mathf.Sin(angleInDegrees*Mathf.Deg2Rad),0, Mathf.Cos(angleInDegrees*Mathf.Deg2Rad));
    }

}
