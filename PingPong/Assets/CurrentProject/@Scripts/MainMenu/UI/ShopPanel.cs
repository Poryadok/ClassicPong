using System.Collections.Generic;
using PM.PingPong.General;
using PM.UsefulThings;
using UIBinding;
using UnityEngine;
using Zenject;

namespace PM.PingPong.MainMenu
{
	public class ShopPanel : AbPanel
	{
		private readonly ListProperty shopItems = new();

		private ShopListElementData.ShopLEDFactory shopLedFactory;
		private GeneralConfigHolder generalConfigHolder;
		private Merchandiser merchandiser;

		[Inject]
		public void Construct(ShopListElementData.ShopLEDFactory shopLedFactory,
			GeneralConfigHolder generalConfigHolder,
			Merchandiser merchandiser)
		{
			this.shopLedFactory = shopLedFactory;
			this.generalConfigHolder = generalConfigHolder;
			this.merchandiser = merchandiser;
		}

		private void Start()
		{
			FillElements();
			shopItems.OnClick += OnShopItemClick;
		}

		private void OnDestroy()
		{
			shopItems.OnClick -= OnShopItemClick;
		}

		private void OnShopItemClick(BaseListElementData target)
		{
			var led = (ShopListElementData)target;
			if (led.State == ShopLEDState.Bought)
			{
				merchandiser.SetActiveSkin(led.Config.Id);
			}

			FillElements();
		}

		private void FillElements()
		{
			var elements = new List<ShopListElementData>();

			foreach (var shopItem in generalConfigHolder.ShopItems)
			{
				elements.Add(shopLedFactory.Create(shopItem));
			}

			shopItems.value = elements;
		}

		public void Back()
		{
			Close();
		}
	}
}