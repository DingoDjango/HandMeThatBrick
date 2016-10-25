using HugsLib;
using RimWorld;

[DefOf]
public static class HMTBDefs
{
	public static WorkGiverDef HaulDeliverResourcesToFrames;
	public static WorkGiverDef HaulDeliverResourcesToBlueprints;
}

public class HandMeThatBrick : ModBase
{
	public override string ModIdentifier
	{
		get
		{
			return "HandMeThatBrick";
		}
	}

	public override void DefsLoaded()
	{
		UpdateDefs();
	}

	public override void SettingsChanged()
	{
		UpdateDefs();
	}

	private void UpdateDefs()
	{
		var toggle = Settings.GetHandle<bool>("HaulersHelpConstruct", "Use haulers for construction", "Any colonist set to hauling will also deliver materials to construction jobs.", true);
		HMTBDefs.HaulDeliverResourcesToFrames.scanThings = toggle.Value;
		HMTBDefs.HaulDeliverResourcesToBlueprints.scanThings = toggle.Value;
	}
}