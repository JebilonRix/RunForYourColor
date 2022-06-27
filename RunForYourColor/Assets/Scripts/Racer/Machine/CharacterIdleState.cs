using UnityEngine;

namespace RedPanda.StateMachine
{
    public class CharacterIdleState : CharacterBaseState
    {
        public override void EnterState(CharacterStateManager manager)
        {
            manager.Rb.velocity = Vector3.zero;
            manager.AnimHandler(this);
        }
        public override void UpdateState(CharacterStateManager manager)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //for debug
                manager.SwitchState(manager.RunState);
            }
            if (manager.StartRun)
            {
                manager.SwitchState(manager.RunState);
            }
        }
        public override void FixedUpdateState(CharacterStateManager manager)
        {
        }
        public override void ExitState(CharacterStateManager manager)
        {
        }
    }
}