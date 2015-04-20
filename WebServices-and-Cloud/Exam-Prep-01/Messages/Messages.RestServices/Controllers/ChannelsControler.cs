namespace MessagesRestService.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Messages.Data;

    using MessagesRestService.BindingModels;
    using MessagesRestService.DataModels;

    [RoutePrefix("api")]
    public class ChannelsControler : BaseApiController
    {
        [HttpGet]
        [Route("channels")]
        public IHttpActionResult GetChannels()
        {
            var channels =
                this.Data.Channels.OrderBy(c => c.Name).Select(c => new ChannelDataModel { Id = c.Id, Name = c.Name });

            return this.Ok(channels);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetChannelsById(int id)
        {
            var channels = this.Data.Channels.OrderBy(c => c.Name).Select(c => new ChannelDataModel { Id = c.Id, Name = c.Name }).FirstOrDefault(c => c.Id == id);
            return this.Ok(channels);
        }

        [HttpPost]
        public IHttpActionResult PostChannel(ChannelBindingModel model)
        {
            if (model == null || this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (this.Data.Channels.Any(c => c.Name == model.Name))
            {
                return this.Conflict();
            }

            var channel = new Channel { Name = model.Name };

            this.Data.Channels.Add(channel);
            this.Data.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = channel.Id }, channel);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult EditChannel(int id, ChannelBindingModel model)
        {
            if (model == null || this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (this.Data.Channels.Any(c => c.Name == model.Name))
            {
                return this.Conflict();
            }

            var channel = this.Data.Channels.FirstOrDefault(c => c.Id == id);

            if (channel == null)
            {
                return this.NotFound();
            }

            channel.Name = model.Name;
            this.Data.SaveChanges();

            return this.Ok(new
                           {
                               Message = string.Format("Channel #{0} edited successfully.", channel.Id)
                           });
        }
    }
}