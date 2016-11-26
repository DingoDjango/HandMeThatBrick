using RimWorld;
using Verse;

namespace HandMeThatBrick
{
	public class WorkGiver_HaulDeliverResourcesToBlueprints : WorkGiver_ConstructDeliverResourcesToBlueprints
	{
		public override bool HasJobOnThing(Pawn pawn, Thing t)
		{
            Blueprint blueprint = t as Blueprint;
            return base.HasJobOnThing(pawn, t) && !blueprint.MaterialsNeeded().NullOrEmpty();
        }
	}
}