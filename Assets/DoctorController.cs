using UnityEngine;
using UnityEngine.UI;

public class DoctorController : MonoBehaviour
{
   [SerializeField] private GameObject patientPrefab;
    private GameObject patientInstance = null;
    private PersonController personController = null;
    public float moveSpeed = 5f;


    private void Start()
    {
        patientInstance = Instantiate(patientPrefab);

        personController = patientInstance.GetComponent<PersonController>();
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
        if (patientInstance == null)
        {
            patientInstance = Instantiate(patientPrefab);

            personController = patientInstance.GetComponent<PersonController>();
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
