using UnityEngine;

namespace RedPanda.StateMachine
{
    public class CharacterClimbState : CharacterBaseState
    {
        public override void EnterState(CharacterStateManager manager)
        {
            manager.Rb.useGravity = false;
            manager.AnimHandler(this);
            manager.SetMass(true);

            Debug.Log("CharacterClimbState enter");
        }
        public override void UpdateState(CharacterStateManager manager)
        {
        }
        public override void FixedUpdateState(CharacterStateManager manager)
        {
            manager.Rb.velocity = new Vector3(0, manager.Speed, 0);
            manager.WallCheck();
        }
        public override void ExitState(CharacterStateManager manager)
        {
            manager.Rb.useGravity = true;
            manager.SetMass(false);
        }
    }
}