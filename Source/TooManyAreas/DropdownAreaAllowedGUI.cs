using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace TooManyAreas;

public static class DropdownAreaAllowedGUI
{
    private static IEnumerable<Widgets.DropdownMenuElement<Area>> Button_GenerateMenu(Pawn pawn)
    {
        yield return new Widgets.DropdownMenuElement<Area>
        {
            option = new FloatMenuOption(AreaUtility.AreaAllowedLabel_Area(null),
                delegate { pawn.playerSettings.AreaRestrictionInPawnCurrentMap = null; }),
            payload = null
        };
        foreach (var area in Find.CurrentMap.areaManager.AllAreas)
        {
            var a = area;
            if (area != pawn.playerSettings.AreaRestrictionInPawnCurrentMap && area.AssignableAsAllowed())
            {
                yield return new Widgets.DropdownMenuElement<Area>
                {
                    option = new FloatMenuOption(a.Label,
                        delegate { pawn.playerSettings.AreaRestrictionInPawnCurrentMap = a; },
                        MenuOptionPriority.Default, delegate { a.MarkForDraw(); }),
                    payload = a
                };
            }
        }
    }

    public static bool DrawBox(Rect rect, Pawn pawn)
    {
        if (pawn?.playerSettings == null)
        {
            return true;
        }

        var hasRestriction = pawn.playerSettings.AreaRestrictionInPawnCurrentMap != null &&
                             Find.CurrentMap.areaManager.AllAreas.Contains(pawn.playerSettings
                                 .AreaRestrictionInPawnCurrentMap);
        var texture2D = !hasRestriction
            ? BaseContent.GreyTex
            : pawn.playerSettings.AreaRestrictionInPawnCurrentMap.ColorTexture;
        var text = hasRestriction
            ? pawn.playerSettings.AreaRestrictionInPawnCurrentMap.Label
            : AreaUtility.AreaAllowedLabel_Area(null);

        var contractedRect = rect.ContractedBy(2f);
        var rightPart = contractedRect.RightPartPixels(contractedRect.height);

        Widgets.Dropdown(contractedRect, pawn,
            p => hasRestriction ? p.playerSettings.AreaRestrictionInPawnCurrentMap : null,
            Button_GenerateMenu, text, texture2D, text, null, null, true);
        if (Mouse.IsOver(contractedRect))
        {
            GUI.DrawTexture(rect, BaseContent.WhiteTex);
            if (hasRestriction)
            {
                pawn.playerSettings.AreaRestrictionInPawnCurrentMap.MarkForDraw();
            }
        }

        GUI.DrawTexture(contractedRect, texture2D);
        GUI.DrawTexture(rightPart, HarmonyPatches.DropdownIndicator);
        Text.Font = GameFont.Small;
        Text.Anchor = TextAnchor.LowerCenter;
        Text.WordWrap = false;
        Widgets.Label(contractedRect, text);
        Text.WordWrap = true;
        Text.Anchor = TextAnchor.UpperLeft;
        return false;
    }
}