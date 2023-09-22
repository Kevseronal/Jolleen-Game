using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kutu : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject DustExplosion; // Patlama animasyonunun GameObject referans�
    public GameObject meyvePrefab;
    public GameObject karpuzPrefab;
    public GameObject muzPrefab;
    public GameObject visnePrefab;


    public void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Belirtilen say�da meyve olu�turun
        for (int i = 0; i < 1; i++)
        {
            GameObject meyvePrefab = GetRandomMeyvePrefab();

            // Meyve prefab�n� belirli bir pozisyon ve rotasyonda olu�turun
            Vector3 meyvePosition = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
            Instantiate(meyvePrefab, meyvePosition, Quaternion.identity);
        }


    }


    private GameObject GetRandomMeyvePrefab()
    {
        float randomsayi = Random.Range(0f, 1f); // 0 ile 1 aras�nda rastgele bir say� �retin

        //float randomsayi = 5;
        if (randomsayi <= 0.33f)
        {
            return karpuzPrefab;
        }
        else if (randomsayi <= 0.67f)
        {
            return muzPrefab;
        }
        else
        {
            return visnePrefab;
        }
    }
}
