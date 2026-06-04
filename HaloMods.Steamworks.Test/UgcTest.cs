using Microsoft.VisualStudio.TestTools.UnitTesting;
using Steamworks.Data;
using Steamworks.Ugc;
using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Steamworks
{
    [TestClass]
    [DeploymentItem( "steam_api64.dll" )]
	public class UgcTest
    {
		[TestMethod]
        public void Download()
        {
			SteamUGC.Download( 2962107814 );
		}

		[TestMethod]
		public async Task GetInformationValid()
		{
			var itemInfo = await Ugc.Item.GetAsync(2962107814);

			Assert.IsTrue(itemInfo.HasValue);

            Console.WriteLine($"Result: {itemInfo?.Result}");
            Console.WriteLine($"Title: {itemInfo?.Title}");
            Console.WriteLine($"Description: {itemInfo?.Description}");
            Console.WriteLine($"Tags: {string.Join(",", itemInfo?.Tags)}");
            Console.WriteLine($"IsInstalled: {itemInfo?.IsInstalled}");
            Console.WriteLine($"IsDownloading: {itemInfo?.IsDownloading}");
            Console.WriteLine($"IsDownloadPending: {itemInfo?.IsDownloadPending}");
            Console.WriteLine($"IsSubscribed: {itemInfo?.IsSubscribed}");
            Console.WriteLine($"IsAcceptedForUse: {itemInfo?.IsAcceptedForUse}");
            Console.WriteLine($"IsPublic: {itemInfo?.IsPublic}");
            Console.WriteLine($"Created: {itemInfo?.Created}");
            Console.WriteLine($"Updated: {itemInfo?.Updated}");
            Console.WriteLine($"NeedsUpdate: {itemInfo?.NeedsUpdate}");
            Console.WriteLine($"Owner: {itemInfo?.Owner}");
            Console.WriteLine($"Score: {itemInfo?.Score}");
            Console.WriteLine($"Size: {itemInfo?.TotalSizeBytes}");
            Console.WriteLine($"Size On Disk: {itemInfo?.SizeBytes}");
            Console.WriteLine($"PreviewImageUrl: {itemInfo?.PreviewImageUrl}");
            Console.WriteLine($"NumComments: {itemInfo?.NumComments}");
            Console.WriteLine($"Url: {itemInfo?.Url}");
            Console.WriteLine($"Directory: {itemInfo?.Directory}");
        }

        [TestMethod]
        public async Task GetInformationInvalid()
        {
            // This id is a valid workshop item, however it has been removed or delisted
            var itemInfo = await Ugc.Item.GetAsync(3691769975);

            Assert.IsTrue(itemInfo.HasValue);

            Console.WriteLine($"Result: {itemInfo?.Result}");
            Console.WriteLine($"Title: {itemInfo?.Title}");
            Console.WriteLine($"Description: {itemInfo?.Description}");
            Console.WriteLine($"Tags: {string.Join(",", itemInfo?.Tags)}");
            Console.WriteLine($"IsInstalled: {itemInfo?.IsInstalled}");
            Console.WriteLine($"IsDownloading: {itemInfo?.IsDownloading}");
            Console.WriteLine($"IsDownloadPending: {itemInfo?.IsDownloadPending}");
            Console.WriteLine($"IsSubscribed: {itemInfo?.IsSubscribed}");
            Console.WriteLine($"IsAcceptedForUse: {itemInfo?.IsAcceptedForUse}");
            Console.WriteLine($"IsPublic: {itemInfo?.IsPublic}");
            Console.WriteLine($"Created: {itemInfo?.Created}");
            Console.WriteLine($"Updated: {itemInfo?.Updated}");
            Console.WriteLine($"NeedsUpdate: {itemInfo?.NeedsUpdate}");
            Console.WriteLine($"Owner: {itemInfo?.Owner}");
            Console.WriteLine($"Score: {itemInfo?.Score}");
            Console.WriteLine($"Size: {itemInfo?.TotalSizeBytes}");
            Console.WriteLine($"Size On Disk: {itemInfo?.SizeBytes}");
            Console.WriteLine($"PreviewImageUrl: {itemInfo?.PreviewImageUrl}");
            Console.WriteLine($"NumComments: {itemInfo?.NumComments}");
            Console.WriteLine($"Url: {itemInfo?.Url}");
            Console.WriteLine($"Directory: {itemInfo?.Directory}");
        }
    }
}
