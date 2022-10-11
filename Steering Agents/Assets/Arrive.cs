using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive : Seeking_Target
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        teste2 = cam.ScreenToWorldPoint(Input.mousePosition);
        //Seek(teste2);

        applyForce(Arrive_Vec(teste2));

        GoingFoward();

        teleport();

        if(vel.magnitude > 0.2f)
        {
            Rotate();
        }
       
    }

    Vector2 Arrive_Vec(Vector2 target)
    {

        Vector2 nForce;
        float dist;
        nForce = target - (Vector2)transform.position;

        dist = nForce.magnitude;

        if (dist < 5)
        {
            nForce = nForce.normalized;
            nForce = nForce * dist;
        }
        else
        {
            nForce = nForce.normalized;
            nForce = nForce * Max_Speed;
        }

       
        nForce -= vel;
       

        nForce = nForce.normalized;
        nForce = nForce * Max_Force;

        return nForce;
    }
}
