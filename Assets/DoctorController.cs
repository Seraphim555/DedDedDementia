using UnityEngine;
using UnityEngine.UI;

public class DoctorController : MonoBehaviour
{
   [SerializeField] public PersonController person;
    private PersonController personController = null;
    public float moveSpeed = 5f;


    private void Start()
    {
        personController = person.GetComponent<PersonController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SendLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SendRight();
        }
    }


    public void SendLeft()
    {
        personController.MoveLeft();
    }

    public void SendRight()
    {
        personController.MoveRight();
    }
}
