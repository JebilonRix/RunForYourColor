namespace RedPanda.StateMachine
{
    public class CharacterRunState : CharacterBaseState
    {
        public override void EnterState(CharacterStateManager manager)
        {
            manager.AnimHandler(this);
            manager.Rb.useGravity = true;
            manager.SetMass(false);
        }
        public override void UpdateState(CharacterStateManager manager)
        {
            manager.JumpInput();
        }
        public override void FixedUpdateState(CharacterStateManager manager)
        {
            manager.GoForward();
            manager.WallCheck();

            if (manager.Rb.velocity.y < -0.1f)
            {
                manager.SwitchState(manager.FallState);
            }
        }
        public override void ExitState(CharacterStateManager manager)
        {
        }
    }
}