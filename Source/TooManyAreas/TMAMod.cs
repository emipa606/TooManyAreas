using Mlie;
using UnityEngine;
using Verse;

namespace TooManyAreas;

public class TMAMod : Mod
{
    public static TMAMod Instance;
    private static string currentVersion;
    public readonly TMASettings Settings;

    public TMAMod(ModContentPack content) : base(content)
    {
        Instance = this;
        Settings = GetSettings<TMASettings>();
        currentVersion = VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        base.DoSettingsWindowContents(inRect);
        var listing_Standard = new Listing_Standard();
        listing_Standard.Begin(inRect);
        listing_Standard.ColumnWidth = inRect.width / 2;
        listing_Standard.Label("TMA.MinimalAreas".Translate(Settings.transitionValue));
        listing_Standard.NewColumn();
        listing_Standard.IntAdjuster(ref Settings.transitionValue, 1, 2);
        if (currentVersion != null)
        {
            listing_Standard.Gap();
            GUI.contentColor = Color.gray;
            listing_Standard.Label("TMA.CurrentModVersion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listing_Standard.End();
    }

    public override string SettingsCategory()
    {
        return "TMA: Too Many Areas";
    }
}