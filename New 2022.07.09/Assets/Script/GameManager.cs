using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShootingGame;

public class GameManager : MonoBehaviour
{
    private static float scrollSpeed;
    public static float ScrollSpeed
    {
        get
        {
            return scrollSpeed;
        }
        set
        {
            scrollSpeed = value;
        }
    }

    private static Bullet bulletPrefab;
    public static Bullet BulletPrefab
    {
        get
        {
            return bulletPrefab;
        }
    }

    private void Awake()
    {
        bulletPrefab = Resources.Load<Bullet>(@"Prefab/Bullet");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
