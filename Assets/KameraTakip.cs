using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Takip edilecek karakterin Transform bile�eni
    public float distance = 5.0f; // Kamera ile karakter aras�ndaki mesafe
    public float height = 2.0f; // Kameran�n karakterin �zerindeki y�ksekli�i
    public float rotationDamping = 3.0f; // Kamera d�n���n�n yumu�akl���
    public float heightDamping = 2.0f; // Kamera y�ksekli�i de�i�iminin yumu�akl���

    void LateUpdate()
    {
        if (!target)
            return;

        // Karakterin pozisyonunu al
        float wantedRotationAngle = target.eulerAngles.y;
        float wantedHeight = target.position.y + height;

        // Kameran�n pozisyonunu ve d�n���n� hesapla
        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

        // Kameran�n d�n���n� yumu�at
        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime + 100);

        // Kameran�n y�ksekli�ini yumu�at
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

        // Yeni kamera rotasyonunu ve pozisyonunu olu�tur
        Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);
        Vector3 newPosition = target.position - (currentRotation * Vector3.forward * distance);
        newPosition.y = currentHeight;

        // Kameray� yeni pozisyon ve rotasyona ayarla
        transform.position = newPosition;
        transform.LookAt(target);
    }
}
