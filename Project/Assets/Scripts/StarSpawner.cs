using UnityEngine;
using System.Linq;

public class StarSpawner : MonoBehaviour
{
    public Transform[] spawnPoints; // Spawn noktalarını içeren dizi
    public GameObject[] starPrefabs; // Yıldız prefab'larını içeren dizi
    private int remainingStars; // Kalan yıldız sayısını takip etmek için

    void Start()
    {
        StartNewRound();
    }

    void StartNewRound()
    {
        // Yıldızları spawn et ve kalan yıldız sayısını sıfırla
        SpawnStars();
        remainingStars = 5; // Her turda 5 yıldız var
    }

    void SpawnStars()
    {
        var shuffledSpawnPoints = spawnPoints.OrderBy(x => Random.value).Take(5).ToArray();

        for (int i = 0; i < shuffledSpawnPoints.Length; i++)
        {
            GameObject randomStarPrefab = starPrefabs[Random.Range(0, starPrefabs.Length)];
            GameObject spawnedStar = Instantiate(randomStarPrefab, shuffledSpawnPoints[i].position, Quaternion.identity, shuffledSpawnPoints[i]);
            
            // Collider ekle
            AddCollider(spawnedStar);
        }
    }

    void AddCollider(GameObject star)
    {
        if (star.GetComponent<Collider>() == null)
        {
            BoxCollider boxCollider = star.AddComponent<BoxCollider>();
            boxCollider.isTrigger = true;
        }

        // Tıklama bileşeni ekle ve StarClickDetector'e tur referansı ver
        StarClickDetector clickDetector = star.AddComponent<StarClickDetector>();
        clickDetector.OnStarClicked = OnStarClicked;
    }

    // Bir yıldız tıklandığında çağrılır
    void OnStarClicked()
    {
        remainingStars--;

        if (remainingStars <= 0)
        {
            Debug.Log("Tüm yıldızlar bulundu! Yeni tur başlıyor...");
            StartNewRound(); // Yeni bir tur başlat
        }
    }
}

public class StarClickDetector : MonoBehaviour
{
    public System.Action OnStarClicked; // Tıklama olayını takip eden callback

    private void OnMouseDown()
    {
        Debug.Log($"{gameObject.name} yıldızına tıklandı ve kayboldu!");
        
        // Yıldızı yok et
        Destroy(gameObject);

        // Tıklama olayını bildir
        OnStarClicked?.Invoke();
    }
}
