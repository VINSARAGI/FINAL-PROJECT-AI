using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public GameObject coinPrefab;
    public int totalCoins = 10;
    public float spawnRange = 10f;
    public TextMeshProUGUI coinText;
    public LayerMask groundLayer;

    private int coinCount = 0;

    void Start()
    {
        SpawnCoins();
        UpdateCoinText();
    }

    void SpawnCoins()
    {
        for (int i = 0; i < totalCoins; i++)
        {
        // Tentukan posisi spawn acak
            Vector3 randomPos = new Vector3(
                transform.position.x + Random.Range(-spawnRange, spawnRange),
                transform.position.y + 10f, // Spawn di atas untuk Raycast
                transform.position.z + Random.Range(-spawnRange, spawnRange)
            );

        // Gunakan Raycast untuk menempatkan koin di atas tanah
            if (Physics.Raycast(randomPos, Vector3.down, out RaycastHit hit, Mathf.Infinity, groundLayer))
            {
                randomPos.y = hit.point.y + 0.5f;
            }

        // Spawn koin
            GameObject coin = Instantiate(coinPrefab, randomPos, Quaternion.identity);
        
        // Tambahkan referensi CoinManager
            Coin coinScript = coin.GetComponent<Coin>();
            if (coinScript != null)
            {
                coinScript.coinManager = this; // Berikan referensi CoinManager
                Debug.Log("Koin berhasil di-*spawn* dengan referensi CoinManager.");
            }
            else
            {
                Debug.LogError("Prefab Coin tidak memiliki skrip Coin.cs!");
            }
        }
    }

    public void CollectCoin()
    {
        coinCount++;
        Debug.Log("Koin terkumpul: " + coinCount);
        UpdateCoinText();
    }

    void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + coinCount;
        }
        else
        {
            Debug.LogError("TextMeshPro untuk coinText belum diatur.");
        }
    }
}
