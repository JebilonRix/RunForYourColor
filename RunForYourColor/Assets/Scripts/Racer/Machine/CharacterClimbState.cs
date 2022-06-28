using UnityEngine;

namespace RedPanda.StateMachine
{
    public class CharacterClimbState : CharacterBaseState
    {
        public override void EnterState(CharacterStateManager manager)
        {
            manager.Rb.useGravity = false; //deactivates gravity to climbing easily.
            manager.AnimHandler(this); //Sets anim.
        }
        public override void UpdateState(CharacterStateManager manager)
        {
        }
        public override void FixedUpdateState(CharacterStateManager manager)
        {
            manager.WallCheck(); //Checks is there a wall.
            manager.Rb.velocity = new Vector3(0, manager.Speed, 0); //climbing logic.
        }
        public override void ExitState(CharacterStateManager manager)
        {
            manager.Rb.useGravity = true; //activates gravity to climbing easily.
        }
    }
}