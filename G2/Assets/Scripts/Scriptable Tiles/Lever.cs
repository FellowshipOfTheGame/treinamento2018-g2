using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class Lever : Tile {
    
	#if UNITY_EDITOR
// The following is a helper that adds a menu item to create a RoadTile Asset
    [MenuItem("Assets/Create/Special Tiles/LeverTile")]
    public static void CreateLeverTile()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save Tile", "New Tile", "Asset", "Save Tile", "Assets");
        if (path == "")
            return;
    	AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<Lever>(),path);
    }
#endif
}
