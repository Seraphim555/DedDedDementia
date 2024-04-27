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

    public float animationDuration = 10f; // Длительность анимации в секундах
    private static bool isRightChoice = PersonController.isRightChoice;
    private bool animationEnded = AnimationEventEnder.isAnimationEnded;


    void Start()
    {
        // Получаем компонент TextMeshProUGUI из объекта
        scoreText = GetComponent<TextMeshProUGUI>();

        // Проверяем, был ли компонент успешно получен
        if (scoreText == null)
        {
            Debug.LogError("TextMeshPro component is not found!");
        }
    }

    private void Update()
    {
        // Проверяем, если анимация уже началась и игрок не успел совершить действие
        if (animationEnded || !isRightChoice) // Предполагается, что "Fire1" - это кнопка, которую игрок должен нажать
        {
            DeductPoints();
    
        }
        else if (!animationEnded && isRightChoice)
        {
            AddPoints();
           
        }
    }

    // Вызывается, когда игрок совершает правильное действие во время анимации
    public void AddPoints()
    {
        score += reward;
        scoreText.text = "Score: " + score;
    }

    // Вызывается, когда игрок не успевает совершить действие во время анимации
    private void DeductPoints()
    {
        score -= penalty;
        scoreText.text = "Score: " + score;
    }
}
