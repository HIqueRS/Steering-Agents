using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeking_Target : MonoBehaviour
{
    public Vector2 vel;
    public Vector2 pos;
    public Vector2 acc;
    public Vector2 force;
    Vector2 teste;
    public float Max_Speed;
    public float Max_Force;

    Vector2 teste2;

    public Camera cam;
    
   // firce -> aceleration -> velocit -> postition;

    // aceleration += force
    // velociti += aceleration
    //position += (velociti + (aceleration + force))
    // if (velocity pass max speed stop there) em magnitude



    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       

        teste2 = cam.ScreenToWorldPoint(Input.mousePosition);
        Seek(teste2);

        GoingFoward();
    }

    void Seek(Vector2 target)
    {
        Vector2 nForce;
        nForce = target - (Vector2)transform.position;
        //nForce = Vector2.ClampMagnitude(nForce, Max_Speed);
        nForce -= vel;
        nForce = Vector2.ClampMagnitude(nForce, Max_Force);
        applyForce(nForce);
    }

    void applyForce(Vector2 nforce)
    {
        acc += nforce;
    }

    void GoingFoward()
    {

        vel += (acc);

        

        vel = Vector2.ClampMagnitude(vel, Max_Speed);

      

        transform.position += new Vector3(vel.x, vel.y, 0) * Time.deltaTime;

        //dar 00 na aceleração

        acc = Vector2.zero;
    }
}
