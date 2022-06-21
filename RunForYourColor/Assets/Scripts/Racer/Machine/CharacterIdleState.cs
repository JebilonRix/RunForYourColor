using UnityEngine;

namespace RedPanda.StateMachine
{
    public class CharacterIdleState : CharacterBaseState
    {
        public override void EnterState(CharacterStateManager manager)
        {
            manager.Rb.velocity = Vector3.zero;
        }
        public override void UpdateState(CharacterStateManager manager)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                manager.SwitchState(manager.RunState);
            }
            //if (manager.StartRun)
            //{
            //    manager.SwitchState(manager.RunState);
            //}
        }
        public override void FixedUpdateState(CharacterStateManager manager)
        {
        }
        public override void ExitState(CharacterStateManager manager)
        {
        }
    }
}