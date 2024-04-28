using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DoctorController : MonoBehaviour
{
    [SerializeField] private GameObject patientPrefab;
    [SerializeField] private GameObject medicalPanel;
    private GameObject patientInstance = null;
    private PersonController personController = null;
    public float moveSpeed = 5f;

    public static bool isRightChoice = false;


    private void Start()
    {

        patientInstance = Instantiate(patientPrefab);

        personController = patientInstance.GetComponent<PersonController>();

    }

    private void Update()
    {
        if (patientInstance == null)
        {
            patientInstance = Instantiate(patientPrefab);

            personController = patientInstance.GetComponent<PersonController>();
        }
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
        ScoreManager.hasMadeChoice = true;
        isRightChoice = personController.isRightChoice;

    }

    public void SendRight()
    {
        personController.MoveRight();
        ScoreManager.hasMadeChoice = true;
        isRightChoice = personController.isRightChoice;
    }


    public void GetMedicalCardInfo()
    {
        return;
    }

    public void HideMedicalCardInfo()
    {
        return;
    }
}
