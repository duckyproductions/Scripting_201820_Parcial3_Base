using UnityEngine;

/// <summary>
/// Task that instructs ControlledAI to move away from 'tagged' player
/// </summary>
public class FleeFromTagged : Task
{

    public override bool Execute()
    {
        Vector3 v = (ActorController.currentTagged.transform.position - transform.position);

        agent.SetDestination(transform.position - v);
        return base.Execute();
    }
}