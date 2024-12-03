using UnityEngine;
using TMPro;

public class FishController : MonoBehaviour
{
    public TMP_Text powerText;
    public int AnswerValue { get; set; }

    public void SetPowerText(string power)
    {
        powerText.text = power;
    }

    public void HighlightText(Color color)
    {
        powerText.color = color;
    }

    public void ResetState()
    {
        powerText.color = Color.white; // Rengi sıfırla
    }

    private void OnMouseDown()
    {
        FindObjectOfType<GameManager>().OnFishClicked(this);
    }
}
