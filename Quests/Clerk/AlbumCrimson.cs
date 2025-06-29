﻿using System;
using Terraria;
using Terraria.ID;
using Expeditions144;
using System.Collections.Generic;
using Terraria.ModLoader;

namespace ExpeditionsContent144.Quests.Clerk
{
	class AlbumCrimson : ModExpedition
	{
		public override void SetDefaults()
		{
			expedition.name = "Snap! Crimson Landscape";
			SetNPCHead(ExpeditionC144.NPCIDClerk);
			expedition.difficulty = 2;
			expedition.ctgCollect = true;
			expedition.ctgExplore = true;
			expedition.repeatable = true;

			expedition.conditionDescription1 = "Face Monster";
			expedition.conditionDescription2 = "Blood Crawler, Crimera";
			expedition.conditionDescription3 = "Brain of Cthulu, Creeper";
			expedition.conditionCountedMax = 5;
			expedition.conditionDescriptionCountable = "Take photos of listed creatures";
		}
		public override void AddItemsOnLoad()
		{
			AddRewardItem(API.ItemIDExpeditionCoupon, 1, true);
			AddRewardItem(ModContent.ItemType<Items.Albums.AlbumCrimson>());
		}
		public override string Description(bool complete)
		{
			return "Please be extra careful when you're in the crimson. The chasms may lead to sudden drops, and the monsters there are very aggressive. At least it will be easier to take pictures of them, right? ";
		}
		#region Photo Bools
		public static PhotoManager fm = new PhotoManager(NPCID.FaceMonster);
		public static PhotoManager bc = new PhotoManager(false,
			NPCID.BloodCrawler, NPCID.BloodCrawlerWall);
		public static PhotoManager cr = new PhotoManager(NPCID.Crimera);
		public static PhotoManager BoC = new PhotoManager(NPCID.BrainofCthulhu);
		public static PhotoManager cp = new PhotoManager(NPCID.Creeper);
		#endregion

		public override bool CheckPrerequisites(Player player, ref bool cond1, ref bool cond2, ref bool cond3, bool condCount)
		{
			return (API.FindExpedition<AlbumOmnibus2>(mod).completed // Completed the second tier
				&& WorldGen.crimson)
				|| expedition.conditionCounted > 0; // Already done (repeatable)
		}

		public override void CheckConditionCountable(Player player, ref int count, int max)
		{
			count = 0;
			if (fm.checkValid()) count++;
			if (bc.checkValid()) count++;
			if (cr.checkValid()) count++;
			if (cp.checkValid()) count++;
			if (BoC.checkValid()) count++;
		}

		public override bool CheckConditions(Player player, ref bool cond1, ref bool cond2, ref bool cond3, bool condCount)
		{
			cond1 = fm.checkValid();
			cond2 = bc.checkValid() && cr.checkValid();
			cond3 = BoC.checkValid() && cp.checkValid();
			return cond1 && cond2 && cond3;
		}

		public override void PreCompleteExpedition(List<Item> rewards, List<Item> deliveredItems)
		{
			fm.consumePhoto();
			bc.consumePhoto();
			cr.consumePhoto();
			cp.consumePhoto();
			BoC.consumePhoto();

			// Only reward the coupon once!
			if (expedition.completed)
			{ rewards[0] = new Item(); }
		}
	}
}