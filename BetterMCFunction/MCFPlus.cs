using System.Text;
using MCFPlus;

namespace MCFPlus
{
    public class MCFObject
    {
        public string Keyword { get; set; }
        protected string Registry { get; set; }
        protected List<MCFObject> Children { get; set; } = new();
        public MCFType ObjectType { get; set; }
        protected virtual MCFType[] ValidChildren { get; set; }

        public MCFObject()
        {
            Keyword = "empty";
            Registry = "object";
            ObjectType = MCFType.Empty;
            ValidChildren = Array.Empty<MCFType>();
        }

        public MCFObject(string keyword, string registry, MCFType objectType)
        {
            Keyword = keyword;
            Registry = registry;
            ObjectType = objectType;
            ValidChildren = Array.Empty<MCFType>();
        }


        public virtual void Read(string[] input)
        {
            return;
        }

        public virtual bool Write(MCFObject parent)
        {
            return false;
        }

        public virtual bool? AddChild(MCFObject obj)
        {
            return null;
        }
    }

    public class Resource : MCFObject
    {
        protected string Path { get; set; }

        public Resource()
        {
            Path = "empty";
        }

        public Resource(string path)
        {
            Path = path;
        }
    }

    public enum MCFType
    {
        Empty,
        Datapack,
        Namespace,
        Metadata,
        Function,
        Command,
        Resourcepack,
        Texture,
        Model
    }
}