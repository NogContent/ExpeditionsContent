﻿using System;
using Terraria;
using Terraria.ID;
using Expeditions144;

namespace ExpeditionsContent144.Quests.Daily
{
	class MerchTopWatch : ModExpedition
	{
		public override void SetDefaults()
		{
			expedition.name = "Top Watch";
			SetNPCHead(NPCID.Merchant);
			expedition.difficulty = 0;
			expedition.ctgCollect = true;
			expedition.ctgImportant = true;
		}
		public override void AddItemsOnLoad()
		{
			AddDeliverableAnyOf(new int[] { ItemID.GoldWatch, ItemID.PlatinumWatch }, 1);
			AddRewardItem(API.ItemIDExpeditionCoupon, 1);
		}
		public override string Description(bool complete)
		{
			string clerk = NPC.GetFirstNPCNameOrNull(ExpeditionC144.NPCIDClerk);
			if (clerk == "") clerk = "the clerk";
			return "Hey, you know what sells really well right now? High quality watches. Overseas that is, I'm not paying you any extra to get it for me. But I'll put in a word with " + clerk + ", how's that? Now get me one.";
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
