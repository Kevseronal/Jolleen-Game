using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KlonOlustur : MonoBehaviour
{
    public GameObject kutuPrefab; // Oluþturulacak kutu nesnesi
    public GameObject kristalPrefab;
    public GameObject kristalPrefab1;
    public GameObject kristalPrefab2;
    public GameObject kristalPrefab3;

    public int kutuSayisi = 20; // Oluþturulacak kutu sayýsý
    public int kristalSayiai = 35;
    public float minX = 41f; // X düzleminin minimum sýnýrý
    public float maxX = 144f; // X düzleminin maksimum sýnýrý
    public float minZ = 41f; // Z düzleminin minimum sýnýrý
    public float maxZ = 148f; // Z düzleminin maksimum sýnýrý

    void Start()
    {
        // Belirtilen sayýda kutu oluþtur
        for (int i = 0; i < kutuSayisi; i++)
        {
            OluþturKutu();
        }
        for (int i = 0; i < kristalSayiai; i++)
        {
            OluþturKristal();
        }
    }
     
    void OluþturKutu()
    {
        // Rastgele bir konum oluþturur.
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);
        Vector3 randomPosition = new Vector3(randomX, 0f, randomZ);

        // Kutu nesnesini oluþtur ve konumunu ayarladýk
        GameObject yeniKutu = Instantiate(kutuPrefab, randomPosition, Quaternion.identity);

    }
    void OluþturKristal()
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
        
        // Rastgele bir konum oluþtur
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);
        Vector3 randomPosition = new Vector3(randomX, 0f, randomZ);

        // kristal nesnesini oluþtur ve konumunu ayarla
        GameObject yeniKristal = Instantiate(kristalPrefab, randomPosition, Quaternion.identity);

    }
}
