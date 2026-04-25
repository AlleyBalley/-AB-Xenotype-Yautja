using Verse;

namespace ABXenotypeYautja
{
    public class HediffCompProperties_ExtraTip_ModuleSlotName : HediffCompProperties
    {
        public string SlotName = "";
        public string SlotTitle = "";

        public HediffCompProperties_ExtraTip_ModuleSlotName() => this.compClass = typeof(HediffComp_ExtraTip_ModuleSlotName);
    }
}
