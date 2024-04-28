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
    public float animationDuration = 10f; // Длительность анимации в секундах
    private bool isRightChoice = DoctorController.isRightChoice;
    private bool animationEnded = AnimationEventEnder.isAnimationEnded;

    public static bool hasMadeChoice = false;
    private float remainingTime;

    void Start()
    {
        // Получаем компонент TextMeshProUGUI из объекта
        scoreText = GetComponent<TextMeshProUGUI>();

        // Проверяем, был ли компонент успешно получен
        if (scoreText == null)
        {
            Debug.LogError("TextMeshPro component is not found!");
        }

        remainingTime = animationDuration;
    }

    private void Update()
    {
        // Уменьшаем оставшееся время
        remainingTime -= Time.deltaTime;

        // Проверяем, если оставшееся время меньше или равно 0
        if (remainingTime <= 0f)
        {
            if (!hasMadeChoice)
            {
                // Если игрок не сделал выбор, вычитаем штрафные очки
                DeductPoints();
            }

            // Сбрасываем флаг выбора и обновляем время
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

