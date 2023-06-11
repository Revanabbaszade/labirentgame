using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f; // Mermi hızı
    public int damage = 10; // Mermi hasarı
    public GameObject bulletPrefab; // Mermi prefabı
    public Transform bulletSpawn; // Mermi çıkış noktası
    public Rigidbody rb;

    // Mermiyi hareket ettirme
    void Update()
    {

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }

    }
    void Start()
    {
        transform.position = bulletSpawn.position;
        rb.velocity = transform.right * speed;
    }

    void Fire()
    {
        
        {
            // bulletSpawn değişkeninin null olup olmadığını kontrol et
            if (bulletSpawn != null)
            {
                // Mermi nesnesini oluştur
                GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

                // Mermi hızını ve hasarını ayarla
                Bullet bulletComponent = bullet.GetComponent<Bullet>();
                bulletComponent.speed = 20f;
                bulletComponent.damage = 10;
            }
        }

    }
    // Mermi çarpışması
    void OnTriggerEnter(Collider other)
    {
        // Eğer düşmanla çarpışırsa hasar ver
        

        // Mermiyi yok et
        Destroy(gameObject);
    }
}
