using RimWorld;
using Verse;

namespace HMTB
{
	public class WorkGiver_HaulDeliverResourcesToBlueprints : WorkGiver_ConstructDeliverResourcesToBlueprints
	{
		public override bool ShouldSkip(Pawn pawn)
		{
			return !Controller.EnableMod;
		}

		public override bool HasJobOnThing(Pawn pawn, Thing t, bool forced = false)
		{
			Blueprint blueprint = t as Blueprint;

			if (blueprint == null)
			{
				return false;
			}

			bool materialsAllowed = blueprint is Blueprint_Install ? true : !blueprint.MaterialsNeeded().NullOrEmpty();

			return materialsAllowed && Utilities.AllowedHaulDistance(pawn, blueprint) && base.HasJobOnThing(pawn, t, forced);
		}
	}
}
