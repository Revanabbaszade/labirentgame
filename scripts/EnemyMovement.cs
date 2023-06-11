using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 5f;    // Düşmanın hareket hızı
    public float detectionDistance = 10f;   // Düşmanın oyuncuyu algılama mesafesi

    private Transform player;   // Oyuncunun Transform bileşeni
   

    void Start()
    {
        // Oyuncunun Transform bileşenini bul
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Oyuncu düşmanın algılama mesafesi içindeyse, oyuncunun pozisyonuna doğru hareket et
        if (IsPlayerInRange())
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
            // Düşmanın pozisyonu, oyuncunun pozisyonuna doğru çevrilir
            transform.LookAt(player);

        }
    }

    bool IsPlayerInRange()
    {
        // Oyuncu, düşmanın algılama mesafesi içinde mi?
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        return distanceToPlayer <= detectionDistance;
    }
    
}
