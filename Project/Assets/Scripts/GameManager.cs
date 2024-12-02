using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<FishController> fishList;   // Balıklar
    public List<HumanController> humanList; // İnsanlar

    private FishController selectedFish;   // Seçilen balık
    private HumanController selectedHuman; // Seçilen insan

    void Start()
    {
        AssignValues(); // Oyuna başlarken balıklara ve insanlara değerler atayın
    }

    // Balık ve insanlara rastgele değerler ata
    void AssignValues()
    {
        List<int> numbers = new List<int> { 25, 36, 49, 64 }; // İnsanlara atanacak sayılar
        List<int> bases = new List<int> { 5, 6, 7, 8 };       // Balıklara atanacak tabanlar

        // Balıklara değer ata
        for (int i = 0; i < fishList.Count; i++)
        {
            int index = Random.Range(0, bases.Count);
            fishList[i].SetPower(bases[index]);
            bases.RemoveAt(index);
        }

        // İnsanlara değer ata
        for (int i = 0; i < humanList.Count; i++)
        {
            int index = Random.Range(0, numbers.Count);
            humanList[i].SetAnswer(numbers[index]);
            numbers.RemoveAt(index);
        }
    }

    // Balık seçimi
    public void OnSelectFish(FishController fish)
    {
        selectedFish = fish;
        CheckSelection();
    }

    // İnsan seçimi
    public void OnSelectHuman(HumanController human)
    {
        selectedHuman = human;
        CheckSelection();
    }

    // Seçimleri kontrol et
    void CheckSelection()
    {
        if (selectedFish != null && selectedHuman != null)
        {
            // Eşleşme doğru mu?
            if (selectedFish.GetPowerResult() == selectedHuman.GetAnswer())
            {
                Debug.Log("Eşleşme doğru!");
                selectedFish.gameObject.SetActive(false); // Balığı devre dışı bırak
                selectedHuman.gameObject.SetActive(false); // İnsanı devre dışı bırak
            }
            else
            {
                Debug.Log("Yanlış eşleşme!");
            }

            // Seçimleri sıfırla
            selectedFish = null;
            selectedHuman = null;
        }
    }
}
