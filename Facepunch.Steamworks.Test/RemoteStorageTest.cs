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
	public class RemoteStorageTest
	{
		[TestMethod]
        public void Quotas()
        {
			Console.WriteLine( $"SteamRemoteStorage.QuotaBytes: {SteamRemoteStorage.QuotaBytes}" );
			Console.WriteLine( $"SteamRemoteStorage.QuotaRemainingBytes: {SteamRemoteStorage.QuotaRemainingBytes}" );
			Console.WriteLine( $"SteamRemoteStorage.QuotaUsedBytes: {SteamRemoteStorage.QuotaUsedBytes}" );
		}

		[TestMethod]
		public void IsCloudEnabled()
		{
			Console.WriteLine( $"SteamRemoteStorage.IsCloudEnabled: {SteamRemoteStorage.IsCloudEnabled}" );
			Console.WriteLine( $"SteamRemoteStorage.IsCloudEnabledForAccount: {SteamRemoteStorage.IsCloudEnabledForAccount}" );
			Console.WriteLine( $"SteamRemoteStorage.IsCloudEnabledForApp: {SteamRemoteStorage.IsCloudEnabledForApp}" );
		}

		[TestMethod]
		public void FileWrite()
		{
			var rand = new Random();
			var testFile = new byte[1024 * 1024 * 100];

			for( int i=0; i< testFile.Length; i++ )
			{
				testFile[i] = (byte) i;
			}

			var written = SteamRemoteStorage.FileWrite( "testfile", testFile );

			Assert.IsTrue( written );
			Assert.IsTrue( SteamRemoteStorage.FileExists( "testfile" ) );
			Assert.AreEqual( testFile.Length, SteamRemoteStorage.FileSize("testfile") );
		}

		[TestMethod]
		public void FileRead()
		{
			FileWrite();

			var data = SteamRemoteStorage.FileRead( "testfile" );

			Assert.IsNotNull( data );

			for ( int i = 0; i < data.Length; i++ )
			{
				Assert.AreEqual( data[i], (byte)i );
			}

			Assert.AreEqual( data.Length, SteamRemoteStorage.FileSize( "testfile" ) );
			Assert.AreEqual( 1024 * 1024 * 100, SteamRemoteStorage.FileSize("testfile") );
		}

		[TestMethod]
		public void Files()
		{
			foreach ( var file in SteamRemoteStorage.Files )
			{
				Console.WriteLine( $"{file} ({SteamRemoteStorage.FileSize(file)} {SteamRemoteStorage.FileTime( file )})" );
			}

		}
	}

}
