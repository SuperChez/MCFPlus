using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCFPlus
{
    namespace Compilation
    {
        namespace DatapackAssets
        {
            public class Datapack : MCFObject
            {
                public Datapack(string registry, string body)
                {
                    Registry = registry;
                    ObjectType = MCFType.Datapack;
                    Keyword = "datapack";
                    ValidChildren = new MCFType[] { MCFType.Namespace, MCFType.Metadata };
                }

                public bool Write()
                {
                    string path = Interpreter.OUTPUT_PATH + Registry + @"\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    return true;
                }

                public override bool? AddChild(MCFObject obj)
                {
                    if (obj == null || Children.Contains(obj) || obj.ObjectType != MCFType.Namespace)
                    {
                        return false;
                    }
                    Children.Add(obj);
                    return true;
                }
            }
            public class Namespace : MCFObject
            {
                public Namespace(string registry, string body)
                {
                    Registry = registry;
                    ObjectType = MCFType.Namespace;
                    Keyword = "namespace";
                }

                public override bool Write(MCFObject parent)
                {
                    if (parent.ObjectType != MCFType.Datapack)
                    {
                        return false;
                    }
                    return true;
                }
            }

            public class Function : MCFObject
            {
                public Function(string registry, string body)
                {
                    Registry = registry;
                    ObjectType = MCFType.Function;
                    Keyword = "function";
                }
            }

            public class Command : MCFObject
            {
                private string Source;
                private string[] Tokens;
                private StringBuilder Output = new();
                public Command(string cmd)
                {
                    Source = cmd;
                    Tokens = cmd.Split(' ');
                }
                public enum CommandType
                {
                    Advancement,
                    Attribute,
                    Ban,
                    BanIP,
                    Banlist,
                    Bossbar,
                    Clear,
                    Clone,
                    Data,
                    Datapack,
                    Debug,
                    DefaultGameMode,
                    Deop,
                    Difficulty,
                    Effect,
                    Enchant,
                    Execute,
                    Fill,
                    Forceload,
                    Function,
                    Gamemode,
                    Gamerule,
                    Give,
                    Help,
                    Item,
                    JFR,
                    Kick,
                    Kill,
                    List,
                    Locate,
                    Loot,
                    Me,
                    MSG,
                    Op,
                    Pardon,
                    PardonIP,
                    Perf,
                    Place,
                    Playsound,
                    Publish,
                    Recipe,
                    Reload,
                    SaveAll,
                    SaveOff,
                    SaveOn,
                    Say,
                    Schedule,
                    Scoreboard,
                    Seed,
                    Setblock,
                    SetIdelTimeout,
                    SetWorldSpawn,
                    Spawnpoint,
                    Spectate,
                    SpreadPlayers,
                    Stop,
                    Stopsound,
                    Summon,
                    Tag,
                    Team,
                    TeamMSG,
                    Teleport,
                    Tell,
                    Tellraw,
                    Time,
                    Title,
                    TP,
                    Trigger,
                    Weather,
                    Whitelist,
                    Worldborder,
                    XP
                }
            }
        }
    }
}
