using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<HumanController> humans;
    public List<FishController> fishes;
    public TMP_Text scoreText; // Skoru göstereceğimiz UI Text

    private FishController selectedFish = null;
    private HumanController selectedHuman = null;

    private int matchesCompleted = 0; // Tamamlanan eşleşme sayısı
    private int score = 0; // Puan değişkeni

    private void Start()
    {
        AssignMatchingValues();
        UpdateScoreText();
    }

    private void AssignMatchingValues()
    {
        List<int> baseNumbers = new List<int>();
        for (int i = 1; i <= 10; i++) // 1'den 10'a kadar sayılar
        {
            baseNumbers.Add(i);
        }

        List<int> randomIndices = new List<int>();
        while (randomIndices.Count < humans.Count)
        {
            int randomIndex = Random.Range(0, baseNumbers.Count);
            if (!randomIndices.Contains(randomIndex))
            {
                randomIndices.Add(randomIndex);
            }
        }

        for (int i = 0; i < randomIndices.Count; i++)
        {
            int baseNumber = baseNumbers[randomIndices[i]];
            int result = baseNumber * baseNumber;

            fishes[i].SetPowerText($"{baseNumber}²");
            fishes[i].AnswerValue = result;
            fishes[i].ResetState(); // Balığın text rengini sıfırla

            humans[i].SetAnswerText(result);
            humans[i].AnswerValue = result;
            humans[i].ResetState(); // İnsanın text rengini sıfırla
        }
    }

    public void OnFishClicked(FishController fish)
    {
        selectedFish = fish;
        CheckMatch();
    }

    public void OnHumanClicked(HumanController human)
    {
        selectedHuman = human;
        CheckMatch();
    }

    private void CheckMatch()
    {
        if (selectedFish != null && selectedHuman != null)
        {
            if (selectedFish.AnswerValue == selectedHuman.AnswerValue)
            {
                Debug.Log("Correct Match!");
                selectedFish.HighlightText(Color.green);
                selectedHuman.HighlightText(Color.green);

                matchesCompleted++; // Bir eşleşme tamamlandı
                UpdateScore(10); // Doğru cevapta 10 puan ekle
            }
            else
            {
                Debug.Log("Wrong Match!");
                selectedFish.HighlightText(Color.red);
                selectedHuman.HighlightText(Color.red);

                UpdateScore(-5); // Yanlış cevapta 5 puan düşür
            }

            ResetSelection();

            if (matchesCompleted == humans.Count) // Tüm eşleşmeler tamamlandıysa
            {
                StartNewRound(); // Yeni bir tur başlat
            }
        }
    }

    private void UpdateScore(int points)
    {
        score += points; // Puanı güncelle
        UpdateScoreText(); // UI'yi güncelle
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString(); // Skor UI'yi güncelle
    }

    private void ResetSelection()
    {
        selectedFish = null;
        selectedHuman = null;
    }

    private void StartNewRound()
    {
        Debug.Log("Starting a new round...");
        matchesCompleted = 0;
        AssignMatchingValues(); // Yeni sayılar ata
    }
}
