using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BrainstormSessions.Core.Interfaces;
using BrainstormSessions.Core.Model;
using BrainstormSessions.Logs;
using BrainstormSessions.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;

namespace BrainstormSessions.Controllers
{
   public class HomeController : Controller
   {
      private readonly IBrainstormSessionRepository _sessionRepository;
      private readonly Serilog.ILogger _logger;

      public HomeController(IBrainstormSessionRepository sessionRepository, Serilog.ILogger logger)
      {
         _sessionRepository = sessionRepository;
         _logger = logger;
      }



      public async Task<IActionResult> Index()
      {
         var sessionList = await _sessionRepository.ListAsync();

         var model = sessionList.Select(session => new StormSessionViewModel()
         {
            Id = session.Id,
            DateCreated = session.DateCreated,
            Name = session.Name,
            IdeaCount = session.Ideas.Count
         });

         _logger.Information("The view model is created containing {number} sessions.", model.Count());

         return View(model);
      }

      public class NewSessionModel
      {
         [Required]
         public string SessionName { get; set; }
      }

      [HttpPost]
      public async Task<IActionResult> Index(NewSessionModel model)
      {
         if (!ModelState.IsValid)
         {
            _logger.Warning("Model state is invalid. The SessionName field is required.");
            return BadRequest(ModelState);
         }
         else
         {
            await _sessionRepository.AddAsync(new BrainstormSession()
            {
               DateCreated = DateTimeOffset.Now,
               Name = model.SessionName
            });
         }

         return RedirectToAction(actionName: nameof(Index));
      }
   }
}
