using RimWorld;
using Verse;

namespace ABXenotypeYautja
{
    public class ThoughtWorker_HediffTagged : ThoughtWorker
    {
        private int taggedHediffs = 0;

        protected virtual ThoughtState CurrentStateInternal(Pawn p)
        {
            this.taggedHediffs = 0;
            foreach (Hediff hediff in p.health.hediffSet.hediffs)
            {
                DefExtension_HediffTaggingTool modExtension = ((Def)this.def).GetModExtension<DefExtension_HediffTaggingTool>();
                if (hediff.def.tags != null)
                {
                    foreach (string tag in hediff.def.tags)
                    {
                        if (tag.Equals(modExtension.hediffTagRequired))
                        {
                            ++this.taggedHediffs;
                            break;
                        }
                    }
                }
            }
            ThoughtState thoughtState;
            if (this.taggedHediffs <= 0)
            {
                thoughtState = ThoughtState.Inactive;
            }
            else
            {
                if (this.taggedHediffs > this.def.stages.Count)
                    this.taggedHediffs = this.def.stages.Count;
                thoughtState = ThoughtState.ActiveAtStage(this.taggedHediffs - 1);
            }
            return thoughtState;
        }
    }
}
