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
	public class GameServerStatsTest
	{
		static SteamId David = 76561198980310360;

		[TestMethod]
        public async Task GetAchievement()
        {
			var result = await SteamServerStats.RequestUserStatsAsync( David );
			Assert.AreEqual( Result.OK, result );

			var value = SteamServerStats.GetAchievement( David, "10_0_DIRGE_OF_MADRIGAL");
			Assert.IsTrue( value );

			value = SteamServerStats.GetAchievement( David, "ACHIVEMENT_THAT_DOESNT_EXIST" );
			Assert.IsFalse( value );
		}
	}

}
