using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezCurve : MonoBehaviour
{
    [SerializeField]
    private Transform[] controlpoints;
    private Vector2 gizmopositions;


    private void OnDrawGizmos()
    {
        for (float t = 0; t <= 1;t+=0.05f)
        {
            gizmopositions = Mathf.Pow(1 - t, 3) * controlpoints[0].position + 3 * Mathf.Pow(1 - t, 2) * t * controlpoints[1].position + 3 * (1 - t) * Mathf.Pow(t, 2) * controlpoints[2].position +
                                Mathf.Pow(t, 3) * controlpoints[3].position;
            Gizmos.DrawSphere(gizmopositions, 0.25f);
        }
   
        Gizmos.DrawLine(new Vector2(controlpoints[0].position.x,controlpoints[0].position.y),new Vector2(controlpoints[1].position.x, controlpoints[1].position.y));
        Gizmos.DrawLine(new Vector2(controlpoints[2].position.x, controlpoints[2].position.y), new Vector2(controlpoints[3].position.x, controlpoints[3].position.y));
    
    
    }

     
}
