﻿using System;
using Terraria;
using Terraria.ID;
using Expeditions144;

namespace ExpeditionsContent144.Quests.Daily
{
	class MerchCrystals : ModExpedition
	{
		public override void SetDefaults()
		{
			expedition.name = "Crystal Cash";
			SetNPCHead(NPCID.Merchant);
			expedition.difficulty = 0;
			expedition.ctgCollect = true;
			expedition.ctgImportant = true;
		}
		public override void AddItemsOnLoad()
		{
			AddDeliverable(ItemID.CrystalShard, 15);
			AddRewardItem(API.ItemIDExpeditionCoupon, 1);
		}
		public override string Description(bool complete)
		{
			string clerk = NPC.GetFirstNPCNameOrNull(ExpeditionC144.NPCIDClerk);
			if (clerk == "") clerk = "the clerk";
			return "Hey, you know what sells amazingly well right now? Crystak shards. Overseas that is, I'm not paying you any extra to get it for me. But I'll put in a word with " + clerk + ", how's that? Now get me some crystals.";
		}

		public override bool IncludeAsDaily()
		{
			return NPC.FindFirstNPC(NPCID.Merchant) >= 0 && Main.hardMode;
		}

		public override bool CheckPrerequisites(Player player, ref bool cond1, ref bool cond2, ref bool cond3, bool condCount)
		{
			return API.IsDaily(expedition);
		}
	}
}
