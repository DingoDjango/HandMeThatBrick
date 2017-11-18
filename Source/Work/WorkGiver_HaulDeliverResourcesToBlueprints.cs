using System.Collections.Generic;
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

			if (blueprint is Blueprint_Install)
			{
				return base.HasJobOnThing(pawn, t, forced);
			}

			return !blueprint.MaterialsNeeded().NullOrEmpty() && base.HasJobOnThing(pawn, t, forced);
		}

		public override IEnumerable<Thing> PotentialWorkThingsGlobal(Pawn pawn)
		{
			return Utilities.WorkThingsOpportunistic(pawn, this.PotentialWorkThingRequest);
		}
	}
}
