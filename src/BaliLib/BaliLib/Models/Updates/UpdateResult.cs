using System.Collections.Generic;

namespace BaleLib.Models.Updates
{
    public class UpdateResult
    {
        public List<Update> Result { get; set; }
        public bool Ok { get; set; }
        public long Errorcode { get; set; }
    }
}
