using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightControl : MonoBehaviour
{
    // Start is called before the first frame update
    public bool drainOverTime;
    public float maxBrightness;
    public float minBrightness;
    public float drainRate;
    public float batteryRefill;
    [SerializeField] private Light flashlight;

    public static FlashlightControl instance;

    public float maxDamage;
    public float minDamage;
    public float maxRange;
    public float minRange;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        flashlight.intensity = Mathf.Clamp(flashlight.intensity, minBrightness, maxBrightness);
        if (drainOverTime && flashlight.enabled)
        {
            if (flashlight.intensity > minBrightness)
            {
                flashlight.intensity -= Time.deltaTime * drainRate;
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            AudioController.instance.Play("Flashlight");
            flashlight.enabled = !flashlight.enabled;
        }

        if (flashlight.enabled)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, maxRange))
            {
               
                if (hit.collider.CompareTag("enemy"))
                {
                    float damageMultiplier = Mathf.Lerp(maxDamage, minDamage, (hit.distance - minRange) / (maxRange - minRange));
                    Enemy enemy = hit.collider.GetComponent<Enemy>();
                    if (enemy != null)
                    {
                        int damage = (int)Mathf.Ceil(flashlight.intensity * damageMultiplier * Time.deltaTime);
                        enemy.Damage(damage);
                        enemy.updateHealth();
                    }
                }
            }
        }

        GameUIUpdater.instance.updateBatteryText(maxBrightness, flashlight.intensity);
    }

    public void refillBattery()
    {
        flashlight.intensity += batteryRefill;
    }

    public void resetBattery()
    {
        flashlight.intensity = maxBrightness;
    }
}
