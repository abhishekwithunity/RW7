using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pendulummovement : MonoBehaviour
{
    #region Public Variables
    public Rigidbody2D body2d;
    public float leftpushrange;
    public float rightpushrange;
    public float velocitythreshold;    
    #endregion



    // Start is called before the first frame update
    void Start()
    {
        body2d = GetComponent<Rigidbody2D>();
        body2d.angularVelocity = velocitythreshold;


    }

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation.z > 0
           && transform.rotation.z < rightpushrange
           && (body2d.angularVelocity > 0)
           && body2d.angularVelocity < velocitythreshold)
        {
            body2d.angularVelocity = velocitythreshold;
        }
        else if (transform.rotation.z < 0
                && transform.rotation.z > leftpushrange
           && (body2d.angularVelocity < 0)
           && body2d.angularVelocity > velocitythreshold * -1)
        {
            body2d.angularVelocity = velocitythreshold * -1;

        }
    }
            


        
    }

