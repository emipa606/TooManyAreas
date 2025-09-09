using System.Reflection;
using HarmonyLib;
using UnityEngine;
using Verse;

namespace TooManyAreas;

[StaticConstructorOnStartup]
internal static class HarmonyPatches
{
    public static readonly Texture2D DropdownIndicator =
        ContentFinder<Texture2D>.Get("UI/Misc/BarInstantMarkerRotated");

    public static readonly MethodInfo TdEnhancementPackAssignableAsAllowedForPawnMethodInfo;
    public static readonly bool TdEnhancementPackLoaded;

    static HarmonyPatches()
    {
        new Harmony("TooManyAreas").PatchAll(Assembly.GetExecutingAssembly());
        TdEnhancementPackLoaded = ModLister.GetActiveModWithIdentifier("MemeGoddess.TDPack", true) != null;
        if (!TdEnhancementPackLoaded)
        {
            return;
        }

        TdEnhancementPackAssignableAsAllowedForPawnMethodInfo =
            AccessTools.Method("TD_Enhancement_Pack.DoAllowedAreaSelectors_Patch:AssignableAsAllowedForPawn");
        if (TdEnhancementPackAssignableAsAllowedForPawnMethodInfo != null)
        {
            return;
        }

        TdEnhancementPackLoaded = false;
        Log.Message(
            "[TooManyAreas]: Failed to find Area-limiter in TD Enhancement Pack, will not be able to check for hidden areas");
    }
}