using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // Kameranın takip edeceği nesne

    private Vector3 offset; // Kamera ve nesne arasındaki mesafe

    void Start()
    {
        // Kamera ve nesne arasındaki mesafeyi hesapla
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        // Kameranın konumunu güncelle
        transform.position = player.position + offset;
    }
}
