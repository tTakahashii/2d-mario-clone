using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCollectibles : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI orangeText, cherryText;

    [SerializeField] private AudioSource playerSouce;
    [SerializeField] private AudioClip[] collectClips;

    private int orangeScore = 0, cherryScore = 0;
    private Dictionary<string, int> collectibles;
    private Dictionary<string, TextMeshProUGUI> collectibleTexts;

    private void Awake()
    {
        collectibles = new Dictionary<string, int> 
        { 
            ["Orange"] = orangeScore, 
            ["Cherry"] = cherryScore
        };

        collectibleTexts = new Dictionary<string, TextMeshProUGUI>
        {
            ["Orange"] = orangeText,
            ["Cherry"] = cherryText
        };
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collectibles.ContainsKey((collision.tag)))
        {
            collectibles[collision.tag]++;
            collectibleTexts[collision.tag].text = $"{collision.tag}: {collectibles[collision.tag]}";
            playerSouce.PlayOneShot(collectClips[Random.Range(0, collectClips.Length)]);
            Destroy(collision.gameObject);
        }
    }
}
