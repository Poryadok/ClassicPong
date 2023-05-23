using System;
using System.Collections.Generic;
using PM.UsefulThings;
using UIBinding;
using UnityEngine;

namespace PM.PingPong.MainMenu
{
	public class ShopPanel : AbPanel
	{
		private readonly ListProperty shopItems = new();
		
		private void Start()
		{
			FillElements();
			shopItems.OnClick += OnShopItemClick;
		}

		private void OnDestroy()
		{
			shopItems.OnClick -= OnShopItemClick;
		}

		private void OnShopItemClick(BaseListElementData obj)
		{
			
		}

		private void FillElements()
		{
			var elements = new List<ShopListElementData>();
			
			
		}

		public void Back()
		{
			
		}
		
	}
}