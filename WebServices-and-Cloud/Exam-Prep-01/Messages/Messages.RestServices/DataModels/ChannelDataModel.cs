using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessagesRestService.DataModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Messages.Data;

    public class ChannelDataModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}