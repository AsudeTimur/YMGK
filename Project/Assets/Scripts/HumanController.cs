using UnityEngine;
using TMPro;

public class HumanController : MonoBehaviour
{
    public TMP_Text answerText;
    public int AnswerValue { get; set; }

    public void SetAnswerText(int answer)
    {
        answerText.text = answer.ToString();
    }

    public void HighlightText(Color color)
    {
        answerText.color = color;
    }

    public void ResetState()
    {
        answerText.color = Color.white; // Rengi sıfırla
    }

    private void OnMouseDown()
    {
        FindObjectOfType<GameManager>().OnHumanClicked(this);
    }
}
