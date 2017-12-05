﻿using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;
using UnityEngine.UI;

public class LoadImageScript : MonoBehaviour {

	 Image image;

	void Awake () {
		image = GetComponent<Image>();
	}

	public void LoadCharacterImage(Character character) {
		string fileName = "You";
		if(character != null)
			fileName = character.imageName;
		LoadImage("Icons/CharacterIcons/" + fileName);
	}

	public void LoadImage(string filePath) {
		Texture2D imageTexture = Resources.Load(filePath) as Texture2D;
		Rect imageRect = new Rect(0, 0, imageTexture.width, imageTexture.height);
		image.sprite = Sprite.Create(imageTexture, imageRect, new Vector2(0.5f, 0.5f));
		image.preserveAspect = true;
	}

	public Sprite LoadNewSprite(string FilePath, float PixelsPerUnit = 100.0f) {

		// Load a PNG or JPG image from disk to a Texture2D, assign this texture to a new sprite and return its reference

		Sprite NewSprite = new Sprite();
		Texture2D SpriteTexture = LoadTexture(FilePath);
		NewSprite = Sprite.Create(SpriteTexture, new Rect(0, 0, SpriteTexture.width, SpriteTexture.height),new Vector2(0,0), PixelsPerUnit);

		return NewSprite;
	}

	public Texture2D LoadTexture(string FilePath) {

		// Load a PNG or JPG file from disk to a Texture2D
		// Returns null if load fails

		Texture2D Tex2D;
		byte[] FileData;

		if (File.Exists(FilePath)){
			FileData = File.ReadAllBytes(FilePath);
			Tex2D = new Texture2D(2, 2);           // Create new "empty" texture
			if (Tex2D.LoadImage(FileData))           // Load the imagedata into the texture (size is set automatically)
				return Tex2D;                 // If data = readable -> return texture
		}  
		return null;                     // Return null if load failed
	}

}
