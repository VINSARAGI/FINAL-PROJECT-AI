using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionHandler : MonoBehaviour
{
    public string sceneToLoad = "Menu"; // Nama scene yang ingin dimuat

    private void OnTriggerEnter(Collider other)
    {
        // Jika bertabrakan dengan GameObject yang memiliki tag "Obstacle"
        if (other.CompareTag("Block"))
        {
            Debug.Log("Kamu kalah! Memindahkan ke scene: " + sceneToLoad);
            SceneManager.LoadScene(sceneToLoad); // Pindah ke scene yang ditentukan
        }
    }
}
