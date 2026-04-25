using Verse;

namespace ABXenotypeYautja
{
    public class Comp_ExtraTip_ModuleSlotName : ThingComp
    {
        public CompProperties_ExtraTip_ModuleSlotName Props => (CompProperties_ExtraTip_ModuleSlotName)this.props;

        public override string CompInspectStringExtra() => base.CompInspectStringExtra() + ColoredText.Colorize(this.Props.SlotTitle, ColoredText.TipSectionTitleColor) + this.Props.SlotName;
    }
}
