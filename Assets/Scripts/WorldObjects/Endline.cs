using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLine : MonoBehaviour
{
    protected GameManager gameManager;
    protected bool isHeightReached = false;
    public ParticleSystem particle;
    private bool isCreated;
    List<float> xFloat;
    List<float> yFloat;
    List<int[]> rgbaColors;
    int j = 0;

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.GetComponent<BuildingElement>())
        {
            gameManager.calculatePoints();
            isHeightReached = true;
        }

    }

    // Use this for initialization
    void Start()
    {
        gameManager = Camera.main.GetComponent<GameManager>();
        xFloat = new List<float>();
        yFloat = new List<float>();
        xFloat.AddRange(new float[] { -3.72351f, -4.12465f, 2.916426f, 3.963233f, -2.51051f, -1.032002f, -0.1561627f, 1.68052f, -5.83621f, 2.56973f, -2.82953f });
        yFloat.AddRange(new float[] { 5.694991f, -0.536151f, 3.168724f, -2.00521f, 3.168724f, 3.701677f, -1.273498f, 2.510653f, 3.359748f, -0.568438f, -1.01085f });

        rgbaColors = new List<int[]>();
        rgbaColors.Add(new int[] { 249, 241, 178 });
        rgbaColors.Add(new int[] { 127, 62, 62 });
        rgbaColors.Add(new int[] { 203, 168, 95 });
        rgbaColors.Add(new int[] { 66, 61, 203 });
        rgbaColors.Add(new int[] { 223, 131, 33 });
        rgbaColors.Add(new int[] { 255, 255, 255 });
        rgbaColors.Add(new int[] { 187, 227, 142 });
        rgbaColors.Add(new int[] { 255, 255, 255 });
        rgbaColors.Add(new int[] { 155, 215, 240 });
        rgbaColors.Add(new int[] { 255, 255, 255 });


    }

    public void celebrate()
    {
        List<ParticleSystem> particles = new List<ParticleSystem>();

        for (int i = 0; i < 10; i++)
        {
            particles.Add(Instantiate(particle, transform));
        }

        foreach (ParticleSystem particle in particles)
        {
            particle.transform.position = new Vector3(xFloat[j], yFloat[j]);
            j++;
            particle.playbackSpeed = 0.6f;
            particle.startDelay = 0.3f * j;
            particle.startColor = getParticleColor(j % 4);
            //particle.startColor = new Color(rgbaColors[j][0], rgbaColors[j][1], rgbaColors[j][2], .5f);
            particle.Play();
            new WaitForSeconds(1);
        }
    }
    // Update is called once per frame
    

    Color getParticleColor(int index)
    {
        Color color = Color.white;
        switch (index)
        {
            case 0:
                color = Color.cyan;
                break;
            case 1:
                color = Color.red;
                break;
            case 2:
                color = Color.magenta;
                break;
            case 3:
                color = Color.yellow;
                break;

        }

        return color;
    }
}
