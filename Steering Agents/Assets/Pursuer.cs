using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursuer : Seeking_Target
{
    public GameObject target;
    public Vector2 target_pos;
    public Seeking_Target target_code;


    // Start is called before the first frame update
    void Start()
    {
        target_code = target.GetComponent<Seeking_Target>();
    }

    // Update is called once per frame
    void Update()
    {
        target_pos = target.transform.position;

        applyForce(Pursuit(target_pos));

        GoingFoward();

        teleport();

        Rotate();

    }

    public Vector2 Pursuit(Vector2 target_position)
    {
        target_position = target_position + (target_code.vel * 2);
       
        
        return Seek(target_position);

    }
}
