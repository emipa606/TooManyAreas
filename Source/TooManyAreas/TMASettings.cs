using Verse;

namespace TooManyAreas;

public class TMASettings : ModSettings
{
    public int transitionValue = 10;

    public override void ExposeData()
    {
        Scribe_Values.Look(ref transitionValue, "transitionValue");
        base.ExposeData();
    }
}