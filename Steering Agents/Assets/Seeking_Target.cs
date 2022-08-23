using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeking_Target : MonoBehaviour
{
    public Vector2 vel;
    public Vector2 pos;
    public Vector2 acc;
    public Vector2 force;
    protected Vector2 teste;
    public float Max_Speed;
    public float Max_Force;

    protected Vector2 teste2;

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
        //Seek(teste2);

        applyForce(Seek(teste2));

        GoingFoward();

        teleport();

        Rotate();
    }

    public void teleport()
    {
        if(transform.position.x > 9.5)
        {
            transform.position = new Vector3(-9.4f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.5)
        {
            transform.position = new Vector3(9.4f, transform.position.y, 0);
        }

        if (transform.position.y > 5.5)
        {
            transform.position = new Vector3(transform.position.x, -5.4f, 0);
        }
        else if (transform.position.y < -5.5)
        {
            transform.position = new Vector3(transform.position.x,5.5f, 0);
        }
    }

    public void Rotate()
    {
        float angle = Mathf.Atan2(vel.y, vel.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        //transform.LookAt((Vector2)transform.position + vel);

       // transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.up, vel, 1 * Time.deltaTime, 0.0f));
    }

    protected Vector2 Seek(Vector2 target)
    {
        Vector2 nForce;
        nForce = target - (Vector2)transform.position;

        //Debug.Log(nForce.magnitude);

        nForce = nForce.normalized;
        //nForce = Vector2.ClampMagnitude(nForce, Max_Speed);
        nForce = nForce * Max_Speed;
        nForce -= vel;
        //nForce = Vector2.ClampMagnitude(nForce, Max_Force);

        nForce = nForce.normalized;
        nForce = nForce * Max_Force;
        
        return nForce;
    }

    protected void applyForce(Vector2 nforce)
    {
        acc += nforce;
    }

    protected void GoingFoward()
    {

        vel += (acc)/2 ;

        

        vel = Vector2.ClampMagnitude(vel, Max_Speed);

      

        transform.position += new Vector3(vel.x, vel.y, 0) * Time.deltaTime;

        //dar 00 na aceleração

        acc = Vector2.zero;
    }
}
