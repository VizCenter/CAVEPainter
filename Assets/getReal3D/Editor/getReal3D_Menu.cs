using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class getReal3D_Menu {

    [UnityEditor.Callbacks.PostProcessScene(100)]
    static public void FixPlayerSettings()
    {
        Debug.Log("Adjusting PlayerSettings for build ...");
        PlayerSettings.captureSingleScreen = false;
        PlayerSettings.defaultIsFullScreen = false;
        PlayerSettings.defaultIsNativeResolution = false;
        PlayerSettings.displayResolutionDialog = ResolutionDialogSetting.HiddenByDefault;
        PlayerSettings.forceSingleInstance = false;
        PlayerSettings.resizableWindow = false;
        PlayerSettings.runInBackground = true;
        PlayerSettings.usePlayerLog = true;
    }

    [UnityEditor.Callbacks.PostProcessScene(101)]
    [MenuItem("getReal3D/Advanced/getReal3D Script Execution Order", false, 105)]
    static public void FixExecutionOrder()
    {
        Debug.Log("Fixing script execution order ...");
        getReal3D.Editor.Utils.FixScriptExecutionOrder();
    }

    public static void BuildPlayerImpl(string[] levels, string output, bool arch64 = false)
    {
        BuildTarget currentTarget = EditorUserBuildSettings.activeBuildTarget;
        EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTarget.StandaloneWindows);

        BuildTarget buildTarget = arch64 ? BuildTarget.StandaloneWindows64 : BuildTarget.StandaloneWindows;
        AddGraphicApi(buildTarget, UnityEngine.Rendering.GraphicsDeviceType.Direct3D11);
        AddGraphicApi(buildTarget, UnityEngine.Rendering.GraphicsDeviceType.Direct3D9);

        UnityEditor.BuildOptions options = BuildOptions.None;
        BuildPipeline.BuildPlayer(levels, output, buildTarget, options);
        EditorUserBuildSettings.SwitchActiveBuildTarget(currentTarget);
    }

    public static void BuildPlayerImpl(string output, bool arch64 = false)
    {
        BuildPlayerImpl(getEnabledScenes(), output, arch64);
    }

    public static string[] getEnabledScenes()
    {
        List<string> temp = new List<string>();
        foreach(UnityEditor.EditorBuildSettingsScene S in UnityEditor.EditorBuildSettings.scenes) {
            if(S.enabled) {
                temp.Add(S.path);
            }
        }
        return temp.ToArray();
    }

    private static void AddGraphicApi(BuildTarget target, UnityEngine.Rendering.GraphicsDeviceType type)
    {
        List<UnityEngine.Rendering.GraphicsDeviceType> deviceTypes = PlayerSettings.GetGraphicsAPIs(BuildTarget.StandaloneWindows).ToList<UnityEngine.Rendering.GraphicsDeviceType>();
        if(!deviceTypes.Contains(type)) {
            deviceTypes.Add(type);
            PlayerSettings.SetGraphicsAPIs(target, deviceTypes.ToArray());
        }
    }
}
