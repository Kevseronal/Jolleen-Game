using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KlonOlustur : MonoBehaviour
{
    public GameObject kutuPrefab; // Olu�turulacak kutu nesnesi
    public GameObject kristalPrefab;
    public GameObject kristalPrefab1;
    public GameObject kristalPrefab2;
    public GameObject kristalPrefab3;

    public int kutuSayisi = 20; // Olu�turulacak kutu say�s�
    public int kristalSayiai = 35;
    public float minX = 41f; // X d�zleminin minimum s�n�r�
    public float maxX = 144f; // X d�zleminin maksimum s�n�r�
    public float minZ = 41f; // Z d�zleminin minimum s�n�r�
    public float maxZ = 148f; // Z d�zleminin maksimum s�n�r�

    void Start()
    {
        // Belirtilen say�da kutu olu�tur
        for (int i = 0; i < kutuSayisi; i++)
        {
            Olu�turKutu();
        }
        for (int i = 0; i < kristalSayiai; i++)
        {
            Olu�turKristal();
        }
    }
     
    void Olu�turKutu()
    {
        // Rastgele bir konum olu�turur.
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);
        Vector3 randomPosition = new Vector3(randomX, 0f, randomZ);

        // Kutu nesnesini olu�tur ve konumunu ayarlad�k
        GameObject yeniKutu = Instantiate(kutuPrefab, randomPosition, Quaternion.identity);

    }
    void Olu�turKristal()
    {
        float randomSayi = Random.Range(1, 100);
        
        if(randomSayi>0 && randomSayi < 34)
        {
            kristalPrefab = kristalPrefab1;
        }
        if (randomSayi > 33 && randomSayi < 67)
        {
            kristalPrefab = kristalPrefab2;
        }
        if (randomSayi > 66 && randomSayi < 100)
        {
            kristalPrefab = kristalPrefab3;
        }
        
        // Rastgele bir konum olu�tur
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);
        Vector3 randomPosition = new Vector3(randomX, 0f, randomZ);

        // kristal nesnesini olu�tur ve konumunu ayarla
        GameObject yeniKristal = Instantiate(kristalPrefab, randomPosition, Quaternion.identity);

    }
}
