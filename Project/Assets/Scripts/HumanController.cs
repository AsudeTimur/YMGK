using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HumanController : MonoBehaviour
{
    public TMP_Text answerText; // İnsan objesindeki sayı text'i
    private int answer;         // Sayı (cevap)

    // Sayıyı ayarla
    public void SetAnswer(int value)
    {
        answer = value;
        answerText.text = value.ToString(); // TMP_Text'e sayıyı yaz
    }

    // Sayıyı döndür
    public int GetAnswer()
    {
        return answer;
    }

    // İnsana tıklanınca çağrılır
    void OnMouseDown()
    {
        FindObjectOfType<GameManager>().OnSelectHuman(this); // GameManager'a bildir
    }
}
