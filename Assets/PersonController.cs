using TMPro;
using UnityEngine;

public class PersonController : MonoBehaviour
{
    public float moveSpeed = 14f;
    public Person person = null;
    private TextMeshProUGUI medicalText = null;
    private Vector3 endRightPosition = new Vector3(8, -1.61f, 0);
    private Vector3 endLeftPosition = new Vector3(-8, -1.61f, 0);

    [SerializeField] private Animator animator;


    private bool moveLeft;
    private bool moveRight;
    public bool isRightChoice = true;

    private void Start()
    {
        medicalText = GameObject.Find("MedText").GetComponent<TextMeshProUGUI>();
        person = Person.GenerateRandomPerson();
        medicalText.text = person.MedicalCard.ToString();
    }

    private void Update()
    {
        if (moveRight) {
            if (transform.position != endRightPosition)
            {
                animator.SetBool("canWalk", true);
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
                animator.SetBool("canWalk", true);
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
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
        isRightChoice = !person.Dementia;
        moveLeft = true;

    }

    public void MoveRight()
    {
        isRightChoice = person.Dementia;
        moveRight = true;
    }
}
