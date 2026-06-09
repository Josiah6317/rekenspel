
using UnityEngine;
using TMPro;

public class GunController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI answerText;
    [SerializeField] private TextMeshProUGUI answerText2;

    private int nextTextIndex = 0;


    [SerializeField] private Transform gun;
    [SerializeField] private float gunDistance = 1.5f;

    [Header("Bullet")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;

        gun.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg));

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        gun.position = transform.position + Quaternion.Euler(0, 0, angle) * new Vector3(gunDistance, 0, 0);

        if (Input.GetKeyDown(KeyCode.Mouse0))
            Shoot(direction);
    }

    public void Shoot(Vector3 direction)
    {
        //everytime you make make a bullet you dont control it anymore instantiate
        GameObject newBullet = Instantiate(bulletPrefab, gun.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().linearVelocity = direction.normalized * bulletSpeed;

        Bullet bulletScript = newBullet.GetComponent<Bullet>();

        if (nextTextIndex == 0)
        {
            bulletScript.answerText = answerText;
            nextTextIndex = 1;
        }
        else
        {
            bulletScript.answerText = answerText2;
            nextTextIndex = 0;
        }

        Destroy(newBullet, 5f);

    /*    bulletScript.answerText = answerText;
        bulletScript.answerText2 = answerText2;

        Destroy(newBullet, 5f);*/
    }
}

