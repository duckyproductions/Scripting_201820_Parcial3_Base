using UnityEngine;
/// <summary>
/// Selector that succeeds if 'tagged' player is within a 'acceptableDistance' radius.
/// </summary>
public class IsTaggedActorNear : Selector
{
    [SerializeField]
    private float acceptableDistance = 10F;

    protected override bool CheckCondition()
    {
        if(ActorController.currentTagged != null)
        {
            if ((ActorController.currentTagged.transform.position - transform.position).magnitude <= acceptableDistance)
                return true;
            else
                return false;
        }
        else
            return false;
    }
}