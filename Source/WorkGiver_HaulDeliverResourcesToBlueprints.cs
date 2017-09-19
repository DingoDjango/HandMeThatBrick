using RimWorld;
using Verse;

namespace HMTB
{
	public class WorkGiver_HaulDeliverResourcesToBlueprints : WorkGiver_ConstructDeliverResourcesToBlueprints
	{
		public override bool ShouldSkip(Pawn pawn)
		{
			return !Settings.EnableHMTB;
		}

		public override bool HasJobOnThing(Pawn pawn, Thing t, bool forced = false)
		{
			Blueprint blueprint = t as Blueprint;

			if (blueprint is Blueprint_Install)
			{
				return base.HasJobOnThing(pawn, t, forced);
			}

			return !blueprint.MaterialsNeeded().NullOrEmpty() && base.HasJobOnThing(pawn, t, forced);
		}
	}
}
