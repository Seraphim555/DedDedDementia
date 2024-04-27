using UnityEngine;

public class PersonController : MonoBehaviour
{
    public float moveSpeed = 14f;
    public Person person = null;
    private Vector3 endRightPosition = new Vector3(8, -2.61f, 0);
    private Vector3 endLeftPosition = new Vector3(-8, -2.61f, 0);

    private bool moveLeft;
    private bool moveRight;

    private void Start()
    {
        person = Person.GenerateRandomPerson();
    }

    private void Update()
    {
        if (moveRight) {
            if (transform.position != endRightPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, endRightPosition, moveSpeed * Time.deltaTime);
            }
            else
            {
                Destroy(gameObject);
            }
        } else if (moveLeft)
        {
            if (transform.position != endLeftPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, endLeftPosition, moveSpeed * Time.deltaTime);
            }
            else 
            { 
                Destroy(gameObject);
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
