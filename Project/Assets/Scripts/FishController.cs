using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FishController : MonoBehaviour
{
    public TMP_Text powerText; // Balığın üstündeki üslü ifade text'i
    private int powerBase;     // Üssün tabanı
    private int powerResult;   // Hesaplanmış üs sonucu

    // Üslü ifadeyi ayarla
    public void SetPower(int baseNumber)
    {
        powerBase = baseNumber;
        powerResult = (int)Mathf.Pow(baseNumber, 2); // Üssü hesapla (base^2)
        powerText.text = baseNumber + "²";     // TMP_Text'e üslü ifadeyi yaz
    }

    // Üssün sonucunu döndür
    public int GetPowerResult()
    {
        return powerResult;
    }

    // Balığa tıklanınca çağrılır
    void OnMouseDown()
    {
        FindObjectOfType<GameManager>().OnSelectFish(this); // GameManager'a bildir
    }
}
