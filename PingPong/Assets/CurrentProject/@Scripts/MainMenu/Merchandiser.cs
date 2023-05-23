using System.Collections.Generic;
using System.Linq;
using PM.PingPong.General;
using PM.UsefulThings.Extensions;
using UnityEngine;

namespace PM.PingPong.MainMenu
{
	public class Merchandiser
	{
		public const string ACTIVE_ITEM_KEY = "activeItem";
		public const string ITEM_BOUGHT_PREFIX = "itemBought{0}";
		public const string ITEM_PROGRESS_PREFIX = "itemProgress{0}";

		private GeneralConfigHolder generalConfigHolder;

		public Merchandiser(GeneralConfigHolder generalConfigHolder)
		{
			this.generalConfigHolder = generalConfigHolder;
		}

		public bool IsItemBought(string id)
		{
			return PlayerPrefs.HasKey(string.Format(ITEM_BOUGHT_PREFIX, id));
		}

		public int GetItemProgress(string id)
		{
			return PlayerPrefs.GetInt(string.Format(ITEM_PROGRESS_PREFIX, id));
		}

		public bool IsActive(string id)
		{
			return GetActiveSkin() == id;
		}

		public void SetActiveSkin(string id)
		{
			PlayerPrefs.SetString(ACTIVE_ITEM_KEY, id);
		}

		public void SetItemBought(string id)
		{
			PlayerPrefs.SetInt(string.Format(ITEM_BOUGHT_PREFIX, id), 1);
		}

		public string GetActiveSkin()
		{
			return PlayerPrefs.GetString(ACTIVE_ITEM_KEY);
		}

		public string GetItemInProgress()
		{
			foreach (var item in generalConfigHolder.ShopItems)
			{
				if (!item.IsDefault && !IsItemBought(item.Id))
				{
					return item.Id;
				}
			}

			return "-1";
		}

		public void AddProgress(string id, int progress = 1)
		{
			var currentProgress = GetItemProgress(id);
			currentProgress += progress;
			if (generalConfigHolder.ShopItems.Find(x => x.Id == id).Cost <= currentProgress)
			{
				SetItemBought(id);
				PlayerPrefs.DeleteKey(string.Format(ITEM_PROGRESS_PREFIX, id));
			}
			else
			{
				PlayerPrefs.SetInt(string.Format(ITEM_PROGRESS_PREFIX, id), currentProgress);
			}
		}

		public void AddProgressToCurrentItem(int progress = 1)
		{
			AddProgress(GetItemInProgress(), progress);
		}
	}
}