using UnityEngine;
using UnityEngine.UI;

public class UFOHealthBar : MonoBehaviour
{
    public Slider slider;
    public Transform target;
    public Vector3 offset;

    Health health;

    void Start()
    {
        health = target.GetComponent<Health>();
    }

    void Update()
    {
        if (health == null) return;

        slider.value = health.currentHealth / health.maxHealth;

        transform.position = target.position + offset;
        transform.LookAt(Camera.main.transform);
    }
}
