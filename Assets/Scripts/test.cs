using UnityEngine;
using UnityEngine.AI;

public class test : MonoBehaviour
{
    public float detectionRange = 5f;
    public float patrolRange = 10f;
    public LayerMask playerLayer;

    public Transform player;
    private NavMeshAgent navMeshAgent;
    private bool isPlayerInRange;
    private float speed;
    private Animator animator;
    private float patrolTimer = 0f;
    public float patrolWaitTime = 1f;
    private Vector3 targetPatrolPoint;
    private bool isPatrolling;
 public PlayerScanner playerScanner;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("XR Origin").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.stoppingDistance = 2f;
        animator = GetComponent<Animator>();
        animator.applyRootMotion = true; // disable root motion from animator

        targetPatrolPoint = GetRandomPatrolPoint();
        isPatrolling = true;
    }

    void Update()
{
    GameObject player = playerScanner.Detect(transform);

    if (player != null)
    {
        animator.applyRootMotion = true;
        navMeshAgent.destination = player.transform.position;
        navMeshAgent.speed = 2;
        speed = navMeshAgent.velocity.magnitude;

        animator.SetFloat("speed", speed);

        if (Vector3.Distance(transform.position, player.transform.position) < navMeshAgent.stoppingDistance)
        {
            Attack();
        }
        else
        {
            navMeshAgent.isStopped = false;
            speed = Mathf.Clamp(navMeshAgent.velocity.magnitude, 0f, 3f);
        }

        if (Vector3.Distance(transform.position, targetPatrolPoint) < navMeshAgent.stoppingDistance)
        {
            isPatrolling = false;
        }
    }
    else
    {
        if (!isPatrolling || navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            animator.applyRootMotion = true;
            if (patrolTimer <= 0f)
            {
                targetPatrolPoint = GetRandomPatrolPoint();
                isPatrolling = true;
                patrolTimer = patrolWaitTime;
            }
            else
            {
                patrolTimer -= Time.deltaTime;
            }
        }

        navMeshAgent.SetDestination(targetPatrolPoint);

        speed = navMeshAgent.velocity.magnitude;

        animator.SetFloat("speed", speed);

        if (isPatrolling)
        {
            animator.applyRootMotion = true;
            navMeshAgent.speed = 1;

            Vector3 direction = (targetPatrolPoint - transform.position).normalized;

            // control root motion manually
            animator.rootPosition += direction * navMeshAgent.speed * Time.deltaTime;
            animator.rootRotation = Quaternion.LookRotation(direction);
        }
    }
}


#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Color c = new Color(0.8f, 0, 0, 0.4f);
            UnityEditor.Handles.color = c;

            Vector3 rotatedForward = Quaternion.Euler(
                0,
                -playerScanner.detectionAngle * 0.5f,
                0) * transform.forward;

            UnityEditor.Handles.DrawSolidArc(
                transform.position,
                Vector3.up,
                rotatedForward,
                playerScanner.detectionAngle,
                playerScanner.detectionRadius);


            UnityEditor.Handles.DrawSolidArc(
                transform.position,
                Vector3.up,
                rotatedForward,
                360,
                playerScanner.meleeDetectionRadius);

        }
#endif

    

    Vector3 GetRandomPatrolPoint()
    {
        Vector3 randomDirection = Random.insideUnitSphere * patrolRange;
        randomDirection += transform.position;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, patrolRange, NavMesh.AllAreas & ~(1 << NavMesh.GetAreaFromName("Obstacles")));
        Debug.Log(navHit.position);
        return navHit.position;
    }

    void Attack()
    {
        Debug.Log("attacking");
        animator.SetTrigger("attack");
        navMeshAgent.isStopped = true;
        speed = 0f;
        transform.LookAt(player.position);
        animator.applyRootMotion = false;
    }
}
