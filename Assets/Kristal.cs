using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kristal : MonoBehaviour
{
    public GameObject EnergyExplosion; // Patlama animasyonunun GameObject referans�
    public float animDuration = 2f; // Patlama animasyonunun s�resi

    private void OnCollisionEnter(Collision collision)
    {
        // �arp��an nesnenin etiketini kontrol edin (�rne�in, "Oyuncu" olarak kabul edelim)
        if (collision.gameObject.tag == "player")
        {
            UnityEngine.Debug.Log("�al��t�");
            // Patlama animasyonunu �al��t�r
            GameObject explosion = Instantiate(EnergyExplosion, transform.position, Quaternion.identity);

            // Patlama animasyonunu durdurmak i�in bir s�re bekleyin ve sonra yok edin
            Destroy(explosion, animDuration);

            // Kutuyu yok et
            Destroy(gameObject);

           
        }
    }
}
