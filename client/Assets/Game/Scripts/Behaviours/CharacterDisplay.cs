﻿using System.Collections;
using System.Linq;
using UnityEngine;

public class CharacterDisplay : MonoBehaviour
{
    private bool _isLoaded;

    public SpriteRenderer BaseHeadSpriteRenderer;
    public SpriteRenderer BaseTorsoSpriteRenderer;
    public SpriteRenderer BaseLeftArmSpriteRenderer;
    public SpriteRenderer BaseLeftHandSpriteRenderer;
    public SpriteRenderer BaseRightArmSpriteRenderer;
    public SpriteRenderer BaseRightHandSpriteRenderer;
    public SpriteRenderer BaseLegsSpriteRenderer;
    public SpriteRenderer BaseFeetSpriteRenderer;

    public SpriteRenderer HairSpriteRenderer;
    public SpriteRenderer FacialHairSpriteRenderer;
    public SpriteRenderer HeadEquipmentSpriteRenderer;
    public SpriteRenderer NeckEquipmentSpriteRenderer;
    public SpriteRenderer GloveEquipmentSpriteRenderer;
    public SpriteRenderer RightHandEquipmentSpriteRenderer;
    public SpriteRenderer LeftHandEquipmentSpriteRenderer;
    public SpriteRenderer TorsoEquipmentSpriteRenderer;
    public SpriteRenderer LegEquipmentSpriteRenderer;
    public SpriteRenderer FeetEquipmentSpriteRenderer;
    public SpriteRenderer BackEquipmentSpriteRenderer;

    private void Start()
    {
        GenerateRandomCharacter();
    }

    public void GenerateRandomCharacter()
    {
        StartCoroutine(GenerateRandomCharacterCoroutine());
    }

    private Sprite CreateSprite(Texture2D texture)
    {
        var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        sprite.texture.filterMode = FilterMode.Point;
        return sprite;
    }

    private IEnumerator GenerateRandomCharacterCoroutine()
    {
        yield return new WaitUntil(() => AssetManager.Instance?.AssetManifest != null);
        var skinColor = Random.ColorHSV();
        var assetManifest = AssetManager.Instance.AssetManifest;
        yield return AssetManager.Instance.GetTexture(assetManifest.CharacterManifest.HeadTexturePath, texture =>
        {
            BaseHeadSpriteRenderer.sprite = CreateSprite(texture);
            BaseHeadSpriteRenderer.color = skinColor;
        });
        yield return AssetManager.Instance.GetTexture(assetManifest.CharacterManifest.TorsoTexturePath, texture =>
        {
            BaseTorsoSpriteRenderer.sprite = CreateSprite(texture);
            BaseTorsoSpriteRenderer.color = skinColor;
        });
        yield return AssetManager.Instance.GetTexture(assetManifest.CharacterManifest.LeftArmTexturePath, texture =>
        {
            BaseLeftArmSpriteRenderer.sprite = CreateSprite(texture);
            BaseLeftArmSpriteRenderer.color = skinColor;
        });
        yield return AssetManager.Instance.GetTexture(assetManifest.CharacterManifest.LeftHandTexturePath, texture =>
        {
            BaseLeftHandSpriteRenderer.sprite = CreateSprite(texture);
            BaseLeftHandSpriteRenderer.color = skinColor;
        });
        yield return AssetManager.Instance.GetTexture(assetManifest.CharacterManifest.RightArmTexturePath, texture =>
        {
            BaseRightArmSpriteRenderer.sprite = CreateSprite(texture);
            BaseRightArmSpriteRenderer.color = skinColor;
        });
        yield return AssetManager.Instance.GetTexture(assetManifest.CharacterManifest.RightHandTexturePath, texture =>
        {
            BaseRightHandSpriteRenderer.sprite = CreateSprite(texture);
            BaseRightHandSpriteRenderer.color = skinColor;
        });
        yield return AssetManager.Instance.GetTexture(assetManifest.CharacterManifest.LegsTexturePath, texture =>
        {
            BaseLegsSpriteRenderer.sprite = CreateSprite(texture);
            BaseLegsSpriteRenderer.color = skinColor;
        });
        yield return AssetManager.Instance.GetTexture(assetManifest.CharacterManifest.FeetTexturePath, texture =>
        {
            BaseFeetSpriteRenderer.sprite = CreateSprite(texture);
            BaseFeetSpriteRenderer.color = skinColor;
        });

        var hairColor = Random.ColorHSV();
        if (Random.value <= 0.5f && assetManifest.CharacterManifest.HairStyles.Any())
        {
            var hairStyles = assetManifest.CharacterManifest.HairStyles.ToArray();
            var hairStyle = hairStyles[Random.Range(0, hairStyles.Length)];
            yield return AssetManager.Instance.GetTexture(hairStyle.EquippedTexturePath, texture =>
            {
                HairSpriteRenderer.sprite = CreateSprite(texture);
                HairSpriteRenderer.color = hairColor;
            });
        }
        if (Random.value <= 0.5f && assetManifest.CharacterManifest.FacialHairStyles.Any())
        {
            var facialHairStyles = assetManifest.CharacterManifest.FacialHairStyles.ToArray();
            var facialHairStyle = facialHairStyles[Random.Range(0, facialHairStyles.Length)];
            yield return AssetManager.Instance.GetTexture(facialHairStyle.EquippedTexturePath, texture =>
            {
                FacialHairSpriteRenderer.sprite = CreateSprite(texture);
                FacialHairSpriteRenderer.color = hairColor;
            });
        }

        if (Random.value <= 0.5f && assetManifest.ItemManifest.BackItems.Any())
        {
            var items = assetManifest.ItemManifest.BackItems.ToArray();
            var item = items[Random.Range(0, items.Length)];
            yield return AssetManager.Instance.GetTexture(item.EquippedTexturePath, texture => { BackEquipmentSpriteRenderer.sprite = CreateSprite(texture); });
        }
        if (Random.value <= 0.5f && assetManifest.ItemManifest.FeetItems.Any())
        {
            var items = assetManifest.ItemManifest.FeetItems.ToArray();
            var item = items[Random.Range(0, items.Length)];
            yield return AssetManager.Instance.GetTexture(item.EquippedTexturePath, texture => { FeetEquipmentSpriteRenderer.sprite = CreateSprite(texture); });
        }
        if (Random.value <= 0.5f && assetManifest.ItemManifest.LegItems.Any())
        {
            var items = assetManifest.ItemManifest.LegItems.ToArray();
            var item = items[Random.Range(0, items.Length)];
            yield return AssetManager.Instance.GetTexture(item.EquippedTexturePath, texture => { LegEquipmentSpriteRenderer.sprite = CreateSprite(texture); });
        }
        if (Random.value <= 0.5f && assetManifest.ItemManifest.TorsoItems.Any())
        {
            var items = assetManifest.ItemManifest.TorsoItems.ToArray();
            var item = items[Random.Range(0, items.Length)];
            yield return AssetManager.Instance.GetTexture(item.EquippedTexturePath, texture => { TorsoEquipmentSpriteRenderer.sprite = CreateSprite(texture); });
        }
        if (Random.value <= 0.5f && assetManifest.ItemManifest.GloveItems.Any())
        {
            var items = assetManifest.ItemManifest.GloveItems.ToArray();
            var item = items[Random.Range(0, items.Length)];
            yield return AssetManager.Instance.GetTexture(item.EquippedTexturePath, texture => { GloveEquipmentSpriteRenderer.sprite = CreateSprite(texture); });
        }
        if (Random.value <= 0.5f && assetManifest.ItemManifest.LeftHandItems.Any())
        {
            var items = assetManifest.ItemManifest.LeftHandItems.ToArray();
            var item = items[Random.Range(0, items.Length)];
            yield return AssetManager.Instance.GetTexture(item.EquippedTexturePath, texture => { LeftHandEquipmentSpriteRenderer.sprite = CreateSprite(texture); });
        }
        if (Random.value <= 0.5f && assetManifest.ItemManifest.RightHandItems.Any())
        {
            var items = assetManifest.ItemManifest.RightHandItems.ToArray();
            var item = items[Random.Range(0, items.Length)];
            yield return AssetManager.Instance.GetTexture(item.EquippedTexturePath, texture => { RightHandEquipmentSpriteRenderer.sprite = CreateSprite(texture); });
        }
        if (Random.value <= 0.5f && assetManifest.ItemManifest.NeckItems.Any())
        {
            var items = assetManifest.ItemManifest.NeckItems.ToArray();
            var item = items[Random.Range(0, items.Length)];
            yield return AssetManager.Instance.GetTexture(item.EquippedTexturePath, texture => { NeckEquipmentSpriteRenderer.sprite = CreateSprite(texture); });
        }
        if (Random.value <= 0.5f && assetManifest.ItemManifest.HeadItems.Any())
        {
            var items = assetManifest.ItemManifest.HeadItems.ToArray();
            var item = items[Random.Range(0, items.Length)];
            yield return AssetManager.Instance.GetTexture(item.EquippedTexturePath, texture => { HeadEquipmentSpriteRenderer.sprite = CreateSprite(texture); });
        }
    }
}
