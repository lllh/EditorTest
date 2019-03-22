using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class MyEditor_Test8 : AssetPostprocessor {

	public void OnPreprocessTexture()
	{			
		Debug.Log("OnPreprocessTexture");
	}

	[MenuItem("Tool/ResetTextureName")]
	static void ResetTextureName()
	{
		int index = 1;
		Object[] objects = Selection.objects;
		if(objects.Length == 0){
			EditorUtility.DisplayDialog("warnning", "请选中图片资源","确定","关闭");
			return;
		}
		foreach(Object item in objects){
			string tmp_assetPath = AssetDatabase.GetAssetPath(item);
			AssetDatabase.RenameAsset(tmp_assetPath, item.GetInstanceID().ToString());
		}
		foreach(Object item in objects){
			string tmp_assetPath = AssetDatabase.GetAssetPath(item);
			if(tmp_assetPath == "")	continue;

			int frontLength = tmp_assetPath.LastIndexOf("Textures/") + 9;
			int backLength = tmp_assetPath.LastIndexOf("/");
			string frontStr = tmp_assetPath.Substring( frontLength, backLength - frontLength);
			
			AssetDatabase.RenameAsset(tmp_assetPath, string.Format("{0}_{1}{2}", frontStr, index < 10?"0":"", index));
			EditorUtility.DisplayProgressBar("ChangeName :", tmp_assetPath, (float)index / (float)objects.Length);
			index += 1;			
		}
		EditorUtility.ClearProgressBar();
		AssetDatabase.Refresh();
	}

	[MenuItem("Tool/SetTextureProperties")]
	static void SetTextureProperties(){
		
		Object[] objects = Selection.objects;
		if(objects.Length == 0){
			EditorUtility.DisplayDialog("warnning", "请选中图片资源","确定","关闭");
			return;
		}
		int index = 1;
		foreach(Object obj in objects){
			Texture2D item = obj as Texture2D;
			if(item == null) continue;
			string path = AssetDatabase.GetAssetPath(obj);
			TextureImporter importer = TextureImporter.GetAtPath(path) as TextureImporter;
			bool isSprite = item.width < 700 && item.height < 400;
			importer.textureType = isSprite ? TextureImporterType.Sprite : TextureImporterType.Default;
			importer.mipmapEnabled = false;
			importer.alphaIsTransparency = true;
			importer.alphaSource = TextureImporterAlphaSource.FromInput;
			importer.sRGBTexture = true;
			importer.isReadable = false;
			importer.textureCompression = isSprite ? TextureImporterCompression.Uncompressed : TextureImporterCompression.CompressedHQ;
			importer.npotScale = isSprite ? TextureImporterNPOTScale.None : TextureImporterNPOTScale.ToNearest;
			importer.SaveAndReimport();
			EditorUtility.DisplayProgressBar("设置图片格式 :", path, (float)index / (float)objects.Length);
			index += 1;	
			
		}
		EditorUtility.ClearProgressBar();
		AssetDatabase.Refresh();
	}

	public void OnPostprocessTexture(Texture2D tex){
		Debug.Log("import texture" +  "   " + tex.name );
		// EditorUtility.ClearProgressBar();
		// Debug.Log(fullPath);
		// Debug.Log(tex.width);
		
		// bool isSprite = false;
		// isSprite = tex.width < 700 && tex.height < 400;
		// TextureImporter importer = this.assetImporter as TextureImporter;
		// importer.textureType = isSprite ? TextureImporterType.Sprite : TextureImporterType.Default;
		// importer.mipmapEnabled = false;
		// importer.alphaIsTransparency = true;
		// importer.alphaSource = TextureImporterAlphaSource.FromInput;
		// importer.sRGBTexture = true;
		// importer.isReadable = false;
		// importer.textureCompression = isSprite ? TextureImporterCompression.Uncompressed : TextureImporterCompression.CompressedHQ;
		// importer.npotScale = isSprite ? TextureImporterNPOTScale.None : TextureImporterNPOTScale.ToNearest;

		// AssetDatabase.Refresh();
	}

	public static void OnPostprocessAllAssets(string[] importAssets, string[] deletedAssets, string[] moveAssets, string[] movedFromAssetPaths){
		foreach(string str in importAssets){
			Debug.Log("import asset: name:" + str);
		}
		foreach(string str in deletedAssets){
			Debug.Log("delete asset: name:" + str);
		}

		foreach(string str in moveAssets){
			Debug.Log("move asset: name:" + str);
		}
	}
}
