using System;
using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;

namespace TooManyAreas;

[HarmonyPatch(typeof(AreaAllowedGUI), nameof(AreaAllowedGUI.DoAllowedAreaSelectors))]
internal static class AreaAllowedGUI_DoAllowedAreaSelectors
{
    private static bool Prefix(Rect rect, Pawn p)
    {
        if (Find.CurrentMap == null || p.playerSettings == null)
        {
            return true;
        }

        var allAreas = Find.CurrentMap.areaManager.AllAreas;
        return allAreas.Count(area => area.AssignableAsAllowed()) + 1 < TMAMod.Instance.Settings.transitionValue ||
               DropdownAreaAllowedGUI.DrawBox(rect, p);
    }

    private static Exception Finalizer(Exception __exception)
    {
        return __exception is NullReferenceException ? null : __exception;
    }
}