using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public int score = 0;
    public int penalty = 100;
    public int reward = 100;

    [SerializeField] private Animator animator;
    public float animationDuration = 10f; // ������������ �������� � ��������
    private bool isRightChoice = DoctorController.isRightChoice;
    private bool animationEnded = AnimationEventEnder.isAnimationEnded;

    public static bool hasMadeChoice = false;
    private float remainingTime;

    void Start()
    {
        // �������� ��������� TextMeshProUGUI �� �������
        scoreText = GetComponent<TextMeshProUGUI>();

        // ���������, ��� �� ��������� ������� �������
        if (scoreText == null)
        {
            Debug.LogError("TextMeshPro component is not found!");
        }

        remainingTime = animationDuration;
    }

    private void Update()
    {
        // ��������� ���������� �����
        remainingTime -= Time.deltaTime;

        // ���������, ���� ���������� ����� ������ ��� ����� 0
        if (remainingTime <= 0f)
        {
            if (!hasMadeChoice)
            {
                // ���� ����� �� ������ �����, �������� �������� ����
                DeductPoints();
            }

            // ���������� ���� ������ � ��������� �����
            hasMadeChoice = false;
            remainingTime = animationDuration;
            animator.Play("New Animation", -1, 0f);
        } else if (hasMadeChoice) { 
            if (DoctorController.isRightChoice)
            {
                AddPoints();
            } else if (!DoctorController.isRightChoice)
            {
                DeductPoints();
            }
            hasMadeChoice = false;
        }
    }

    public void AddPoints()
    {
        score += reward;
        UpdateScoreText();
        animator.Play("New Animation", -1, 0f);

    }

    public void DeductPoints()
    {
        score -= penalty;
        UpdateScoreText();
        animator.Play("New Animation", -1, 0f);

    }

    private void UpdateScoreText()
    {
        scoreText.text = $"Score: {score}";
    }
}

