namespace RedPanda.StateMachine
{
    public abstract class CharacterBaseState
    {
        public abstract void EnterState(CharacterStateManager manager);
        public abstract void UpdateState(CharacterStateManager manager);
        public abstract void FixedUpdateState(CharacterStateManager manager);
        public abstract void ExitState(CharacterStateManager manager);
    }
}