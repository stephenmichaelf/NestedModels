using System.Collections.Generic;

namespace NestedModels.Models
{
    public class Phone
    {
        public Phone()
        {
            Extensions = new List<Extension>();
            CreateExtensions();
        }

        public int PhoneId { get; set; }
        public string PhoneNumber { get; set; }
        public bool DeletePhone { get; set; }

        public virtual ICollection<Extension> Extensions { get; set; }

        internal void CreateExtensions(int count = 3)
        {
            for (int i = 0; i < count; i++)
            {
                Extensions.Add(new Extension());
            }
        }
    }

    public class Extension
    {
        public int ExtensionId { get; set; }
        public int ExtensionDetailsId { get; set; }
        public virtual ExtensionDetails ExtensionDetails { get; set; }
        public string Count { get; set; }
    }

    public class ExtensionDetails
    {
        public int ExtensionDetailsId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
    }
}