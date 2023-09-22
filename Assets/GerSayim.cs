using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GerSayim : MonoBehaviour
{
    public Text kronometre;
    public float geriSayimSuresi = 100.0f; // Geri sayým süresi (saniye)
    private float kalanSure;

    void Start()
    {
        kalanSure = geriSayimSuresi;
        GuncelleGeriSayimMetni();
    }

    void Update()
    {
        if (kalanSure > 0)
        {
            kalanSure -= Time.deltaTime;
            GuncelleGeriSayimMetni();
        }
        else
        {
            // Geri sayým bittiðinde sahneyi deðiþtir
            SahneDegistir();
        }
    }

    void GuncelleGeriSayimMetni()
    {
        int kalanSaniye = Mathf.CeilToInt(kalanSure);
        kronometre.text = kalanSaniye.ToString();
    }

    void SahneDegistir()
    {
        int hangiSahne = SceneManager.GetActiveScene().buildIndex;
        int hedefSahne = (hangiSahne + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(hedefSahne);
    }
}