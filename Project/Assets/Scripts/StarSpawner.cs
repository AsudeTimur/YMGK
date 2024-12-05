using UnityEngine;
using TMPro;
using System.Linq;

public class StarGame : MonoBehaviour
{
    public Transform[] spawnPoints; // Spawn noktaları
    public GameObject[] starPrefabs; // Yıldız prefab'ları
    public TextMeshProUGUI scoreText; // Skor göstergesi

    private int remainingStars; // Kalan yıldız sayısı
    private int score; // Toplam puan

    void Start()
    {
        score = 0; // Skoru sıfırla
        UpdateScoreUI();
        StartNewRound(); // İlk turu başlat
    }

    void Update()
    {
        // Mouse sol tuşuna basıldığında tıklama kontrolü yap
        if (Input.GetMouseButtonDown(0))
        {
            DetectClick();
        }
    }

    void DetectClick()
    {
        // Tıklanan nesneyi algıla
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform.CompareTag("Star"))
            {
                Debug.Log($"Yıldıza tıklandı: {hit.transform.name}");
                Destroy(hit.transform.gameObject);
                HandleStarClick();
            }
            else
            {
                Debug.Log("Yanlış bir nesneye tıklandı!");
                HandleEmptySpaceClick();
            }
        }
        else
        {
            Debug.Log("Boş bir alana tıklandı!");
            HandleEmptySpaceClick();
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {score}";
        }
    }

    void StartNewRound()
    {
        ClearOldStars(); // Önceki yıldızları temizle
        SpawnRandomStars(5); // 5 rastgele yıldız oluştur
        remainingStars = 5; // Her turda 5 yıldız
    }

    void SpawnRandomStars(int count)
    {
        var randomSpawnPoints = spawnPoints.OrderBy(x => Random.value).Take(count).ToArray();

        foreach (var spawnPoint in randomSpawnPoints)
        {
            GameObject randomStarPrefab = starPrefabs[Random.Range(0, starPrefabs.Length)];
            GameObject spawnedStar = Instantiate(randomStarPrefab, spawnPoint.position, Quaternion.identity, spawnPoint);

            // Yıldıza "Star" tag'i ekle
            spawnedStar.tag = "Star";
            AddCollider(spawnedStar);
        }
    }

    void AddCollider(GameObject obj)
    {
        if (obj.GetComponent<Collider>() == null)
        {
            BoxCollider boxCollider = obj.AddComponent<BoxCollider>();
            boxCollider.isTrigger = true;
        }
    }

    void ClearOldStars()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            foreach (Transform child in spawnPoint)
            {
                Destroy(child.gameObject);
            }
        }
    }

    void HandleStarClick()
    {
        score += 10; // Puan ekle
        remainingStars--; // Kalan yıldız sayısını azalt

        UpdateScoreUI();

        if (remainingStars <= 0)
        {
            Debug.Log("Tüm yıldızlar bulundu! Yeni tur başlıyor...");
            StartNewRound(); // Yeni bir tur başlat
        }
    }

    void HandleEmptySpaceClick()
    {
        score -= 5; // Puan çıkar
        if (score < 0) score = 0; // Puanı sıfırın altına indirme

        UpdateScoreUI();
    }
}
