using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
    public Transform target; // The object to follow
    public float approachDistance = 10f; // Distance at which to start approaching the target
    public float followDistance = 3f; // Distance at which to start following the target
    public float attackDistance = 1.5f; // Distance at which to start attacking the target
    public float speed = 5f; // The speed at which the character moves
    private Animator animator; // Reference to the Animator component
    private bool isApproaching = false; // Flag to track if the enemy is approaching

    void Start()
    {
        animator = GetComponent<Animator>(); // Get the Animator component
    }

    void Update()
    {
        if (target == null)
            return; // No target to follow or attack, so do nothing

        // Calculate the distance to the target
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        // Determine whether to follow, approach, or attack based on proximity
        if (distanceToTarget <= approachDistance)
        {
            isApproaching = true;
        }

        if (isApproaching && distanceToTarget > attackDistance)
        {
            // Move towards the target if it's within approach distance but not attack distance
            FollowTarget();
        }
        else if (distanceToTarget <= attackDistance)
        {
            // Attack if the target is very close
            AttackTarget();
        }
    }

    void FollowTarget()
    {
        // Calculate the direction to move towards the target
        Vector3 direction = target.position - transform.position;
        direction.y = 0; // Ensure the character doesn't move vertically

        // Rotate character to face the target (optional)
        transform.rotation = Quaternion.LookRotation(direction);

        // Move character towards the target
        transform.position += direction.normalized * speed * Time.deltaTime;

        // Trigger the walking animation
        animator.SetBool("isWalking", true);
    }

    void AttackTarget()
    {
        // Rotate character to face the target (optional)
        Vector3 direction = target.position - transform.position;
        direction.y = 0; // Ensure the character doesn't move vertically
        transform.rotation = Quaternion.LookRotation(direction);

        // Trigger the attack animation
        animator.SetBool("isWalking", false);
        animator.SetTrigger("attack");
    }
}