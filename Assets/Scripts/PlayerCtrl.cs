using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    private Animator _animator;
    private int _distanceOfRaycast = 10;
    private RaycastHit _hit;
    private AudioSource _audioSource;
    private int _totalLoot = 0;

    [SerializeField]
    public AudioClip ChestOpenSound;
    [SerializeField]
    public Text FoundChestText;
    [SerializeField]
    public int TotalChest;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        FoundChestText.text = $"Hazine {_totalLoot}/{TotalChest}";
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        InteractingObjectWithRayCast();
    }

    private void InteractingObjectWithRayCast()
    {
        var ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(ray, out _hit, _distanceOfRaycast))
        {
            if (Input.GetButtonDown("Fire1") && _hit.transform.CompareTag("TreasureChest"))
            {
                var lootBox = _hit.transform.gameObject.GetComponent<LootBox>();
                if (!lootBox.isOpen)
                {
                    _totalLoot++;
                    _audioSource.PlayOneShot(ChestOpenSound);
                    lootBox.Open();
                }
                else
                {
                    _totalLoot--;
                    _audioSource.PlayOneShot(ChestOpenSound);
                    lootBox.Close();
                }

                FoundChestText.text = $"Hazine: {_totalLoot}/{TotalChest}";
            }
        }
    }

    private void PlayerMovement()
    {
        _animator.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));
        _animator.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));
        _animator.SetBool("IsRunning", Input.GetKey("left shift"));
        _animator.SetBool("IsJumping", Input.GetKey("space"));
        _animator.SetBool("IsCrouching", Input.GetKey("left ctrl"));
    }

}
