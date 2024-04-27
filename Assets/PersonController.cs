using UnityEngine;

public class PersonController : MonoBehaviour
{
    public float moveSpeed = 14f;
    public Person person = null;
    private Vector3 endRightPosition = new Vector3(8, -1.61f, 0);
    private Vector3 endLeftPosition = new Vector3(-8, -1.61f, 0);

    [SerializeField] Animator animator;

    private bool moveLeft;
    private bool moveRight;
    public static bool isRightChoice = true;

    private void Start()
    {
        person = Person.GenerateRandomPerson();
    }

    private void Update()
    {
        if (moveRight) {
            if (transform.position != endRightPosition)
            {
                animator.SetBool("canWalk", true);
                transform.position = Vector3.MoveTowards(transform.position, endRightPosition, moveSpeed * Time.deltaTime);
                isRightChoice = true;
            }
            else
            {
                Destroy(gameObject);
                isRightChoice = false;
            }
        } else if (moveLeft)
        {
            if (transform.position != endLeftPosition)
            {
                animator.SetBool("canWalk", true);
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                transform.position = Vector3.MoveTowards(transform.position, endLeftPosition, moveSpeed * Time.deltaTime);
                isRightChoice=true;
            }
            else 
            { 
                Destroy(gameObject);
                isRightChoice = false;
            }
        }
    }

    public void MoveLeft()
    {
        moveLeft = true;

    }

    public void MoveRight()
    {
        moveRight = true;
    }
}
