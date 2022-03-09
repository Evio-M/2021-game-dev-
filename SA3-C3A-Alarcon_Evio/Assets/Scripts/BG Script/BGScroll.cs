using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    public float scrollSpeed = 0.1f;
    private MeshRenderer mRenderer;
    private float yScroll;

    private AudioSource bgSound;

    void Awake()
	{
        bgSound = GetComponent<AudioSource>();
    }


    void Start()
    {
        mRenderer = GetComponent<MeshRenderer>();
        bgSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
    }

    void Scroll()
    {
        yScroll = Time.time * scrollSpeed;
        Vector2 offset = new Vector2(0f, yScroll);
        mRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
