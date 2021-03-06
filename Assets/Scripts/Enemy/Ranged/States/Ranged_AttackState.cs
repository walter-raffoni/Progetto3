using UnityEngine;

public class Ranged_AttackState : State
{
    public Ranged_AttackState(EnemyRanged _enemy, StateMachine _stateMachine) : base(_enemy, _stateMachine)
    {
        enemyRanged = _enemy;
        stateMachine = _stateMachine;
    }

    public override void Enter()
    {
        base.Enter();

        enemyRanged.InvokeRepeating("Spara", 0, 1);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (enemyRanged.Target.position.x > enemyRanged.transform.position.x && !enemyRanged.FacingRight) enemyRanged.Flip();
        if (enemyRanged.Target.position.x < enemyRanged.transform.position.x && enemyRanged.FacingRight) enemyRanged.Flip();

        if (Vector3.Distance(enemyRanged.transform.position, enemyRanged.Target.position) >= enemyRanged.DistPgTroppoLontano) stateMachine.ChangeState(enemyRanged.patrollingState);
        else if (Vector3.Distance(enemyRanged.transform.position, enemyRanged.Target.position) <= enemyRanged.DistPgTroppoVicino) enemyRanged.transform.position = Vector2.MoveTowards(enemyRanged.transform.position, enemyRanged.transform.position + Vector3.right, enemyRanged.Speed * Time.fixedDeltaTime);
    }
}