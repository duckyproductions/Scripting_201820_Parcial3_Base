using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetNearestTarget : Task
{
    GameObject[] targets;
    public Vector3 destination; 
    float temporal; 

    public override bool Execute()
    {
        targets  = GameObject.FindGameObjectsWithTag("Player");

        if (targets.Length > 2)
        { 
            temporal = 100;

            for (int i = 0; i < targets.Length; i++)
            { 
                if((targets[i] != ActorController.lastTagged))
                {
                    Vector3 vector3 = targets[i].transform.position - transform.position;

                    if(vector3.magnitude <= temporal && vector3.magnitude != 0 )
                    {
                        temporal = vector3.magnitude;
                        destination = targets[i].GetComponent<Transform>().position;
                    }
                } 
            }

        }
        else
            destination = targets[0].GetComponent<Transform>().position;
 
        return true;

    }
}
