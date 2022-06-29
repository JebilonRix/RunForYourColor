using RedPanda.StateMachine;
using UnityEngine;

public class CharacterFallState : CharacterBaseState
{
    private float _timer = 0f;
    private float _animDelay = 0;
    private bool _isAnimPlayed = false;

    public override void EnterState(CharacterStateManager manager)
    {
    }
    public override void UpdateState(CharacterStateManager manager)
    {
        _timer += Time.deltaTime;
        _animDelay += Time.deltaTime;

        if (_animDelay >= 0.1f && !_isAnimPlayed)
        {
            manager.AnimHandler(this); //Sets anim.
            _isAnimPlayed = true;
        }
    }
    public override void FixedUpdateState(CharacterStateManager manager)
    {
        manager.GoForward(); //Makes it go forward.

        manager.Rb.velocity += new Vector3(0, 0, 0.5f); //Make falling faster.

        //Altýnda bir þey var mý?
        if (Physics.Raycast(new Ray(manager.transform.position + manager.transform.forward * 1.5f, Vector3.down), out RaycastHit _groundHit, Mathf.Infinity, manager._whatIsWall))
        {
            if (!_groundHit.transform)
            {
                return;
            }

            if (_groundHit.distance < manager.GroundOffSet)
            {
                if (_timer > 1f)
                {
                    manager.SwitchState(manager.FallToRunState);
                }
                else
                {
                    manager.SwitchState(manager.RunState);
                }

                return;
            }
        }

        //Karþýda duvar var mý?
        if (Physics.Raycast(new Ray(manager.transform.position, Vector3.forward), out RaycastHit _wallHit, 2f, manager._whatIsWall))
        {
            if (!_wallHit.transform)
            {
                return;
            }

            if (_wallHit.distance < manager._wallOffset)
            {
                manager.SwitchState(manager.ClimbState);
                return;
            }
        }
    }
    public override void ExitState(CharacterStateManager manager)
    {
        _timer = 0f;
        _animDelay = 0f;
        _isAnimPlayed = false;
    }
}