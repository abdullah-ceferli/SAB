using UnityEngine;

public class BrainrotMover : MonoBehaviour
{
    private Vector3 target;
    public float speed = 2f;

    public void Init(Vector3 targetPoint)
    {
        target = targetPoint;
    }

    void Update()
    {
        if (target == Vector3.zero) return;

        transform.position = Vector3.MoveTowards(
            transform.position,
            target,
            speed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            Destroy(gameObject);
        }
    }
}
