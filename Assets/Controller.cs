using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;

public class Controller : MonoBehaviour
{
    public Animator animator;
    public Rigidbody rb;
    public Text kronometreText;
    public int kronometre;
    public float speed = 10;


    public Text pembeText;
    public Text maviText;
    public Text yesilText;
    public Text visneText;
    public Text muzText;
    public Text karpuzText;

    public GameObject EnergyExplosion; // Patlama animasyonunun GameObject referans�
    public GameObject DustExplosion; // Patlama animasyonunun GameObject referans�

    public float animDuration = 2f; // Patlama animasyonunun s�resi
    public float animDuration2 = 2f; // Patlama animasyonunun s�resi


    private bool isTurningRight = false; // Sa�a d�nme i�lemi devam ediyor mu?
    private bool isTurningLeft = false; // Sola d�nme i�lemi devam ediyor mu?
    private float currentRotationY = 0f; // Mevcut d�n�� a��s�
    public float rotationSpeed = 90f; // D�nme h�z� (derece/saniye)

    private float minX = 41f; // X d�zleminin minimum s�n�r�
    private float maxX = 144f; // X d�zleminin maksimum s�n�r�
    private float minZ = 41f; // Z d�zleminin minimum s�n�r�
    private float maxZ = 148f; // Z d�zleminin maksimum s�n�r�

    public AudioSource elmas;
    public AudioSource kirilma;
    public AudioSource win;
    public AudioSource zamansayac;
    public AudioSource arkaplanses;
    public AudioSource yemek;



    void Start()
    {
        
        int pembeSayi = UnityEngine.Random.Range(3, 5);
        pembeText.text = pembeSayi.ToString();
        int maviSayi = UnityEngine.Random.Range(3, 5);
        maviText.text = maviSayi.ToString();
        int yesilSayi = UnityEngine.Random.Range(3, 5);
        yesilText.text = yesilSayi.ToString();
        int karpuzSayi = UnityEngine.Random.Range(1, 3);
        karpuzText.text = karpuzSayi.ToString();
        int visneSayi = UnityEngine.Random.Range(1, 3);
        visneText.text = visneSayi.ToString();
        int muzSayi = UnityEngine.Random.Range(1, 3);
        muzText.text = muzSayi.ToString();
        

        zamansayac.Play();
        arkaplanses.Play();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("yuru", true);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("yuru", false);
                animator.SetBool("kos", true);
            }
            else
            {
                animator.SetBool("kos", false);
            }
        }
        else // "W" tu�una bas�lmad���nda
        {
            animator.SetBool("yuru", false);
            animator.SetBool("kos", false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("zipla", true);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("geriyuru", true);

        }
        if (Input.GetKey(KeyCode.O))
        {
            animator.SetBool("yumruk", true);
            Invoke("DestroyBox", 1.0f);

        }

        if (Input.GetKey(KeyCode.P))
        {
            animator.SetBool("tekme", true);
            Invoke("DestroyBox", 1.0f);

        }

        // "D" tu�una bas�ld���nda karakterin sa�a 90 derece d�nmesini ba�lat
        if (Input.GetKeyDown(KeyCode.D))
        {
            isTurningRight = true;
        }

        // "D" tu�u bas�l� tutuluyorsa karakteri sa�a do�ru d�nd�r
        if (Input.GetKey(KeyCode.D) && isTurningRight)
        {
            currentRotationY += rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, currentRotationY, 0f);
        }

        // "D" tu�u b�rak�ld���nda d�nme i�lemi sona ersin
        if (Input.GetKeyUp(KeyCode.D))
        {
            isTurningRight = false;
        }

        // "A" tu�una bas�ld���nda karakterin sola 90 derece d�nmesini ba�lat
        if (Input.GetKeyDown(KeyCode.A))
        {
            isTurningLeft = true;
        }

        // "A" tu�u bas�l� tutuluyorsa karakteri sola do�ru d�nd�r
        if (Input.GetKey(KeyCode.A) && isTurningLeft)
        {
            currentRotationY -= rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, currentRotationY, 0f);
        }

        // "A" tu�u b�rak�ld���nda d�nme i�lemi sona ersin
        if (Input.GetKeyUp(KeyCode.A))
        {
            isTurningLeft = false;
        }


        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.O) && !Input.GetKey(KeyCode.P))
        {
            animator.SetBool("yuru", false);
            animator.SetBool("zipla", false);
            animator.SetBool("kos", false);
            animator.SetBool("geriyuru", false);
            animator.SetBool("yumruk", false);
            animator.SetBool("tekme", false);
        }
        

        if (int.Parse(pembeText.text) == 0 && int.Parse(maviText.text) == 0 && int.Parse(yesilText.text) == 0 && int.Parse(karpuzText.text) == 0 && int.Parse(visneText.text) == 0 && int.Parse(muzText.text) == 0)
        {
            SahneDegistir();
            win.Play();
        }
    }
    void DestroyBox()
    {

        Vector3 forwardRayDirection = transform.forward;

        RaycastHit hitForward;


        // Ray, bir �eyi vurdu mu kontrol ettik

        if (Physics.Raycast(transform.position, forwardRayDirection, out hitForward, 5f))
        {
            // Vurulan nesnenin etiketini kontrol ettik
            if (hitForward.collider.CompareTag("kutu"))
            {
                kirilma.Play();
                // Kutuyu yok et
                // Patlama animasyonunu �al��t�r
                GameObject explosion = Instantiate(DustExplosion, transform.position, Quaternion.identity);

                // Patlama animasyonunu durdurmak i�in bir s�re bekleyin ve sonra yok edin
                Destroy(explosion, animDuration);

                Destroy(hitForward.collider.gameObject);
            }
        }

        

    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "maviKristal")
        {
            elmas.Play();
            // Patlama animasyonunu �al��t�r
            GameObject explosion = Instantiate(EnergyExplosion, transform.position, Quaternion.identity);

            // Patlama animasyonunu durdurmak i�in bir s�re bekleyin ve sonra yok edin
            Destroy(explosion, animDuration);
            Destroy(other.gameObject);

            int maviPuan = int.Parse(maviText.text);
            if (maviPuan != 0)
            {
                maviPuan -= 1;
            }
            maviText.text = maviPuan.ToString();
        }

        
        if (other.gameObject.tag == "pembeKristal")
        {
            elmas.Play();
            // Patlama animasyonunu �al��t�r
            GameObject explosion = Instantiate(EnergyExplosion, transform.position, Quaternion.identity);

            // Patlama animasyonunu durdurmak i�in bir s�re bekleyin ve sonra yok edin
            Destroy(explosion, animDuration);
            Destroy(other.gameObject);

            int pembePuan = int.Parse(pembeText.text);
            if (pembePuan != 0)
            {
                pembePuan -= 1;
            }
            pembeText.text = pembePuan.ToString();
        }
        if (other.gameObject.tag == "yesilKristal")
        {
            elmas.Play();
            // Patlama animasyonunu �al��t�r
            GameObject explosion = Instantiate(EnergyExplosion, transform.position, Quaternion.identity);

            // Patlama animasyonunu durdurmak i�in bir s�re bekleyin ve sonra yok edin
            Destroy(explosion, animDuration);
            Destroy(other.gameObject);

            int yesilPuan = int.Parse(yesilText.text);
            if(yesilPuan != 0)
            {
                yesilPuan -= 1;
            }
            
            yesilText.text = yesilPuan.ToString();
        }
        if (other.gameObject.tag == "karpuz")
        {
            yemek.Play();
            Destroy(other.gameObject);

            int karpuzPuan = int.Parse(karpuzText.text);
            if (karpuzPuan != 0)
            {
                karpuzPuan -= 1;
            }
            karpuzText.text = karpuzPuan.ToString();
        }
        if (other.gameObject.tag == "visne")
        {
            yemek.Play();
            Destroy(other.gameObject);

            int visnePuan = int.Parse(visneText.text);
            if (visnePuan != 0)
            {
                visnePuan -= 1;
            }
            visneText.text = visnePuan.ToString();
        }
        if (other.gameObject.tag == "muz")
        {
            yemek.Play();
            Destroy(other.gameObject);

            int muzPuan = int.Parse(muzText.text);
            if (muzPuan != 0)
            {
                muzPuan -= 1;
            }
            muzText.text = muzPuan.ToString();
        }
        

    }

    



    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Karakterin pozisyonunu hesaplad�m.
        Vector3 newPosition = transform.position + new Vector3(horizontalInput, 0f, verticalInput) * Time.deltaTime;

        // Yeni pozisyon s�n�rlar i�inde mi kontrol ettim.
        float clampedX = Mathf.Clamp(newPosition.x, minX, maxX);
        float clampedZ = Mathf.Clamp(newPosition.z, minZ, maxZ);

        // Yeni pozisyonu s�n�rlar i�inde ayarlay�n
        transform.position = new Vector3(clampedX, transform.position.y, clampedZ);

        

    }

    void SahneDegistir()
    {
        int hangiSahne = SceneManager.GetActiveScene().buildIndex;
        int hedefSahne = (hangiSahne + 2) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(hedefSahne);
    }
    
}
