using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Takip edilecek karakterin Transform bileþeni
    public float distance = 5.0f; // Kamera ile karakter arasýndaki mesafe
    public float height = 2.0f; // Kameranýn karakterin üzerindeki yüksekliði
    public float rotationDamping = 3.0f; // Kamera dönüþünün yumuþaklýðý
    public float heightDamping = 2.0f; // Kamera yüksekliði deðiþiminin yumuþaklýðý

    void LateUpdate()
    {
        if (!target)
            return;

        // Karakterin pozisyonunu al
        float wantedRotationAngle = target.eulerAngles.y;
        float wantedHeight = target.position.y + height;

        // Kameranýn pozisyonunu ve dönüþünü hesapla
        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

        // Kameranýn dönüþünü yumuþat
        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime + 100);

        // Kameranýn yüksekliðini yumuþat
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

        // Yeni kamera rotasyonunu ve pozisyonunu oluþtur
        Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);
        Vector3 newPosition = target.position - (currentRotation * Vector3.forward * distance);
        newPosition.y = currentHeight;

        // Kamerayý yeni pozisyon ve rotasyona ayarla
        transform.position = newPosition;
        transform.LookAt(target);
    }
}
