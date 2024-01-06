using UnityEngine;

public class CueBall : MonoBehaviour
{
    private bool isDragging = false;
    private Vector2 dragStartPos;
    private Vector2 dragEndPos;
    private float maxDragDistance = 1500f; // Jarak maksimum untuk menentukan kecepatan pukulan

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnDragStart();
        }

        if (Input.GetMouseButton(0))
        {
            OnDragging();
        }

        if (Input.GetMouseButtonUp(0))
        {
            OnDragEnd();
        }
    }

    void OnDragStart()
    {
        isDragging = true;
        dragStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void OnDragging()
    {
        if (isDragging)
        {
            dragEndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    void OnDragEnd()
    {
        if (isDragging)
        {
            isDragging = false;

            // Hitung vektor arah dari posisi awal ke posisi akhir
            Vector2 dragVector = dragEndPos - dragStartPos;

            // Normalisasi vektor arah
            Vector2 shotDirection = dragVector.normalized;

            // Hitung kecepatan pukulan berdasarkan panjang vektor drag, dengan batasan maksimum
            float shotSpeed = Mathf.Clamp(dragVector.magnitude, 0, maxDragDistance);

            // Terapkan gaya ke bola cue
            rb.AddForce(shotDirection * shotSpeed, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TableBoundary"))
        {
            // Mendeteksi tabrakan dengan pembatas meja
            ReflectOffTableBoundary(collision.contacts[0].normal);
        }
        else if (collision.gameObject.CompareTag("TargetBall"))
        {
            Debug.Log("Bola target terkena!");
            // Tambahkan logika atau skor yang sesuai di sini
        }
    }

    void ReflectOffTableBoundary(Vector2 normal)
    {
        // Menghitung pantulan reflektif terhadap pembatas meja
        Vector2 reflectedDirection = Vector2.Reflect(rb.velocity.normalized, normal);

        // Terapkan kecepatan setelah pantulan
        rb.velocity = reflectedDirection * rb.velocity.magnitude;
    }
}
