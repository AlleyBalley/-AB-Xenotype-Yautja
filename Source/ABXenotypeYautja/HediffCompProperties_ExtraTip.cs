using Verse;

namespace ABXenotypeYautja
{
    public class HediffCompProperties_ExtraTip : HediffCompProperties
    {
        public string SlotName = "";
        public string SlotTitle = "";

        public HediffCompProperties_ExtraTip() => this.compClass = typeof(HediffComp_ExtraTip);
    }
}
