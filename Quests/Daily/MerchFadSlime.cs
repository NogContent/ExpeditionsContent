﻿using System;
using Terraria;
using Terraria.ID;
using Expeditions144;

namespace ExpeditionsContent144.Quests.Daily
{
	class MerchFadSlime : ModExpedition
	{
		public override void SetDefaults()
		{
			expedition.name = "Slime Investment";
			SetNPCHead(NPCID.Merchant);
			expedition.difficulty = 2;
			expedition.ctgCollect = true;
			expedition.ctgImportant = true;
		}
		public override void AddItemsOnLoad()
		{
			AddDeliverable(ItemID.SlimeChair, 1);
			AddDeliverable(ItemID.SlimeTable, 1);
			AddDeliverableAnyOf(new int[] {
				ItemID.SlimeSofa,
				ItemID.SlimeSink,
				ItemID.SlimeChandelier}, 1);
			AddRewardItem(API.ItemIDExpeditionCoupon, 1);
		}
		public override string Description(bool complete)
		{
			string clerk = NPC.GetFirstNPCNameOrNull(ExpeditionC144.NPCIDClerk);
			if (clerk == "") clerk = "the clerk";
			return "There's an fad going on for slime! If you can aquire a selection of furniture for me, I could make a big profit! Oh, and " + clerk + " will give you something for your troubles, I'm sure. ";
		}

		public override bool IncludeAsDaily()
		{
			return NPC.FindFirstNPC(NPCID.Merchant) >= 0;
		}

		public override bool CheckPrerequisites(Player player, ref bool cond1, ref bool cond2, ref bool cond3, bool condCount)
		{
			return API.IsDaily(expedition);
		}
	}
}
