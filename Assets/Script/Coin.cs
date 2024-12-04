using UnityEngine;

public class Coin : MonoBehaviour
{
    public CoinManager coinManager; // Referensi ke CoinManager

    void Start()
    {
        if (coinManager == null)
        {
            Debug.LogError(gameObject.name + " tidak memiliki referensi ke CoinManager.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + " menyentuh koin: " + gameObject.name); // Log collider yang menyentuh
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player menyentuh koin: " + gameObject.name);
            if (coinManager != null)
            {
                coinManager.CollectCoin(); // Tambahkan koin
                Debug.Log("Koin berhasil ditambahkan.");
            }
            else
            {
                Debug.LogError("CoinManager tidak terhubung!");
            }
            Destroy(gameObject); // Hapus koin
        }
    }
}
