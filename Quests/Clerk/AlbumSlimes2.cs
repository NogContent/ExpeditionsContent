﻿using System;
using Terraria;
using Terraria.ID;
using Expeditions144;
using System.Collections.Generic;
using Terraria.ModLoader;

namespace ExpeditionsContent144.Quests.Clerk
{
	class AlbumSlimes2 : ModExpedition
	{
		public override void SetDefaults()
		{
			expedition.name = "Snap! Dark and Slimy";
			SetNPCHead(ExpeditionC144.NPCIDClerk);
			expedition.difficulty = 2;
			expedition.ctgCollect = true;
			expedition.ctgExplore = true;
			expedition.repeatable = true;

			expedition.conditionDescription1 = "King Slime, Mother Slime";
			expedition.conditionDescription2 = "Dungeon Slime";
			expedition.conditionDescription3 = "Lava Slime";
			expedition.conditionCountedMax = 4;
			expedition.conditionDescriptionCountable = "Take photos of listed creatures";
		}
		public override void AddItemsOnLoad()
		{
			AddRewardItem(API.ItemIDExpeditionCoupon, 1, true);
			AddRewardItem(ModContent.ItemType<Items.Albums.AlbumSlimes2>());
		}
		public override string Description(bool complete)
		{
			return "There are plenty of diverse and interesting slimes out there, inhabiting all kinds of different places, and adapting to all kinds of environments! See if you can snap some good examples of these kinds of slimes. ";
		}
		#region Photo Bools
		public static bool King
		{ get { return PhotoManager.PhotoOfNPC[NPCID.KingSlime]; } }
		public static bool Mother
		{ get { return PhotoManager.PhotoOfNPC[NPCID.MotherSlime]; } }
		public static bool Dungeon
		{ get { return PhotoManager.PhotoOfNPC[NPCID.DungeonSlime]; } }
		public static bool Lava
		{ get { return PhotoManager.PhotoOfNPC[NPCID.LavaSlime]; } }
		#endregion

		public override bool CheckPrerequisites(Player player, ref bool cond1, ref bool cond2, ref bool cond3, bool condCount)
		{
			return (API.FindExpedition<AlbumSlimes>(mod).completed)
				|| expedition.conditionCounted > 0;
		}

		public override void CheckConditionCountable(Player player, ref int count, int max)
		{
			count = 0;
			if (King) count++;
			if (Mother) count++;
			if (Dungeon) count++;
			if (Lava) count++;
		}

		public override bool CheckConditions(Player player, ref bool cond1, ref bool cond2, ref bool cond3, bool condCount)
		{
			cond1 = King && Mother;
			cond2 = Dungeon;
			cond3 = Lava;
			return cond1 && cond2 && cond3;
		}

		public override void PreCompleteExpedition(List<Item> rewards, List<Item> deliveredItems)
		{
			PhotoManager.ConsumePhoto(NPCID.KingSlime);
			PhotoManager.ConsumePhoto(NPCID.MotherSlime);
			PhotoManager.ConsumePhoto(NPCID.DungeonSlime);
			PhotoManager.ConsumePhoto(NPCID.LavaSlime);

			// Only reward the coupon once!
			if (expedition.completed)
			{ rewards[0] = new Item(); }
		}
	}
}
