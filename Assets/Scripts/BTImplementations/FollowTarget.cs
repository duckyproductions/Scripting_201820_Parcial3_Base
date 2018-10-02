/// <summary>
/// Task that instructs ControlledAI to follow its designated 'target'
/// </summary>
public class FollowTarget : Task
{
    public override bool Execute()
    {
        agent.SetDestination(GetComponent<GetNearestTarget>().destination);
        return base.Execute();
    }
}