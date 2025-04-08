using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CardsController : MonoBehaviour
{
    [SerializeField] Card cardPrefab;
    [SerializeField] Transform gridTransform;
    [SerializeField] Sprite[] sprites;

    public Animator winAnim;
    public Animator gameAnim;

    private List<Sprite> spritePairs;

    Card firstSelected;
    Card secondSelected;

    private PlayerComponent pc;

    int matchCounts;

    private void Start()
    {
        PrepareSprites();
        CreateCards();
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerComponent>(); ;
    }

    private void PrepareSprites()
    {
        spritePairs = new List<Sprite>();

        for (int i = 0; i < sprites.Length; i++)
        {

            // ������ ���� �� ���� ����

            spritePairs.Add(sprites[i]);
            spritePairs.Add(sprites[i]);
        }

        ShuffleSprites(spritePairs);
    }
    void CreateCards()
    {
        for (int i = 0; i < spritePairs.Count; i++)
        {
            Card card = Instantiate(cardPrefab, gridTransform);
            card.SetIconSprite(spritePairs[i]);
            card.controller = this;
        }
    }

    public void SetSelected(Card card)
    {
        if (card.isSelected == false)
        {
            card.Show();

            if (firstSelected == null) 
            {
                firstSelected = card;
                return;
            }

            if (secondSelected == null)
            {
                secondSelected = card;
                StartCoroutine(CheckMatching(firstSelected, secondSelected));
                firstSelected = null;
                secondSelected = null;
            }
        }
    }

    IEnumerator CheckMatching(Card a, Card b)
    {
        yield return new WaitForSeconds(0.3f);
        if (a.iconSprite == b.iconSprite)
        {
            // ������ � ���������� �������� ���
            matchCounts++;
            if(matchCounts >= spritePairs.Count/2)
            {
                // ���� ��������
                PrimeTween.Sequence.Create()
                    .Chain(PrimeTween.Tween.Scale(gridTransform, Vector3.one * 1.2f, 0.2f, ease: PrimeTween.Ease.OutBack))
                    .Chain(PrimeTween.Tween.Scale(gridTransform, Vector3.one, 0.1f));
                gameAnim.SetBool("gameOpen", false);

                pc.colTickects += 5;
                spritePairs.Clear();
                ResetGame();
            }
        }
        else
        {
            // ���� ������� ������ �� ������
            a.Hide();
            b.Hide();
        }
    }

    void ShuffleSprites(List<Sprite> spriteList)
    {
        for (int i = spriteList.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);

            // ������ ����� ���������� � ������� ������ �������

            Sprite temp = spriteList[i];
            spriteList[i] = spriteList[randomIndex];
            spriteList[randomIndex] = temp;
        }
    }

    public void ResetGame()
    {
        // ������� ��� ������������ �����
        foreach (Transform child in gridTransform)
        {
            Destroy(child.gameObject);
        }

        // ���������� ���������� ���������
        firstSelected = null;
        secondSelected = null;
        matchCounts = 0;

        // ���������� �����
        PrepareSprites();
        CreateCards();
    }
}