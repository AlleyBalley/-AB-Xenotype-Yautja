using Verse;

namespace ABXenotypeYautja
{
    public class CompProperties_ExtraTip_ModuleSlotName : CompProperties
    {
        public string SlotName = "";
        public string SlotTitle = "";

        public CompProperties_ExtraTip_ModuleSlotName() => this.compClass = typeof(Comp_ExtraTip_ModuleSlotName);
    }
}
