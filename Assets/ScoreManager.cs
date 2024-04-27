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

    public float animationDuration = 10f; // ������������ �������� � ��������
    private static bool isRightChoice = PersonController.isRightChoice;
    private bool animationEnded = AnimationEventEnder.isAnimationEnded;


    void Start()
    {
        // �������� ��������� TextMeshProUGUI �� �������
        scoreText = GetComponent<TextMeshProUGUI>();

        // ���������, ��� �� ��������� ������� �������
        if (scoreText == null)
        {
            Debug.LogError("TextMeshPro component is not found!");
        }
    }

    private void Update()
    {
        // ���������, ���� �������� ��� �������� � ����� �� ����� ��������� ��������
        if (animationEnded || !isRightChoice) // ��������������, ��� "Fire1" - ��� ������, ������� ����� ������ ������
        {
            DeductPoints();
    
        }
        else if (!animationEnded && isRightChoice)
        {
            AddPoints();
           
        }
    }

    // ����������, ����� ����� ��������� ���������� �������� �� ����� ��������
    public void AddPoints()
    {
        score += reward;
        scoreText.text = "Score: " + score;
    }

    // ����������, ����� ����� �� �������� ��������� �������� �� ����� ��������
    private void DeductPoints()
    {
        score -= penalty;
        scoreText.text = "Score: " + score;
    }
}
