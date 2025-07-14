using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //[SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _startMovementPoint;
    [SerializeField] private GameObject _endMovementPoint;

    private Rigidbody2D rb;
    private Transform currentPoint;
    private float speed = 10f;

    private bool movementInRightSide = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = _endMovementPoint.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (movementInRightSide)
        {
            transform.position = Vector3.MoveTowards(transform.position, _endMovementPoint.transform.position, speed * Time.deltaTime);
            if (transform.position == _endMovementPoint.transform.position)
            {
                movementInRightSide = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _startMovementPoint.transform.position, speed * Time.deltaTime);
            if (transform.position == _startMovementPoint.transform.position)
            {
                movementInRightSide = true;
            }
        }
            //Vector2 point = currentPoint.position - transform.position; 
            //if (currentPoint == _endMovementPoint.transform)
            //{
            //    rb.linearVelocityX = speed;
            //}
            //else
            //{
            //    rb.linearVelocityX = -speed;
            //}
    }
}
