using PM.PingPong.General;
using PM.UsefulThings.Extensions;
using UnityEngine;

namespace PM.PingPong.MainMenu
{
	public class FirstOpenAppSetup
	{
		public FirstOpenAppSetup(GeneralConfigHolder generalConfigHolder, Merchandiser merchandiser)
		{
			if (!PlayerPrefs.HasKey(Merchandiser.ACTIVE_ITEM_KEY))
			{
				merchandiser.SetActiveSkin(generalConfigHolder.ShopItems.Find(x => x.IsDefault).Id);
			}
		}
	}
}