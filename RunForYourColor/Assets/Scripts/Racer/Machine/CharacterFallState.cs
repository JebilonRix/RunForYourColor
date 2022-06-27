using RedPanda.StateMachine;

public class CharacterFallState : CharacterBaseState
{
    public override void EnterState(CharacterStateManager manager)
    {
        manager.AnimHandler(this);
    }
    public override void UpdateState(CharacterStateManager manager)
    {
    }
    public override void FixedUpdateState(CharacterStateManager manager)
    {
        manager.GoForward();
        manager.WallCheck();
        manager.GroundCheck();
    }
    public override void ExitState(CharacterStateManager manager)
    {
    }
}