using System;
using Newtonsoft.Json;
using UnityEngine;

[Serializable]
public class ItemData
{
    [JsonProperty] public int ItemId { get; private set; }
    [JsonProperty] public int Count { get; private set; }
    [JsonProperty] public byte[] IconData { get; private set; }

    public ItemData(int id, int count, Sprite icon)
    {
        ItemId = id;
        Count = count;
        IconData = ConvertSpriteToBytes(icon);
    }

    public Sprite GetIcon()
    {
        return ConvertBytesToSprite(IconData);
    }

    public void SubtractCount()
    {
        Count--;
    }

    public void AddCount()
    {
        Count++;
    }

    private byte[] ConvertSpriteToBytes(Sprite sprite)
    {
        if (sprite == null)
        {
            return null;
        }

        Texture2D texture = sprite.texture;
        return texture.EncodeToPNG();
    }

    private Sprite ConvertBytesToSprite(byte[] bytes)
    {
        if (bytes == null)
        {
            return null;
        }

        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(bytes);
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);
        return sprite;
    }
}