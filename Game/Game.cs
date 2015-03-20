﻿using System;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;

namespace TeridiumRPG
{
    public static class Game
    {
        public static string PlayerDataDir;
        public static string CharacterDataRoot;
        public static string ItemDataRoot;
        public static string GameData;
        static Deserializer Deserializer;

        static Game ()
        {
            Deserializer = new Deserializer ();
            PlayerDataDir = Environment.GetEnvironmentVariable ("HOME") + "/.teridiumwar/PlayerData";
            CharacterDataRoot = Environment.GetEnvironmentVariable ("HOME") + "/.teridiumwar/CharacterData";
            ItemDataRoot = Environment.GetEnvironmentVariable ("HOME") + "/.teridiumwar/ItemData";
            GameData = Environment.GetEnvironmentVariable ("HOME") + "/.teridiumwar/GameData";
            if (!Directory.Exists (PlayerDataDir))
                Directory.CreateDirectory (PlayerDataDir);
        }

        static bool Save (string filename, object obj)
        {
            Serializer Serializer = new Serializer (SerializationOptions.Roundtrip);
            string tmpfilename = filename + ".tmp";
            try {
                if (File.Exists (tmpfilename))
                    File.Delete (tmpfilename);
                TextWriter writer = File.CreateText (tmpfilename);
                Serializer.Serialize (writer, obj);
                writer.Close ();
                File.Delete (filename);
                File.Move (tmpfilename, filename);
                return true;
            } catch (Exception ex) {
                return false;
            } finally {
                if (File.Exists (tmpfilename))
                    File.Delete (tmpfilename);
            }
        }

        public static bool SaveHero (Hero hero)
        {
            return Save (PlayerDataDir + "/" + hero.Identifier + ".yml", hero);
        }

        public static Hero LoadHero (string name)
        {
            return Deserializer.Deserialize<Hero> (File.OpenText (PlayerDataDir + "/" + name + ".yml"));
        }

        public static Array ListHeros ()
        {
            List<string> retval = new List<string> ();
            var files = Directory.GetFiles (PlayerDataDir);
            foreach (string filename in files) {
                FileInfo fileinfo = new FileInfo (filename);
                var heroname = fileinfo.Name.Substring (0, fileinfo.Name.IndexOf ("."));
                if (heroname != "")
                    retval.Add (heroname);
            }
            return retval.ToArray ();
        }

        public static Character LoadCharacter (string name)
        {
            Character character = Deserializer.Deserialize<Character> (File.OpenText (CharacterDataRoot + "/" + name + "/info.yml"));
            if (character.Print != null)
                character.Print = File.OpenText (CharacterDataRoot + "/" + name + "/" + character.Print).ReadToEnd ();
            return character;
        }

        public static Character[] LoadAllCharacters ()
        {
            List<Character> chars = new List<Character> ();
            foreach (string dir in Directory.GetDirectories(CharacterDataRoot)) {
                DirectoryInfo dirinfo = new DirectoryInfo (dir);
                chars.Add (LoadCharacter (dirinfo.Name));
            }
            return chars.ToArray ();
        }

        public static Item LoadItem (string name)
        {
            return Deserializer.Deserialize<Item> (File.OpenText (ItemDataRoot + "/" + name + "/info.yml"));
        }

        public static Item[] LoadAllItems ()
        {
            List<Item> items = new List<Item> ();
            foreach (string dir in Directory.GetDirectories(ItemDataRoot)) {
                DirectoryInfo dirinfo = new DirectoryInfo (dir);
                items.Add (LoadItem (dirinfo.Name));
            }
            return items.ToArray ();
        }

        public static TeridiumRPG.Shop.Shop LoadShop (string name)
        {
            return Deserializer.Deserialize<TeridiumRPG.Shop.Shop> (File.OpenText (GameData + "/Shops/" + name + "/info.yml"));
        }

        public static void PrintObj (object obj)
        {
            Serializer Serializer = new Serializer (SerializationOptions.Roundtrip);
            Serializer.Serialize (Console.Out, obj);
        }
    }
}

