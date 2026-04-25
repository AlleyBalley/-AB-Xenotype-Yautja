using Verse;

namespace ABXenotypeYautja
{
    public class HediffComp_ReceiveHediff : HediffComp
    {
        private HediffCompProperties_ReceiveHediff Props => (HediffCompProperties_ReceiveHediff)this.props;

        public virtual void CompPostPostAdd(DamageInfo? dinfo)
        {
            if (this.Props.hediffs == null)
                return;
            for (int index1 = 0; index1 < this.Props.hediffs.Count; ++index1)
            {
                if (((Hediff)this.parent).pawn.health.hediffSet.GetFirstHediffOfDef(this.Props.hediffs[index1], false) == null)
                {
                    ((Hediff)this.parent).pawn.health.AddHediff(this.Props.hediffs[index1], (BodyPartRecord)null, new DamageInfo?(), (DamageWorker.DamageResult)null);
                }
                else
                {
                    for (int index2 = 0; index2 < ((Hediff)this.parent).pawn.health.hediffSet.hediffs.Count; ++index2)
                    {
                        if (((Hediff)this.parent).pawn.health.hediffSet.hediffs[index2].def == this.Props.hediffs[index1])
                        {
                            ((Hediff)this.parent).pawn.health.RemoveHediff(((Hediff)this.parent).pawn.health.hediffSet.hediffs[index2]);
                            ((Hediff)this.parent).pawn.health.AddHediff(this.Props.hediffs[index1], (BodyPartRecord)null, new DamageInfo?(), (DamageWorker.DamageResult)null);
                        }
                    }
                }
            }
        }
    }
}
