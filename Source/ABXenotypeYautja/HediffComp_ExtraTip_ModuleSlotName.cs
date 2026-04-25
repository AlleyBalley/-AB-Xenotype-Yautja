using Verse;

namespace ABXenotypeYautja
{
    public class HediffComp_ExtraTip_ModuleSlotName : HediffComp
    {
        public HediffCompProperties_ExtraTip_ModuleSlotName Props => (HediffCompProperties_ExtraTip_ModuleSlotName)this.props;

        public override string CompTipStringExtra => base.CompTipStringExtra + ColoredText.Colorize(this.Props.SlotTitle, ColoredText.TipSectionTitleColor) + this.Props.SlotName;
    }
}
