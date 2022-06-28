using UnityEngine;

namespace RedPanda.StateMachine
{
    public class CharacterIdleState : CharacterBaseState
    {
        public override void EnterState(CharacterStateManager manager)
        {
            manager.Rb.velocity = Vector3.zero; //Sets velocity to zero.
            manager.Rb.mass = 1f; //Sets mass to default value.
            manager.AnimHandler(this); //Sets anim.
        }
        public override void UpdateState(CharacterStateManager manager)
        {
            //starts racer from buttons
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