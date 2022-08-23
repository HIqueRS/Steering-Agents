using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evade : Pursuer
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target_pos = target.transform.position;

        applyForce(Evade_Force(target_pos));

        GoingFoward();

        teleport();

        Rotate();
    }

    Vector2 Evade_Force(Vector2 vec)
    {
        return Pursuit(vec) * -1;
    }
}
