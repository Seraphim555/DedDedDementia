using UnityEngine;

public class PersonController : MonoBehaviour
{
    public float moveSpeed = 14f;
    public GameObject panel;
    public Person currentPerson = null;
    
    private bool moveLeft;
    private bool moveRight;
    private bool madeDecision;

    private void Start()
    {
        madeDecision = false;
        currentPerson = Person.GenerateRandomPerson();
        panel.SetActive(false);
    }

    private void Update()
    {
        if (moveRight && !madeDecision) {
            transform.Translate(Vector2.right * (moveSpeed * Time.deltaTime));
        } else if (moveLeft && !madeDecision)
        {
            transform.Translate(Vector2.left * (moveSpeed * Time.deltaTime));
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
