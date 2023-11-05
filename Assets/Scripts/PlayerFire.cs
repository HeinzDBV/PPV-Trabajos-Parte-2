using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public Gun PrimaryGun;
    public Gun SecondaryGun;
    public Gun Gun;
    public int gunIndex;
    public GameObject PrimaryGunGO;
    public GameObject SecondaryGunGO;

    private void Start() 
    {
        if (PrimaryGunGO != null)
        {
            PrimaryGun = PrimaryGunGO.GetComponent<Gun>();
        }
        if (SecondaryGunGO != null)
        {
            SecondaryGun = SecondaryGunGO.GetComponent<Gun>();
        }

        Gun = PrimaryGun;
        PrimaryGunGO.SetActive(true);
        SecondaryGunGO.SetActive(false);
        gunIndex = 0;
    }

    private void Update() 
    {
        Debug.DrawRay(
            transform.position, 
            transform.forward * 10f, 
            Color.red
        );
    }

    public void Fire()
    {
        if (Gun != null)
        {
            Gun.Shoot();
        }
    }

    public void Reload()
    {
        if (Gun != null)
        {
            Gun.Reload();
        }
    }

    public void SwitchGun()
    {
        if (Gun == PrimaryGun)
        {
            SwitchToSecondaryGun();
        }
        else if (Gun == SecondaryGun)
        {
            SwitchToPrimaryGun();
        }
    }

    public void SwitchToPrimaryGun()
    {
        Gun = PrimaryGun;
        gunIndex = 0;
        PrimaryGunGO.SetActive(true);
        SecondaryGunGO.SetActive(false);
    }

    public void SwitchToSecondaryGun()
    {
        Gun = SecondaryGun;
        gunIndex = 1;
        PrimaryGunGO.SetActive(false);
        SecondaryGunGO.SetActive(true);
    }

    public void EquipGun(GameObject gunPrefab)
    {

        if (PrimaryGun == null)
        {
            EquipPrimaryGun(gunPrefab);
        }
        else if (SecondaryGun == null)
        {
            EquipSecondaryGun(gunPrefab);
        }
        else
        {
            //DropGun
            DropGun();
            
            //EquipGun
            if (gunIndex == 0)
            {
                EquipPrimaryGun(gunPrefab);
            }
            else
            {
                EquipSecondaryGun(gunPrefab);
            }
        }
    }

    public void EquipPrimaryGun(GameObject gunPrefab)
    {
        GameObject gunObject = Instantiate(gunPrefab, transform.position, transform.rotation, PrimaryGunGO.transform);
        Gun gun = gunObject.GetComponentInChildren<Gun>();

        PrimaryGun = gun;
        SwitchToPrimaryGun();
    }

    public void EquipSecondaryGun(GameObject gunPrefab)
    {
        GameObject gunObject = Instantiate(gunPrefab, transform.position, transform.rotation, SecondaryGunGO.transform);
        Gun gun = gunObject.GetComponentInChildren<Gun>();

        SecondaryGun = gun;
        SwitchToSecondaryGun();
    }

    public void DropGun()
    {
        if (Gun != null)
        {
            Instantiate(Gun.ItemPrefab, transform.position, transform.rotation);
            if (gunIndex == 0)
            {
                PrimaryGun = null;
                Destroy(PrimaryGunGO.transform.GetChild(0).gameObject);
            }
            else
            {
                SecondaryGun = null;
                Destroy(SecondaryGunGO.transform.GetChild(0).gameObject);
            }
            Gun = null;
        }
    }
}
