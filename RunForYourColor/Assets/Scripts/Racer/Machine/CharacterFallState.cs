using RedPanda.StateMachine;
using UnityEngine;

public class CharacterFallState : CharacterBaseState
{
    public override void EnterState(CharacterStateManager manager)
    {
        manager.AnimHandler(this); //Sets anim.
    }
    public override void UpdateState(CharacterStateManager manager)
    {
    }
    public override void FixedUpdateState(CharacterStateManager manager)
    {
        manager.GoForward(); //Makes it go forward.
        manager.WallCheck(); //Checks is there a wall.
        manager.Rb.velocity += new Vector3(0, 0, 0.5f); //Make falling faster.

        // Starts ground checks if ray.distance less than offset. It switchs state to "FallToRunState".
        //if (Physics.Raycast(new Ray(manager.transform.position, Vector3.down), out RaycastHit _groundHit))
        //{
        //    if (_groundHit.collider.CompareTag(manager.GroundTag) || _groundHit.collider.CompareTag("DeadPoint"))
        //    {
        //        if (_groundHit.distance < manager.GroundOffSet)
        //        {
        //            manager.SwitchState(manager.FallToRunState);
        //        }
        //    }
        //}

        if (manager.Rb.velocity.y >= 0f)
        {
            manager.SwitchState(manager.FallToRunState);
        }
    }
    public override void ExitState(CharacterStateManager manager)
    {
    }
}