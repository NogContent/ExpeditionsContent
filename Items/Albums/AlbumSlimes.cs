﻿using Terraria;
using Terraria.ModLoader;

namespace ExpeditionsContent144.Items.Albums
{
	public class AlbumSlimes : ModItem
	{
		public override void SetStaticDefaults()
		{
			/****DisplayName.SetDefault("Know Your Slimes, 1st ed.");
            Tooltip.SetDefault("'It contains photos of slimes and slime accessories'"
                + AlbumAnimalFirst.Value2ToolTip(this, Item.sellPrice(0, 3, 0, 0)));*/
		}
		public override void SetDefaults()
		{
			AlbumAnimalFirst.SetDefaultAlbum(this,
				Item.sellPrice(0, 3, 0, 0), 1, 4
				);
		}
		public override void AddRecipes()
		{
			AlbumAnimalFirst.AddCopyRecipes(this, 3);
		}
	}
}
