﻿using System;
using Terraria;
using Terraria.ID;
using Expeditions144;

namespace ExpeditionsContent144.Quests.Daily
{
	class MerchFadSpookyWood : ModExpedition
	{
		public override void SetDefaults()
		{
			expedition.name = "Vogue Spooky";
			SetNPCHead(NPCID.Merchant);
			expedition.difficulty = 4;
			expedition.ctgCollect = true;
			expedition.ctgImportant = true;
		}
		public override void AddItemsOnLoad()
		{
			AddDeliverable(ItemID.SpookyChair, 1);
			AddDeliverable(ItemID.SpookyTable, 1);
			AddDeliverableAnyOf(new int[] {
				ItemID.SpookySofa,
				ItemID.SpookySink,
				ItemID.SpookyChandelier}, 1);
			AddRewardItem(API.ItemIDExpeditionCoupon, 1);
		}
		public override string Description(bool complete)
		{
			string clerk = NPC.GetFirstNPCNameOrNull(ExpeditionC144.NPCIDClerk);
			if (clerk == "") clerk = "the clerk";
			return "There's an fad going on for spooky wood! If you can aquire a selection of furniture for me, I could make a big profit! Oh, and " + clerk + " will give you something for your troubles, I'm sure. ";
		}

		public override bool IncludeAsDaily()
		{
			return NPC.FindFirstNPC(NPCID.Merchant) >= 0 && Main.hardMode && NPC.downedHalloweenTree;
		}

		public override bool CheckPrerequisites(Player player, ref bool cond1, ref bool cond2, ref bool cond3, bool condCount)
		{
			return API.IsDaily(expedition);
		}
	}
}
