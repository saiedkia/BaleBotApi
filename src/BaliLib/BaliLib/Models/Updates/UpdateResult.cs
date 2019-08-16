using System.Collections.Generic;

namespace BaleLib.Models.Updates
{
    public class UpdateResult
    {
        public List<UpdateResponse> Result { get; set; }
        public bool Ok { get; set; }

    }
}
