using ElevenNote_Models;
using ElevenNote_Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ElevenNote_WebMVC.Controllers
{
    [Authorize]
    [RoutePrefix("api/Note")]
    public class NoteApiController : ApiController
    {
        private bool SetStarState(int noteId, bool newState)
        {
            //Create the service
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new NoteService(userId);

            //Get the Note
            var detail = service.GetNoteById(noteId);

            //Create the NoteEdit model instance with new star state
            var updateNote =
                new NoteEdit
                {
                    NoteId = detail.NoteId,
                    Title = detail.Title,
                    Content = detail.Content,
                    IsStarred = newState
                };

            //Return a value indicating whether the update succedede
            return service.UpdateNote(updateNote);
        }
        [Route("{id}/Star")]
        [HttpPut]
        public bool ToggleStarOn(int id) => SetStarState(id, true);

        [Route("{id}/Star")]
        [HttpDelete]
        public bool ToggleStarOff(int id) => SetStarState(id, false);
    }
}
