using RedPanda.StateMachine;
using UnityEngine;

public class CharacterFallState : CharacterBaseState
{
    public override void EnterState(CharacterStateManager manager)
    {
        manager.AnimHandler(this);
        manager.SetMass(false);
    }
    public override void UpdateState(CharacterStateManager manager)
    {
    }
    public override void FixedUpdateState(CharacterStateManager manager)
    {
        manager.GoForward();
        manager.WallCheck();

        if (Physics.Raycast(new Ray(manager.transform.position, Vector3.down), out RaycastHit _groundHit))
        {
            if (_groundHit.collider.CompareTag(manager.GroundTag) && _groundHit.distance <= manager.GroundOffSet)
            {
                if (manager.Rb.velocity.y <= -5f)
                {
                    manager.SwitchState(manager.FallToRunState);
                }
                else
                {
                    manager.SwitchState(manager.RunState);
                }
            }
        }
    }
    public override void ExitState(CharacterStateManager manager)
    {
        manager.SetMass(true);
    }
}