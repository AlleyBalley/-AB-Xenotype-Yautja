using Verse;

namespace ABXenotypeYautja
{
    public class HediffComp_ExtraTip : HediffComp
    {
        public HediffCompProperties_ExtraTip Props => (HediffCompProperties_ExtraTip)this.props;

        public override string CompTipStringExtra => base.CompTipStringExtra + ColoredText.Colorize(this.Props.SlotTitle, ColoredText.TipSectionTitleColor) + this.Props.SlotName;
    }
}