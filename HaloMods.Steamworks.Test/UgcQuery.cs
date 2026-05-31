using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Steamworks.Data;

namespace Steamworks
{
    [TestClass]
    [DeploymentItem( "steam_api64.dll" )]
	public class UgcQueryTests
    {
		[TestMethod]
        public async Task QueryAll()
        {
			var q = Ugc.Query.All;

			var result = await q.GetPageAsync( 1 );
			Assert.IsNotNull( result );

			Console.WriteLine( $"ResultCount: {result?.ResultCount}" );
			Console.WriteLine( $"TotalCount: {result?.TotalCount}" );
		}

		[TestMethod]
		public async Task QueryWithCreatorApp() 
		{
            var q = Ugc.Query.All
							.WhereCreatorApp( 976730 );

            var result = await q.GetPageAsync(1);
            Assert.IsNotNull(result);

            Console.WriteLine($"ResultCount: {result?.ResultCount}");
            Console.WriteLine($"TotalCount: {result?.TotalCount}");
        }

        [TestMethod]
		public async Task QueryWithTags()
		{
            var q = Ugc.Query.All
                            .WithTag( "halo4" )
                            .WithTag( "campaign" )
                            .MatchAllTags();

            var result = await q.GetPageAsync( 1 );
            Assert.IsNotNull( result );
            Assert.IsTrue( result?.ResultCount > 0 );

			Console.WriteLine( $"ResultCount: {result?.ResultCount}" );
			Console.WriteLine( $"TotalCount: {result?.TotalCount}" );

            foreach ( var entry in result.Value.Entries )
            {
                Console.WriteLine($"Name: {entry.Title} [{entry.Id}]");

                Assert.IsTrue(entry.HasTag("halo4"), $"Item '{entry.Title}' is missing 'halo4' tag.");
                Assert.IsTrue(entry.HasTag("campaign"), $"Item '{entry.Title}' is missing 'campaign' tag.");
            }
        }

		[TestMethod]
		public async Task QueryAllFromFriends()
		{
			var q = Ugc.Query.All
						.CreatedByFriends();

			var result = await q.GetPageAsync( 1 );
			Assert.IsNotNull( result );

			Console.WriteLine( $"ResultCount: {result?.ResultCount}" );
			Console.WriteLine( $"TotalCount: {result?.TotalCount}" );

			foreach ( var entry in result.Value.Entries )
			{
				Console.WriteLine( $" {entry.Title}" );
			}
		}

		[TestMethod]
		public async Task QueryUserOwn()
		{
			var q = Ugc.Query.All
							.WhereUserPublished();

			var result = await q.GetPageAsync( 1 );
			Assert.IsNotNull( result );

			Console.WriteLine( $"ResultCount: {result?.ResultCount}" );
			Console.WriteLine( $"TotalCount: {result?.TotalCount}" );

			foreach ( var entry in result.Value.Entries )
			{
				Console.WriteLine( $" {entry.Title}" );
			}
		}

		[TestMethod]
		public async Task QueryDavid()
		{
			var q = Ugc.Query.All
							.WhereUserPublished( 76561198980310360 );

			var result = await q.GetPageAsync( 1 );
			Assert.IsNotNull( result );
			Assert.IsTrue( result?.ResultCount > 0 );

			Console.WriteLine( $"ResultCount: {result?.ResultCount}" );
			Console.WriteLine( $"TotalCount: {result?.TotalCount}" );

			foreach ( var entry in result.Value.Entries )
			{
				Console.WriteLine( $" {entry.Title}" );
			}
		}

		[TestMethod]
		public async Task QuerySpecificFile()
		{
            var item = await SteamUGC.QueryFileAsync( 2962107814 );

            Assert.IsTrue( item.HasValue );
			Assert.IsNotNull( item.Value.Title );

			Console.WriteLine( $"Title: {item?.Title}" );
			Console.WriteLine( $"Desc: {item?.Description}" );
			Console.WriteLine( $"Tags: {string.Join( ",", item?.Tags )}" );
			Console.WriteLine( $"Author: {item?.Owner.Name} [{item?.Owner.Id}]" );
			Console.WriteLine( $"PreviewImageUrl: {item?.PreviewImageUrl}" );
			Console.WriteLine( $"NumComments: {item?.NumComments}" );
			Console.WriteLine( $"Url: {item?.Url}" );
			Console.WriteLine( $"Directory: {item?.Directory}" );
			Console.WriteLine( $"IsInstalled: {item?.IsInstalled}" );
			Console.WriteLine( $"IsAcceptedForUse: {item?.IsAcceptedForUse}" );
			Console.WriteLine( $"IsPublic: {item?.IsPublic}" );
			Console.WriteLine( $"Created: {item?.Created}" );
			Console.WriteLine( $"Updated: {item?.Updated}" );
			Console.WriteLine( $"Score: {item?.Score}" );
		}
	}

}
