using UnityEngine;

namespace RedPanda.StateMachine
{
    public class CharacterRunState : CharacterBaseState
    {
        public override void EnterState(CharacterStateManager manager)
        {
            manager.AnimHandler(this);
            //manager.Rb.useGravity = true;
            manager.SetMass(true);

            Debug.Log("CharacterRunState enter");
        }
        public override void UpdateState(CharacterStateManager manager)
        {
            manager.JumpInput();
        }
        public override void FixedUpdateState(CharacterStateManager manager)
        {
            manager.GoForward();
            manager.WallCheck();

            if (manager.Rb.velocity.y < -5f)
            {
                manager.SwitchState(manager.FallState);
            }
            else if (manager.Rb.velocity.y > 5f)
            {
                manager.SwitchState(manager.FallState);
            }
            else
            {
                Debug.Log(manager.Rb.velocity.y);
            }
        }
        public override void ExitState(CharacterStateManager manager)
        {
            //Debug.Log("CharacterRunState exit");
        }
    }
}