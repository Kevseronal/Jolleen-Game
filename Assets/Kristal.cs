using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kristal : MonoBehaviour
{
    public GameObject EnergyExplosion; // Patlama animasyonunun GameObject referansý
    public float animDuration = 2f; // Patlama animasyonunun süresi

    private void OnCollisionEnter(Collision collision)
    {
        // Çarpýþan nesnenin etiketini kontrol edin (örneðin, "Oyuncu" olarak kabul edelim)
        if (collision.gameObject.tag == "player")
        {
            UnityEngine.Debug.Log("çalýþtý");
            // Patlama animasyonunu çalýþtýr
            GameObject explosion = Instantiate(EnergyExplosion, transform.position, Quaternion.identity);

            // Patlama animasyonunu durdurmak için bir süre bekleyin ve sonra yok edin
            Destroy(explosion, animDuration);

            // Kutuyu yok et
            Destroy(gameObject);

           
        }
    }
}
