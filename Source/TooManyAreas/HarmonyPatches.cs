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

    static HarmonyPatches()
    {
        new Harmony("TooManyAreas").PatchAll(Assembly.GetExecutingAssembly());
    }
}