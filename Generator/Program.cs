using Newtonsoft.Json;
using System.IO;

namespace Generator
{
    class Program
    {
        private const string OutputFolder = "Test/Facepunch.Steamworks/Generated/Interfaces";

        public static SteamApiDefinition Definitions;

		static void Main( string[] args )
        {
            var content = File.ReadAllText( "steam_sdk/steam_api.json" );
            var def = JsonConvert.DeserializeObject<SteamApiDefinition>( content );

			Definitions = def;

			var generator = new CodeWriter( def );

            if (!Directory.Exists(OutputFolder)) 
            {
                Directory.CreateDirectory(OutputFolder);
            }

            generator.ToFolder( "Test/Facepunch.Steamworks/Generated/" );
        }
    }
}


