using UnityEditor;
using System.IO;
/// <summary>
/// create a menu item at the bottom of the Assets menu called “Build AssetBundles” that will execute the code in the function associated with that tag.
/// ref: https://docs.unity3d.com/2018.4/Documentation/Manual/AssetBundles-Workflow.html
/// </summary>
public class CreateAssetBundles
{
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        string assetBundleDirectory = "Assets/AssetBundles";
        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
    }
}