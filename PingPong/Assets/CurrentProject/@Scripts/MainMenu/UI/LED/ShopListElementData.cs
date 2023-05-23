using PM.PingPong.General;
using UIBinding;
using UIBinding.Elements;
using UnityEngine;
using Zenject;

namespace PM.PingPong.MainMenu
{
	public class ShopListElementData : BaseListElementData
	{
		private readonly SpriteProperty image = new();
		private readonly ColorProperty color = new();
		private readonly IntProperty state = new();
		private readonly StringProperty name = new();
		private readonly FloatProperty progressSlider = new();
		private readonly StringProperty progressText = new();

		private const string PROGRESS_TEMPLATE = "{0}/{1}";

		public ShopLEDState State { get; }
		public ShopItemConfig Config { get; }
		
		public ShopListElementData(ShopItemConfig config, Merchandiser merchandiser)
		{
			Config = config;
			
			image.value = config.Image;
			color.value = config.Color;
			name.value = config.Name;
			
			if (merchandiser.IsItemBought(config.Id) || config.IsDefault)
			{
				State = merchandiser.IsActive(config.Id)
					? ShopLEDState.Active
					: ShopLEDState.Bought;
				state.value = (int)State;
			}
			else
			{
				State = ShopLEDState.InProgress;
				state.value = (int)State;
				var progress = merchandiser.GetItemProgress(config.Id);
				progressText.value =
					string.Format(PROGRESS_TEMPLATE, progress, config.Cost);
				progressSlider.value = progress / (float)config.Cost;
			}
		}

		public class ShopLEDFactory : PlaceholderFactory<ShopItemConfig, ShopListElementData>
		{
		}
	}

	public enum ShopLEDState
	{
		InProgress = 0,
		Bought = 1,
		Active = 2
	}
}