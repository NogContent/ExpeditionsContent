﻿using Terraria;
using Terraria.ModLoader;

namespace ExpeditionsContent144.Items.Albums
{
	public class AlbumFlora : ModItem
	{
		public override void SetStaticDefaults()
		{
			/****DisplayName.SetDefault("Man-Eating Plants in the Wild, 1st ed.");
            Tooltip.SetDefault("'It contains pictures and notes on dangerous plants'"
                + AlbumAnimalFirst.Value2ToolTip(this, Item.sellPrice(0, 6, 0, 0)));*/
		}
		public override void SetDefaults()
		{
			AlbumAnimalFirst.SetDefaultAlbum(this,
				Item.sellPrice(0, 6, 0, 0), 2, 18
				);
		}
		public override void AddRecipes()
		{
			AlbumAnimalFirst.AddCopyRecipes(this, 2);
		}
	}
}
