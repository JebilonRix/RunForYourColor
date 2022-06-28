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
            manager.Rb.velocity = new Vector3(0, manager.Speed, 0); //climbing logic.

            //Karþýnda climb point var mý?
            if (!Physics.Raycast(new Ray(manager.transform.position - manager.transform.up * 0.5f, Vector3.forward), out RaycastHit climHit, 2f, manager._whatIsWall))
            {
                manager.SwitchState(manager.RunState);
            }
        }
        public override void ExitState(CharacterStateManager manager)
        {
            manager.Rb.useGravity = true; //activates gravity to climbing easily.
            manager.Rb.velocity = new Vector3(0, 1.5f, 0);
        }
    }
}