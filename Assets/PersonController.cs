using UnityEngine;

public class PersonController : MonoBehaviour
{
    public float moveSpeed = 14f;
    public Person person = null;
    private Vector3 endRightPosition = new Vector3(8, -1.61f, 0);
    private Vector3 endLeftPosition = new Vector3(-8, -1.61f, 0);

    [SerializeField] Animator animator;

    [SerializeField] AudioClip rightChoiceDementiONAudio;
    [SerializeField] AudioClip rightChoiceDementiOFFAudio;
    [SerializeField] AudioClip wrongChoiceDementiONAudio;
    [SerializeField] AudioClip wrongChoiceDementiOFFAudio;

    [SerializeField] AudioSource audioSource;
        
    private bool moveLeft;
    private bool moveRight;
    public static bool isRightChoice = true;

    private void Start()
    {
        person = Person.GenerateRandomPerson();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (moveRight)
        {
            if (transform.position != endRightPosition)
            {
                animator.SetBool("canWalk", true);
                transform.position = Vector3.MoveTowards(transform.position, endRightPosition, moveSpeed * Time.deltaTime);
                isRightChoice = true;
                audioSource.PlayOneShot(rightChoiceDementiONAudio);
            }
            else
            {
                Destroy(gameObject);
                isRightChoice = false;
<<<<<<< HEAD
                audioSource.PlayOneShot(wrongChoiceDementiONAudio);
=======
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
>>>>>>> 27598bd333b9173906a4c9ae6cdf6696cf3e72f2
            }
        }
        else if (moveLeft)
        {
            if (transform.position != endLeftPosition)

                animator.SetBool("canWalk", true);
            transform.localScale = Vector3.left;
            transform.position = Vector3.MoveTowards(transform.position, endLeftPosition, moveSpeed * Time.deltaTime);
            isRightChoice = true;
            audioSource.PlayOneShot(rightChoiceDementiOFFAudio);
        }
        else
        {
            Destroy(gameObject);
            isRightChoice = false;
            audioSource.PlayOneShot(wrongChoiceDementiOFFAudio);
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
