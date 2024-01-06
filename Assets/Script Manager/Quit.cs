using UnityEngine;

public class Quit : MonoBehaviour
{
    // Fungsi ini bisa dipanggil dari tombol atau kondisi tertentu
    public void QuitGame()
    {
        Debug.Log("Keluar dari Game"); // Tambahkan pesan ke konsol sebelum keluar
        // Aplikasi akan keluar saat dijalankan di standalone build
        // Di editor Unity, ini hanya akan menghentikan pemutaran
        Application.Quit();
    }
}
