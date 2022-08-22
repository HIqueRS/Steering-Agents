using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : Seeking_Target
{


    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        teste2 = cam.ScreenToWorldPoint(Input.mousePosition);
        

        applyForce(Flee_Vector(teste2));

        GoingFoward();
    }

    Vector2 Flee_Vector(Vector2 vec)
    {
        return Seek(vec) * -1;
    }
}
