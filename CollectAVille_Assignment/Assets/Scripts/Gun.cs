using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gun : MonoBehaviour
{
    private DamageBuff _damageBuff;
    private Transform _cam;
    [SerializeField] private GameObject _gunBarrel;
    [SerializeField] private ParticleSystem _muzzleFlash;
    [SerializeField] private AudioSource _pew;
    private Renderer _gunRenderer;
    private Color _newGunColor;

    [Header("Gun Stats")]
    [SerializeField] private float _range = 50f;
    [SerializeField] private float _damage = 50f;

    [Header("Laser")]
    [SerializeField] private GameObject _laser;
    [SerializeField] private Transform _muzzle;
    [SerializeField] private float _fadeDuration = 0.3f;


    private void Start()
    {
        _cam = Camera.main.transform;
        _damageBuff = new DamageBuff();
        _gunRenderer = _gunBarrel.GetComponent<Renderer>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (!PauseMenu.GameIsPaused)
        {
            RaycastHit hit;
            _muzzleFlash.Play();
            _pew.Play();
            if (Physics.Raycast(_cam.position, _cam.forward, out hit, _range))
            {
                if (hit.collider.GetComponent<Damageable>() != null)
                {
                    hit.collider.GetComponent<Damageable>().TakeDamage(_damage, hit.point, hit.normal);
                }
                CreateLaser(hit.point);
            }
            else
            {
                CreateLaser(_cam.position + _cam.forward * _range);
            }
        }     
                
    }

    void CreateLaser(Vector3 end)
    {
        LineRenderer lr = Instantiate(_laser).GetComponent<LineRenderer>();
        lr.SetPositions(new Vector3[2] { _muzzle.position, end });
        StartCoroutine(FadeLaser(lr));
        Destroy(lr.gameObject, 0.5f);

    }

    IEnumerator FadeLaser(LineRenderer lr)
    {
        float _alpha = 1;
        while (_alpha > 0)
        {
            _alpha -= Time.deltaTime / _fadeDuration;
            lr.startColor = new Color(lr.startColor.r, lr.startColor.g, lr.startColor.b, _alpha);
            lr.endColor = new Color(lr.endColor.r, lr.endColor.g, lr.endColor.b, _alpha);
            yield return null;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DamageBuff"))
        {
            _damage *= _damageBuff.BuffAmount;
            _newGunColor = _damageBuff.ColorChange;
            _gunRenderer.material.color = _newGunColor;

        }


    }

}
