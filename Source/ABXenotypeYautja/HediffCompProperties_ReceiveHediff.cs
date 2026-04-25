using System.Collections.Generic;
using Verse;

namespace ABXenotypeYautja
{
    public class HediffCompProperties_ReceiveHediff : HediffCompProperties
    {
        public List<HediffDef> hediffs;

        public HediffCompProperties_ReceiveHediff() => this.compClass = typeof(HediffComp_ReceiveHediff);
    }
}
